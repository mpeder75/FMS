@echo off
setlocal

rem Get the current directory
set "currentDir=%cd%"

set /p "app=Enter application name: "
choice /c YN /M "Are You Sure?"
if %errorlevel%==1 goto yes
if %errorlevel%==2 goto no

:yes
echo Creating %app%

if not exist "%currentDir%\%app%" mkdir "%currentDir%\%app%"
cd "%currentDir%\%app%"

dotnet new webapi -f net8.0 -au None -o %app%.Api
dotnet new classlib -f net8.0 -o %app%.Application
dotnet new classlib -f net8.0 -o %app%.Domain
dotnet new xunit -f net8.0 -o %app%.Domain.Test
dotnet new classlib -f net8.0 -o %app%.Infrastructure
dotnet new classlib -f net8.0 -o %app%.DatabaseMigration

dotnet add %app%.Api reference %app%.Application
dotnet add %app%.Api reference %app%.Domain
dotnet add %app%.Api reference %app%.Infrastructure
dotnet add %app%.Api reference %app%.DatabaseMigration
dotnet add %app%.Domain.Test reference %app%.Domain
dotnet add %app%.Application reference %app%.Domain
dotnet add %app%.Infrastructure reference %app%.Domain
dotnet add %app%.Infrastructure reference %app%.Application
dotnet add %app%.DatabaseMigration reference %app%.Infrastructure

dotnet new sln -n %app%
dotnet sln %app%.sln add %app%.Api/%app%.Api.csproj
dotnet sln %app%.sln add %app%.Application/%app%.Application.csproj
dotnet sln %app%.sln add %app%.Domain/%app%.Domain.csproj
dotnet sln %app%.sln add %app%.Domain.Test/%app%.Domain.Test.csproj
dotnet sln %app%.sln add %app%.Infrastructure/%app%.Infrastructure.csproj
dotnet sln %app%.sln add %app%.DatabaseMigration/%app%.DatabaseMigration.csproj

dotnet add %app%.Api/%app%.Api.csproj package Microsoft.EntityFrameworkCore
dotnet add %app%.Api/%app%.Api.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add %app%.Api/%app%.Api.csproj package Microsoft.EntityFrameworkCore.Tools

dotnet add %app%.DatabaseMigration/%app%.DatabaseMigration.csproj package Microsoft.EntityFrameworkCore
dotnet add %app%.DatabaseMigration/%app%.DatabaseMigration.csproj package Microsoft.EntityFrameworkCore.SqlServer

dotnet add %app%.Infrastructure/%app%.Infrastructure.csproj package AutoMapper
dotnet add %app%.Infrastructure/%app%.Infrastructure.csproj package Microsoft.EntityFrameworkCore
dotnet add %app%.Infrastructure/%app%.Infrastructure.csproj package Microsoft.EntityFrameworkCore.Relational

dotnet add %app%.Domain.Test/%app%.Domain.Test.csproj package Moq

echo Update nuget packages
dotnet tool install --global dotnet-outdated-tool 
dotnet outdated --upgrade

:no
endlocal
