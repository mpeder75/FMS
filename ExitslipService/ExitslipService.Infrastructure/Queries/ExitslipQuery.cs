using ExitslipService.Application.Interfaces;
using ExitslipService.Application.Query.ExitSlipDTO;
using ExitslipService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitslipService.Application.Query;
using ExitslipService.Application.Query.QueryDto;
using ExitslipService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExitSlipService.Infrastructure.Queries
{
    public class ExitSlipQuery(ExitSlipContext db) : IExitSlipQuery
    {
        List<ExitSlip> IExitSlipQuery.GetAllByStudentId(Guid studentId)
        {
            throw new NotImplementedException();
        }

        List<ExitSlip> IExitSlipQuery.GetAllByLessonId(Guid lessonId)
        {
            throw new NotImplementedException();
        }

        QueryDTO IExitSlipQuery.GetOneById(Guid exitSlipId)
        {
            var result = db.ExitSlips.AsNoTracking().Single(a => a.Id == exitSlipId);
            
            return new QueryDTO
            {
                Id = result.Id,
                LessonId = result.LessonId,
                StudentId = result.StudentId,
                Questions = result.Questions,
                IsDistributed = result.IsDistributed,
                TeacherComment = result.TeacherComment,
                RowVersion = result.RowVersion
            };
        }
    }
}
