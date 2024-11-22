using DummyDb.Application.Dto;
using DummyDb.Application.IQueries;
using Microsoft.EntityFrameworkCore;

namespace DummyDb.Infrastructure.Queries
{
    public class SchoolClassQuery : ISchoolClassQuery
    {
        private readonly CRMContext _db;

        public SchoolClassQuery(CRMContext db)
        {
            _db = db;
        }

        SchoolClassDto ISchoolClassQuery.GetSchoolClassById(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<SchoolClassDto> ISchoolClassQuery.GetSchoolClasses()
        {
            var result = _db.SchoolClasses
                .AsNoTracking()
                .Include(c => c.Students)
                .Select(c => new SchoolClassDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Term = c.Term,
                    Students = c.Students.Select(s => new StudentDto
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Email = s.Email
                    }).ToList()
                });

            return result.ToList();
        }
    }
}
