namespace DummyDb.Domain.Entities;

public class Teacher : User
{

    private Teacher(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    // ------------------------------------------ Properties -------------------------------------------------------------
    public List<Lesson>? Lessons { get; protected set; }

    // ------------------------------------------- Validation ------------------------------------------------------------


    // ----------------------------------------- Factory Method ----------------------------------------------------------

    public static Teacher Create(string firstName, string lastName, string email)
    {
        return new Teacher(firstName, lastName, email);
    }
}