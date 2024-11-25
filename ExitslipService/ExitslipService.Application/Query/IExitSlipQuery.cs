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
        List<ExitSlipDTO> GetAllByStudentId(Guid studentId);

        List<ExitSlipDTO> GetAllByTeacherId(Guid teacherId);

        List<ExitSlipDTO> GetAllByLessonId(Guid lessonId);

        ExitSlip GetOneById(Guid exitSlipId);

    }
}
