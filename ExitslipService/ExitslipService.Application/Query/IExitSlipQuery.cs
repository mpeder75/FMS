using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitslipService.Application.Query.QueryDto;
using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Query
{
    public interface IExitSlipQuery
    {
        List<ExitSlip> GetAllByStudentId(Guid studentId);

        List<ExitSlip> GetAllByLessonId(Guid lessonId);

        QueryDTO GetOneById(Guid exitSlipId);

    }
}
