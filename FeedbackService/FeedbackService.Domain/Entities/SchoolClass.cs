namespace FeedbackService.Domain.Entities;

public class SchoolClass
{
    private readonly List<Lesson> _lessons;

    public Teacher Teacher { get; protected set; }
    public int Term { get; protected set; }

    public IReadOnlyCollection<Lesson> Lessons => _lessons;

    private SchoolClass(int term, Teacher teacher)
    {
        Term = term;
        Teacher = teacher;
        _lessons = new List<Lesson>();
    }

    public static SchoolClass Create(int term, Teacher teacher)
    {
        return new SchoolClass(term, teacher);
    }

    public void AddLesson(Lesson lesson)
    {
        _lessons.Add(lesson);
    }
}