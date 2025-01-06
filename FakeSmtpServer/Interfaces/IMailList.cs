using FakeSmtpServer.Dto;

namespace FakeSmtpServer.Interfaces
{
    public interface IMailList
    {
        IEnumerable<Teacher> GetTeachersByRoomId(Guid roomId);
    }
}
