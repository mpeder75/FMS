using CRMSyncService.Application.IQueries.Dto;


namespace CRMSyncService.Application.IQueries
{
    public interface ISchoolClassQuery
    {
        IEnumerable<SchoolClassDto> GetSchoolClasses();
        SchoolClassDto GetSchoolClassById(Guid id);
    }
}
