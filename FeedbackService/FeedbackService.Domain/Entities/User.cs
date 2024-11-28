using FeedbackService.Domain;

public class User : DomainEntity
{
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; protected set; }

    protected User() { }

    protected User(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public static User Create(string firstName, string lastName, string email)
    {
        return new User(firstName, lastName, email);
    }
}