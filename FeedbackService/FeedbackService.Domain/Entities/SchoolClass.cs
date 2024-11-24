using FeedbackService.Domain.Entities;

public class SchoolClass
{
    private readonly List<Lesson> _lessons;
    private readonly List<Student> _students;
    private readonly List<Room> _rooms;

    public SchoolClass(int term)
    {
        Term = term;
        _lessons = new List<Lesson>();
        _students = new List<Student>();
        _rooms = new List<Room>();
    }

    public int Term { get; set; }
    public IReadOnlyCollection<Lesson> Lessons => _lessons;
    public IReadOnlyCollection<Student> Students => _students;
    public IReadOnlyCollection<Room> Rooms => _rooms;

    public static SchoolClass Create(int term)
    {
        return new SchoolClass(term);
    }

    public void AddLesson(Lesson lesson)
    {
        _lessons.Add(lesson);
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
    }
}