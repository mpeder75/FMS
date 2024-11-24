namespace FeedbackService.Domain.Entities;

public class Lesson
{
    public DateTime Date { get; protected set; }
    private readonly SchoolClass _schoolClass;
    private readonly Room _room;
    private readonly Teacher _teacher;

    public SchoolClass SchoolClass => _schoolClass;
    public Room Room => _room;
    public Teacher Teacher => _teacher;

    private Lesson(DateTime date, SchoolClass schoolClass, Room room, Teacher teacher)
    {
        Date = date;
        _schoolClass = schoolClass;
        _room = room;
        _teacher = teacher;
    }

    public static Lesson Create(DateTime date, SchoolClass schoolClass, Room room, Teacher teacher)
    {
        return new Lesson(date, schoolClass, room, teacher);
    }
}