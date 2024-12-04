using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using FeedbackService.Domain.ArchUnitNet;

namespace FeedbackService.Domain.Test
{
    public abstract class ArchUnitBaseTest : BaseTest
    {
        protected static readonly Architecture architecture = new ArchLoader()
            .LoadAssemblies(
                DomainAssembly,
                ApplicationAssembly,
                InfrastructureAssembly,
                ApiAssembly)
            .Build();

        protected static readonly IObjectProvider<IType> DomainLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(DomainAssembly).As("Domain Layer");

        protected static readonly IObjectProvider<IType> ApplicationLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(ApplicationAssembly).As("Application Layer");

        protected static readonly IObjectProvider<IType> InfrastructureLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(InfrastructureAssembly).As("Infrastructure Layer");

        protected static readonly IObjectProvider<IType> ApiLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(ApiAssembly).As("Api Layer");
    }
}