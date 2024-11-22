namespace FeedbackService.Domain.Entities;

public class Lesson
{
    public DateTime Date { get; protected set; }
    private readonly SchoolClass _course;
    public SchoolClass Course => _course;

    private Lesson(DateTime date, SchoolClass course)
    {
        Date = date;
        _course = course;
    }

    public static Lesson Create(DateTime date, SchoolClass course)
    {
        return new Lesson(date, course);
    }
}