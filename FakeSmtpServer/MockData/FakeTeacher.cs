namespace FakeSmtpServer.FakeContacts
{
    public class FakeTeacher
    {
        public Guid RoomId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }

        public FakeTeacher(Guid roomId, string firstName, string lastName, string email)
        {
            RoomId = roomId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
