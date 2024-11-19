using CRMSyncService.Application.IQueries;
using CRMSyncService.Application.IQueries.Dto;

namespace CRMSyncService.Infrastructure.Queries
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
            throw new NotImplementedException();
        }
    }
}
