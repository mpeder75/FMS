namespace FakeSmtpServer.Dto
{
    public record Teacher
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
    }
}
