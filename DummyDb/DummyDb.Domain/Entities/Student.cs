namespace DummyDb.Domain.Entities;

public class Student : User
{

    private Student(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    // ------------------------------------------ Properties -------------------------------------------------------------
    public SchoolClass? SchoolClass { get; protected set; }

    // ------------------------------------------- Validation ------------------------------------------------------------


    // ----------------------------------------- Factory Method ----------------------------------------------------------

    public static Student Create(string firstName, string lastName, string email)
    {
        return new Student(firstName, lastName, email);
    }
}