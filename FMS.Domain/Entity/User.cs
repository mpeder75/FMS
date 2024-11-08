using FMS.Domain.Base;

namespace FMS.Domain.Entity
{
    public class User : DomainEntity
    {
        private User(string firstname, string lastname, string email) 
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
        public static User Create(string firstname, string lastname, string email)
        {
            return new User(firstname,lastname,email);
        }
    }
}
