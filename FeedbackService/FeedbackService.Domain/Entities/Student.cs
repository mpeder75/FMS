namespace FeedbackService.Domain.Entities;

public class Student : DomainEntity
{
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; protected set; }
    public SchoolClass SchoolClass { get; protected set; }
    
    protected Student() { }

    private Student(string firstName, string lastName, string email, SchoolClass schoolClass)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        SchoolClass = schoolClass;
    }
    
    public static Student Create(string firstName, string lastName, string email, SchoolClass schoolClass)
    {
        return new Student(firstName, lastName, email, schoolClass);
    }
}