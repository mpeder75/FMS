using ExitslipService.Application.Command.CommandDto;

namespace ExitslipService.Application.Command;

public interface IExitSlipCommand
{
    void Create(CreateExitSlipDTO createExitSlipExitSlipDto);

    void Update(UpdateExitSlipDTO updateExitSlipExitSlipDto);
}