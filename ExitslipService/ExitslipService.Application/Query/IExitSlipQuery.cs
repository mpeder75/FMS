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
        Task<List<ExitSlipDTO>> GetAllByStudentId(Guid studentId);

        Task<List<ExitSlipDTO>> GetAllByTeacherId(Guid teacherId);

        Task<List<ExitSlipDTO>> GetAllByLessonId(Guid lessonId);

        Task<ExitSlipPost> GetOneById(Guid exitSlipId);

    }
}
