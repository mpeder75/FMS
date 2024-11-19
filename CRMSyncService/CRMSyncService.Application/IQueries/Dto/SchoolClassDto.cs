
namespace CRMSyncService.Application.IQueries.Dto
{
    public class SchoolClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Term { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}
