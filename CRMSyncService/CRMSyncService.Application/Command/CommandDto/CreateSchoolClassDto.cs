using DummyDb.Application.Dto;

namespace DummyDb.Application.Command.CommandDto
{
    public class CreateSchoolClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Term { get; set; }
        public List<StudentDto> StudentsDtos { get; set; }
    }


}
