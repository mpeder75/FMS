using ExitslipService.Application.Command.CommandDto;

namespace ExitslipService.Application.Command;

public interface IExitSlipCommand
{
    void Create(CreateDTO createExitSlipDto);

    void Update(UpdateDTO updateExitSlipDto);
}