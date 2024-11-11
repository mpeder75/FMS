using FMS.Domain.Base;

namespace FMS.Domain.Entity
{
    public class Student : DomainEntity
    {
        private Student(string firstname, string lastname, string email) 
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }

        // ------------------------------------------ Properties -------------------------------------------------------------
        public string Firstname { get; protected set; }
        public string Lastname { get; protected set; }
        public string Email { get; protected set; }



        // ----------------------------------------- Factory Method ---------------------------------------------------------
        public static Student Create(string firstname, string lastname, string email)
        {
            return new Student(firstname,lastname,email);
        }
    }
}
