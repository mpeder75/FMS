using System.ComponentModel.DataAnnotations;

namespace FeedbackService.Domain;

public abstract class DomainEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    [Timestamp]
    public byte[] RowVersion { get; protected set; } = null!;
}
