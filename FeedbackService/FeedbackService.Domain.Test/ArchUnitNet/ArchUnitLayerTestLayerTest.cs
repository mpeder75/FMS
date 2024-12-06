using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;

namespace FeedbackService.Domain.Test.ArchUnitNet
{
    public class ArchUnitLayerTest : ArchUnitBaseTest
    {
        // ------------- Domain layer --------------
        [Fact]
        public void DomainLayer_ShoudNotHaveDependencyOn_ApplicationLayer()
        {
            ArchRuleDefinition
                .Types()
                .That()
                .Are(DomainLayer)
                .Should()
                .NotDependOnAny(ApplicationLayer)
                .Check(architecture);
        }

        [Fact]
        public void DomainLayer_ShoudNotHaveDependencyOn_InfrastructureLayer()
        {
            ArchRuleDefinition
                .Types()
                .That()
                .Are(DomainLayer)
                .Should()
                .NotDependOnAny(InfrastructureLayer)
                .Check(architecture);
        }

        [Fact]
        public void DomainLayer_ShoudNotHaveDependencyOn_ApiLayer()
        {
            ArchRuleDefinition
                .Types()
                .That()
                .Are(DomainLayer)
                .Should()
                .NotDependOnAny(ApiLayer)
                .Check(architecture);
        }

        // ------------- Application layer --------------
        [Fact]
        public void ApplicationLayer_ShoudNotHaveDependencyOn_InfrastructureLayer()
        {
            ArchRuleDefinition
                .Types()
                .That()
                .Are(ApplicationLayer)
                .Should()
                .NotDependOnAny(InfrastructureLayer)
                .Check(architecture);
        }

        [Fact]
        public void ApplicationLayer_ShoudNotHaveDependencyOn_ApiLayer()
        {
            ArchRuleDefinition
                .Types()
                .That()
                .Are(ApplicationLayer)
                .Should()
                .NotDependOnAny(ApiLayer)
                .Check(architecture);
        }

        // ------------- Infrastructure layer --------------
        [Fact]
        public void InfrastructureLayer_ShoudNotHaveDependencyOn_ApiLayer()
        {
            ArchRuleDefinition
                .Types()
                .That()
                .Are(InfrastructureLayer)
                .Should()
                .NotDependOnAny(ApiLayer)
                .Check(architecture);
        }
    }
}
