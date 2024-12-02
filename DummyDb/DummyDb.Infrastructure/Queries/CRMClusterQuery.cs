using DummyDb.Application.Dto;
using DummyDb.Application.IQueries;
using Microsoft.EntityFrameworkCore;

namespace DummyDb.Infrastructure.Queries
{
    public class CRMClusterQuery : ICRMClusterQuery
    {
        private readonly CRMContext _db;

        public CRMClusterQuery(CRMContext db)
        {
            _db = db;
        }

        IEnumerable<RoomDto> ICRMClusterQuery.GetCluster()
        {
            var rooms = _db.Rooms.AsNoTracking()
            .Include(r => r.Lessons)
                .ThenInclude(l => l.Teacher)
            .Include(r => r.SchoolClasses)
                .ThenInclude(sc => sc.Students)
            .Select(r => new RoomDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Lessons = r.Lessons.Select(l => new LessonDto
                {
                    Id = l.Id,
                    Date = l.Date,
                    SchoolClassId = l.SchoolClass.Id,
                    Teacher = new TeacherDto
                    {
                        Id = l.Teacher.Id,
                        FirstName = l.Teacher.FirstName,
                        LastName = l.Teacher.LastName,
                        Email = l.Teacher.Email
                    }
                }).ToList(),
                SchoolClasses = r.SchoolClasses.Select(sc => new SchoolClassDto
                {
                    Id = sc.Id,
                    Name= sc.Name,
                    Term = sc.Term,
                    LessonIds = sc.Lessons.Select(ls => ls.Id).ToList(),
                    Students =  sc.Students.Select(s => new StudentDto
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Email= s.Email
                    }).ToList()
                }).ToList()
            }).ToList();

            return rooms;
        }
    }
}
