namespace FeedbackService.Domain.Entities;

public class Lesson
{
    public DateTime Date { get; protected set; }
    private readonly SchoolClass _schoolClass;
    public SchoolClass SchoolClass => _schoolClass;

    private Lesson(DateTime date, SchoolClass schoolClass)
    {
        Date = date;
        _schoolClass = schoolClass;
    }

    public static Lesson Create(DateTime date, SchoolClass schoolClass)
    {
        return new Lesson(date, schoolClass);
    }
}