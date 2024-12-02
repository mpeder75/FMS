using System.Linq;
using ExitslipService.Domain.Entities;
using ExitslipService.Application.Query;
using Microsoft.EntityFrameworkCore;
using ExitslipService.Application.Query.ExitSlipDto;
using ExitslipService.Application.Query.QueryDto;

namespace ExitSlipService.Infrastructure.Queries
{
    public class ExitSlipQuery(ExitSlipContext db) : IExitSlipQuery
    {
        async Task<List<ExitSlipDTO>> IExitSlipQuery.GetAllByStudentId(Guid studentId)
        {
            var result = db.ExitSlips.Where(e => e.StudentId == studentId).Select(exitSlip => new ExitSlipDTO
            {
                StudentId = exitSlip.StudentId,
                LessonId = exitSlip.LessonId,
                Questions = (List<QuestionFormDTO>)exitSlip.Questions,
                IsDistributed = exitSlip.IsDistributed,
                TeacherId = exitSlip.TeacherId,
                TeacherComment = exitSlip.TeacherComment,
                RowVersion = exitSlip.RowVersion,
            }).ToListAsync();
            return await result;
        }

        async Task<List<ExitSlipDTO>> IExitSlipQuery.GetAllByLessonId(Guid lessonId)
        {
            var result = db.ExitSlips.Where(e => e.LessonId == lessonId).Select(exitSlip => new ExitSlipDTO
            {
                StudentId = exitSlip.StudentId,
                LessonId = exitSlip.LessonId,
                Questions = (List<QuestionFormDTO>)exitSlip.Questionnaire,
                IsDistributed = exitSlip.IsDistributed,
                TeacherId = exitSlip.TeacherId,
                TeacherComment = exitSlip.TeacherComment,
                RowVersion = exitSlip.RowVersion,
            }).ToListAsync();
            return await result;
        }

        async Task<List<ExitSlipDTO>> IExitSlipQuery.GetAllByTeacherId(Guid teacherId)
        {
            var result = db.ExitSlips.Where(e => e.TeacherId == teacherId).Select(exitSlip => new ExitSlipDTO
            {
                StudentId = exitSlip.StudentId,
                LessonId = exitSlip.LessonId,
                Questions = (List<QuestionFormDTO>)exitSlip.Questionnaire,
                IsDistributed = exitSlip.IsDistributed,
                TeacherId = exitSlip.TeacherId,
                TeacherComment = exitSlip.TeacherComment,
                RowVersion = exitSlip.RowVersion,
            }).ToListAsync();
            return await result;
        }

        //for internal use only, so no need to return a DTO here, for ease of use and all that.
        async Task<ExitSlipPost> IExitSlipQuery.GetOneById(Guid exitSlipId)
        {
            var result = db.ExitSlips.AsNoTracking().SingleAsync(e => e.Id == exitSlipId);
            return await result;
        }
    }
}
