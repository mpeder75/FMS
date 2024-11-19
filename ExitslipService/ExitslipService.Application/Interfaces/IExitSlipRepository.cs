using ExitslipService.Application.Command.CommandDto;
using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Interfaces;

public interface IExitSlipRepository
{
    void Add(ExitSlip exitSlip);

    void Update(ExitSlip exitSlip);

    ExitSlip Get(Guid id);
}