namespace FeedbackService.Domain.Entities;

public class Course
{
    private readonly List<Lesson> _lessons;

    private readonly Teacher teacher;
    public int Term { get; protected set; }

    public IReadOnlyCollection<Lesson> Lessons => _lessons;

    private Course(int term, Teacher teacher)
    {
        Term = term;
        this.teacher = teacher;
        _lessons = new List<Lesson>();
    }

    public static Course Create(int term, Teacher teacher)
    {
        return new Course(term, teacher);
    }

    public void AddLesson(Lesson lesson)
    {
        _lessons.Add(lesson);
    }
}