using FakeSmtpServer.FakeContacts;

namespace FakeSmtpServer.FakeMalingList;

public class FakeMalingList
{
    private readonly List<FakeTeacher> _mailContacts;

    public FakeMalingList()
    {
        _mailContacts = new List<FakeTeacher>
        {
            new(
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                "Poul",
                "Hansen",
                "poul.hansen@example.com"
            ),
            new(
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                "Birthe",
                "Andersen",
                "birte.andersen@privatmail.dk"
            ),
            new(
                Guid.Parse("33333333-3333-3333-3333-333333333333"),
                "Jane",
                "Smith",
                "jane.smith@example.com"
            ),
            new(
                Guid.Parse("44444444-4444-4444-4444-444444444444"),
                "Lars",
                "Jensen",
                "lars.jensen@example.com"
            ),
            new(
                Guid.Parse("55555555-5555-5555-5555-555555555555"),
                "Mette",
                "Nielsen",
                "mette.nielsen@example.com"
            ),
            new(
                Guid.Parse("66666666-6666-6666-6666-666666666666"),
                "Søren",
                "Thomsen",
                "soren.thomsen@example.com"
            )
        };
    }

    public List<FakeTeacher> GetTeachersByRoomId(Guid roomId)
    {
        return _mailContacts.Where(t => t.RoomId == roomId).ToList();
    }
}