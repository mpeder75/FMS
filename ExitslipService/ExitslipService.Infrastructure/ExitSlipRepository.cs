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
        void IExitSlipRepository.Add(ExitSlip exitSlip)
        {
            context.ExitSlips.Add(exitSlip);
            context.SaveChanges();
        }

        void IExitSlipRepository.Update(ExitSlip exitSlip, byte[] rowVersion)
        {
            context.Entry(exitSlip).Property(nameof(exitSlip.RowVersion)).OriginalValue = exitSlip.RowVersion;
            context.SaveChanges();
        }
    }
}
