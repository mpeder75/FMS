namespace FeedbackService.Domain.Entities;

public class SchoolClass
{
    private readonly List<Lesson> _lessons;
    private readonly List<Room> _rooms;
    private readonly List<Student> _students;

    private readonly Teacher Teacher;


    public int Term { get; set; }
    public IReadOnlyCollection<Lesson> Lessons => _lessons;
    public IReadOnlyCollection<Student> Students => _students;
    public IReadOnlyCollection<Room> Rooms => _rooms;

    private SchoolClass(int term, Teacher teacher)
    {
        Term = term;
        Teacher = teacher;
        _lessons = new List<Lesson>();
        _students = new List<Student>();
        _rooms = new List<Room>();
    }


    public static SchoolClass Create(int term, Teacher teacher)
    {
        return new SchoolClass(term, teacher);
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