namespace FeedbackService.Domain.Entities;

public class Lesson
{
    public DateTime Date { get; protected set; }
    private readonly Course _course;
    public Course Course => _course;

    private Lesson(DateTime date, Course course)
    {
        Date = date;
        _course = course;
    }

    public static Lesson Create(DateTime date, Course course)
    {
        return new Lesson(date, course);
    }
}