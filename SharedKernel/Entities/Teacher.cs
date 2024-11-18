namespace SharedKernel.Entities;

public class Teacher : User
{
    // protected Teacher() { }

    private Teacher(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    // ------------------------------------------ Properties -------------------------------------------------------------


    // ------------------------------------------- Validation ------------------------------------------------------------


    // ----------------------------------------- Factory Method ----------------------------------------------------------

    public static Teacher Create(string firstName, string lastName, string email)
    {
        return new Teacher(firstName, lastName, email);
    }
}