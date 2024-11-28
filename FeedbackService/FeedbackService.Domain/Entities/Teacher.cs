namespace FeedbackService.Domain.Entities;

public class Teacher : DomainEntity
{
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; set; }
    private readonly List<SchoolClass> _classes;
    public IReadOnlyCollection<SchoolClass> Classes => _classes;

    protected Teacher() { }

    protected Teacher(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        _classes = new List<SchoolClass>();
    }

    public static Teacher Create(string firstName, string lastName, string email)
    {
        return new Teacher(firstName, lastName, email);
    }

    public void AddClass(SchoolClass schoolClass)
    {
        _classes.Add(schoolClass);
    }
}