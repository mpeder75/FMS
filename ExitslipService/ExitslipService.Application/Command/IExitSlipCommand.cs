using ExitslipService.Application.Command.CommandDto;

namespace ExitslipService.Application.Command;

public interface IExitSlipCommand
{
    void CreatePost(CreateExitSlipPostDTO createExitSlipPostDto);

    void CreateReply(CreateExitSlipReplyDTO createExitSlipReplyDto);
}