
namespace SharedKernel.Entities;

public class Student : User
{
    // protected Student() { }

    private Student(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    // ------------------------------------------ Properties -------------------------------------------------------------


    // ------------------------------------------- Validation ------------------------------------------------------------


    // ----------------------------------------- Factory Method ----------------------------------------------------------

    public static Student Create(string firstName, string lastName, string email)
    {
        return new Student(firstName,lastName,email);
    }
}