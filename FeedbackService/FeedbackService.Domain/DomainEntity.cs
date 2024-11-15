using System.ComponentModel.DataAnnotations;

namespace FeedbackService.Domain;

public class DomainEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    [Timestamp]
    public byte[] RowVersion { get; protected set; } = null!;

}
