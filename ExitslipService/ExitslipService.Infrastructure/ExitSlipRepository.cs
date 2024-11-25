using ExitslipService.Application.Interfaces;
using ExitslipService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitSlipService.Infrastructure
{
    public class ExitSlipRepository : IExitSlipRepository
    {
        void IExitSlipRepository.Add(ExitSlip exitSlip)
        {
            throw new NotImplementedException();
        }

        void IExitSlipRepository.Update(ExitSlip exitSlip)
        {
            throw new NotImplementedException();
        }
    }
}
