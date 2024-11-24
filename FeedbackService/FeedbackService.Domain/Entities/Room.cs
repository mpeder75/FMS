using FeedbackService.Domain.Entities;

public class Room
{
    private readonly List<Lesson> _lessons;
    private readonly List<Feedbackpost> _feedbackposts;
    private readonly List<SchoolClass> _schoolClasses;

    public Room()
    {
        _lessons = new List<Lesson>();
        _feedbackposts = new List<Feedbackpost>();
        _schoolClasses = new List<SchoolClass>();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public IReadOnlyCollection<Lesson> Lessons => _lessons;
    public IReadOnlyCollection<Feedbackpost> Feedbackposts => _feedbackposts;
    public IReadOnlyCollection<SchoolClass> SchoolClasses => _schoolClasses;

    public static Room Create(string name, string description)
    {
        return new Room
        {
            Name = name,
            Description = description
        };
    }

    public void AddLesson(Lesson lesson)
    {
        _lessons.Add(lesson);
    }

    public void AddFeedbackpost(Feedbackpost feedbackpost)
    {
        _feedbackposts.Add(feedbackpost);
    }

    public void AddSchoolClass(SchoolClass schoolClass)
    {
        _schoolClasses.Add(schoolClass);
    }
}