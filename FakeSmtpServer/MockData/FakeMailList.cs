using FakeSmtpServer.Dto;
using FakeSmtpServer.Interfaces;

namespace FakeSmtpServer.MockData;

public class FakeMailList : IMailList
{
    public IEnumerable<Teacher> GetTeachersByRoomId(Guid roomId)
    {
        // Mock data
        return new List<Teacher>
            {
                new Teacher { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Teacher { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
            };
    }
}