using ExitslipService.Application.Interfaces;
using ExitslipService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitSlipService.Infrastructure
{
    public class ExitSlipRepository(ExitSlipContext context, HttpClient client) : IExitSlipRepository
    {
        void IExitSlipRepository.Add(ExitSlipPost exitSlip)
        {
            context.ExitSlipPosts.Add(exitSlip);
            context.SaveChanges();
        }

        void IExitSlipRepository.Add(ExitSlipReply exitSlip)
        {
            context.ExitSlipReplies.Add(exitSlip);
            context.SaveChanges();
        }

        void IExitSlipRepository.Update(ExitSlipPost exitSlip, byte[] rowVersion)
        {
            context.Entry(exitSlip).Property(nameof(exitSlip.RowVersion)).OriginalValue = exitSlip.RowVersion;
            context.SaveChanges();
            
        }
    }
}
