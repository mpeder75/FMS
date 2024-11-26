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
        IEnumerable<ExitSlipDTO> GetAllByStudentId(Guid studentId);

        IEnumerable<ExitSlipDTO> GetAllByTeacherId(Guid teacherId);

        IEnumerable<ExitSlipDTO> GetAllByLessonId(Guid lessonId);

        ExitSlip GetOneById(Guid exitSlipId);

    }
}
