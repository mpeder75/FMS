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
        async Task<List<ExitSlipReplyDTO>> IExitSlipQuery.GetAllByStudentId(Guid studentId)
        {
            var result = db.ExitSlipReplies.Where(e => e.StudentId == studentId).Include(e => e.Questionnaire).Select(exitSlip => new ExitSlipReplyDTO
            {
                PostId = exitSlip.PostId,
                StudentId = exitSlip.StudentId,
                LessonId = exitSlip.LessonId,
                Questions = exitSlip.Questionnaire,
                TeacherComment = exitSlip.Comment,
                RowVersion = exitSlip.RowVersion,
            }).ToListAsync();
            return await result;
        }

        async Task<List<ExitSlipReplyDTO>> IExitSlipQuery.GetAllByLessonId(Guid lessonId)
        {
            var result = db.ExitSlipReplies.Where(e => e.LessonId == lessonId).Include(e => e.Questionnaire).Select(exitSlip => new ExitSlipReplyDTO
            {
                PostId = exitSlip.PostId,
                StudentId = exitSlip.StudentId,
                LessonId = exitSlip.LessonId,
                Questions = exitSlip.Questionnaire,
                TeacherComment = exitSlip.Comment,
                RowVersion = exitSlip.RowVersion,
            }).ToListAsync();
            return await result;
        }



        //for internal use only, so no need to return a DTO here, for ease of use and all that.
        async Task<ExitSlipPost> IExitSlipQuery.GetOneById(Guid exitSlipId)
        {
            var result = db.ExitSlipPosts.AsNoTracking().SingleAsync(e => e.Id == exitSlipId);
            return await result;
        }
    }
}
