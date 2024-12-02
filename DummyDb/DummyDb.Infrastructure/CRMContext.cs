using DummyDb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DummyDb.Infrastructure
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    

        // Set DummyApi as Startup project, then open Package Manager Console and run the commands:
        // Add-Migration InitialMigration -Context CRMContext -Project DummyDb.DatabaseMigration
        // Update-Database -Context CRMContext -Project DummyDb.DatabaseMigration

        private async Task SeedDatabaseAsync()
        {
            string seedDataQuery = @"
                -- Insert data into SchoolClasses
                INSERT INTO SchoolClasses (Id, Name, Term) VALUES
                (NEWID(), 'Mathematics Class', 1),
                (NEWID(), 'Science Class', 2),
                (NEWID(), 'History Class', 1);

                -- Retrieve inserted SchoolClass IDs for relationships
                DECLARE @ClassId1 UNIQUEIDENTIFIER, @ClassId2 UNIQUEIDENTIFIER, @ClassId3 UNIQUEIDENTIFIER;
                SELECT TOP 1 @ClassId1 = Id FROM SchoolClasses WHERE Name = 'Mathematics Class';
                SELECT TOP 1 @ClassId2 = Id FROM SchoolClasses WHERE Name = 'Science Class';
                SELECT TOP 1 @ClassId3 = Id FROM SchoolClasses WHERE Name = 'History Class';

                -- Insert data into Teachers
                INSERT INTO Teachers (Id, FirstName, LastName, Email) VALUES
                (NEWID(), 'John', 'Doe', 'john.doe@example.com'),
                (NEWID(), 'Jane', 'Smith', 'jane.smith@example.com'),
                (NEWID(), 'Emily', 'Johnson', 'emily.johnson@example.com');

                -- Retrieve inserted Teacher IDs for relationships
                DECLARE @TeacherId1 UNIQUEIDENTIFIER, @TeacherId2 UNIQUEIDENTIFIER, @TeacherId3 UNIQUEIDENTIFIER;
                SELECT TOP 1 @TeacherId1 = Id FROM Teachers WHERE FirstName = 'John';
                SELECT TOP 1 @TeacherId2 = Id FROM Teachers WHERE FirstName = 'Jane';
                SELECT TOP 1 @TeacherId3 = Id FROM Teachers WHERE FirstName = 'Emily';

                -- Insert data into Rooms
                INSERT INTO Rooms (Id, Name, Description) VALUES
                (NEWID(), 'Room A', 'Mathematics Classroom'),
                (NEWID(), 'Room B', 'Science Laboratory'),
                (NEWID(), 'Room C', 'History Hall');

                -- Retrieve inserted Room IDs for relationships
                DECLARE @RoomId1 UNIQUEIDENTIFIER, @RoomId2 UNIQUEIDENTIFIER, @RoomId3 UNIQUEIDENTIFIER;
                SELECT TOP 1 @RoomId1 = Id FROM Rooms WHERE Name = 'Room A';
                SELECT TOP 1 @RoomId2 = Id FROM Rooms WHERE Name = 'Room B';
                SELECT TOP 1 @RoomId3 = Id FROM Rooms WHERE Name = 'Room C';

                -- Insert data into Students
                INSERT INTO Students (Id, FirstName, LastName, Email, SchoolClassId) VALUES
                (NEWID(), 'Alice', 'Brown', 'alice.brown@example.com', @ClassId1),
                (NEWID(), 'Bob', 'Davis', 'bob.davis@example.com', @ClassId1),
                (NEWID(), 'Charlie', 'Wilson', 'charlie.wilson@example.com', @ClassId2),
                (NEWID(), 'Diana', 'Evans', 'diana.evans@example.com', @ClassId2),
                (NEWID(), 'Edward', 'Scott', 'edward.scott@example.com', @ClassId3),
                (NEWID(), 'Fiona', 'Taylor', 'fiona.taylor@example.com', @ClassId3);

                -- Insert data into Lessons
                INSERT INTO Lessons (Id, Date, RoomId, SchoolClassId, TeacherId) VALUES
                (NEWID(), GETDATE(), @RoomId1, @ClassId1, @TeacherId1),
                (NEWID(), DATEADD(DAY, 1, GETDATE()), @RoomId2, @ClassId2, @TeacherId2),
                (NEWID(), DATEADD(DAY, 2, GETDATE()), @RoomId3, @ClassId3, @TeacherId3);

                -- Insert data into RoomSchoolClass (many-to-many relation)
                INSERT INTO RoomSchoolClass (RoomsId, SchoolClassesId) VALUES
                (@RoomId1, @ClassId1),
                (@RoomId2, @ClassId2),
                (@RoomId3, @ClassId3);
                ";
            await Database.ExecuteSqlRawAsync(seedDataQuery);
        }
    }
}