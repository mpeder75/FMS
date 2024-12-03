using ExitslipService.Application.Command.CommandDto;

namespace ExitslipService.Application.Command;

public interface IExitSlipCommand
{
    void Create(CreateExitSlipDTO createExitSlipDto);

    void CreateReply(UpdateExitSlipDTO updateExitSlipDTO);
    void Update(UpdateExitSlipDTO updateExitSlipDto);
}