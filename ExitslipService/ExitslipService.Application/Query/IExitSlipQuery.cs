using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitslipService.Application.Query.ExitSlipDto;
using ExitslipService.Domain.Entities;


namespace ExitslipService.Application.Query
{
    public interface IExitSlipQuery
    {
        Task<List<ExitSlipReplyDTO>> GetAllByStudentId(Guid studentId);

        Task<List<ExitSlipReplyDTO>> GetAllByLessonId(Guid lessonId);

        Task<ExitSlipPost> GetOneById(Guid exitSlipId);

    }
}
