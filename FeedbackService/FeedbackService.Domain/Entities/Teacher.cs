namespace FeedbackService.Domain.Entities;

public class Teacher : DomainEntity
{
    public string FirstName { get; protected set; } = null!;
    public string LastName { get; protected set; } = null!;
    public string Email { get; set; }
    private readonly List<Course> _classes;
    public IReadOnlyCollection<Course> Classes => _classes;

    protected Teacher() { }

    private Teacher(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }


    public static Teacher Create(string firstName, string lastName, string email)
    {
        return new Teacher(firstName, lastName, email);
    }
}