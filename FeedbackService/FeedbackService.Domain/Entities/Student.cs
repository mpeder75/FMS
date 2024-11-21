namespace FeedbackService.Domain.Entities;

public class Student : DomainEntity
{
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; protected set; }
    
    protected Student() { }

    private Student(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
    
    public static Student Create(string firstName, string lastName, string email)
    {
        return new Student(firstName, lastName, email);
    }
}