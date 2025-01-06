namespace FakeSmtpServer.Dto
{
    public record EmailDto
    {
        public string ToAddress { get; init; }
        public string Message { get; init; }
    }
}
