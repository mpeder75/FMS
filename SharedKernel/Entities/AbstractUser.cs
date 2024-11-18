

namespace SharedKernel.Entities
{
    public abstract class User
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
    }
}
