using Assembly = System.Reflection.Assembly;
using FeedbackService.Application.Command;
using FeedbackService.Infrastructure;
using FeedbackService.Api;

namespace FeedbackService.Domain.ArchUnitNet
{
    public abstract class BaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(DomainEntity).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(IFeedbackPostCommand).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(FeedbackContext).Assembly;
        protected static readonly Assembly ApiAssembly = typeof(Program).Assembly;
    }
}

