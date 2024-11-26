using ExitslipService.Domain.Entities;
using ExitslipService.Application.Query;
using Microsoft.EntityFrameworkCore;
using ExitslipService.Application.Query.ExitSlipDto;

namespace ExitSlipService.Infrastructure.Queries
{
    public class ExitSlipQuery(ExitSlipContext db) : IExitSlipQuery
    {
        IEnumerable<ExitSlipDTO> IExitSlipQuery.GetAllByStudentId(Guid studentId)
        {
            var result = db.ExitSlips.Where(e => e.StudentId == studentId).Select(exitSlip => new ExitSlipDTO
            {
                StudentId = exitSlip.StudentId,
                LessonId = exitSlip.LessonId,
                Questions = (List<QuestionForm>)exitSlip.Questions,
                IsDistributed = exitSlip.IsDistributed,
                Teacher = exitSlip.Teacher,
                TeacherComment = exitSlip.TeacherComment,
                RowVersion = exitSlip.RowVersion,
            });
            return result;
        }

        IEnumerable<ExitSlipDTO> IExitSlipQuery.GetAllByLessonId(Guid lessonId)
        {
            var result = db.ExitSlips.Where(e => e.LessonId == lessonId).Select(exitSlip => new ExitSlipDTO
            {
                StudentId = exitSlip.StudentId,
                LessonId = exitSlip.LessonId,
                Questions = (List<QuestionForm>)exitSlip.Questions,
                IsDistributed = exitSlip.IsDistributed,
                Teacher = exitSlip.Teacher,
                TeacherComment = exitSlip.TeacherComment,
                RowVersion = exitSlip.RowVersion,
            });
            return result;
        }

        IEnumerable<ExitSlipDTO> IExitSlipQuery.GetAllByTeacherId(Guid teacherId)
        {
            var result = db.ExitSlips.Where(e => e.Teacher.Id == teacherId).Select(exitSlip => new ExitSlipDTO
            {
                StudentId = exitSlip.StudentId,
                LessonId = exitSlip.LessonId,
                Questions = (List<QuestionForm>)exitSlip.Questions,
                IsDistributed = exitSlip.IsDistributed,
                Teacher = exitSlip.Teacher,
                TeacherComment = exitSlip.TeacherComment,
                RowVersion = exitSlip.RowVersion,
            });
            return result;
        }

        //for internal use only, so no need to return a DTO here, for ease of use and all that.
        ExitSlip IExitSlipQuery.GetOneById(Guid exitSlipId)
        {
            var result = db.ExitSlips.AsNoTracking().Single(e => e.Id == exitSlipId);
            return result;
        }
    }
}
