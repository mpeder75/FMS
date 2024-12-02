using ExitslipService.Application.Command.CommandDto;
using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Interfaces;

public interface IExitSlipRepository
{
    void Add(ExitSlipPost exitSlip);

    void Update(ExitSlipPost exitSlip, byte[] rowVersion);

}