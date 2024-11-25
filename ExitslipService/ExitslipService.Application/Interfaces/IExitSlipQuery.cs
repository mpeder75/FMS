using ExitslipService.Application.Query.ExitSlipDTO;
using ExitslipService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitslipService.Application.Interfaces
{
    public interface IExitSlipQuery
    {
        ExitSlipDTO Get(Guid id);
    }
}
