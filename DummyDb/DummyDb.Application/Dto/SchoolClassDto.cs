namespace DummyDb.Application.Dto
{
    public class SchoolClassDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Term { get; set; }
        public List<StudentDto> Students { get; set; }
        public List<Guid> LessonIds { get; set; }
    }
}
