using ExitslipService.Application.Command.CommandDto;

namespace ExitslipService.Application.Command;

public class ExitSlipCommand : IExitSlipCommand
{
    void IExitSlipCommand.Create(CreateDTO createExitSlipDto)
    {
        throw new NotImplementedException();
    }

    void IExitSlipCommand.Update(UpdateDTO updateExitSlipDto)
    {
        throw new NotImplementedException();
    }
}