using DummyDb.Application.Dto;

namespace DummyDb.Application.IQueries
{
    public interface ISchoolClassQuery
    {
        IEnumerable<SchoolClassDto> GetSchoolClasses();
        SchoolClassDto GetSchoolClassById(Guid id);
    }
}
