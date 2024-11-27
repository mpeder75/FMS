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
        Task<IEnumerable<ExitSlipDTO>> GetAllByStudentId(Guid studentId);

        Task<IEnumerable<ExitSlipDTO>> GetAllByTeacherId(Guid teacherId);

        Task<IEnumerable<ExitSlipDTO>> GetAllByLessonId(Guid lessonId);

        Task<ExitSlip> GetOneById(Guid exitSlipId);

    }
}
