using System.ComponentModel.DataAnnotations;

namespace ExitslipService.Domain;

public class DomainEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    [Timestamp]
    public byte[] RowVersion { get; protected set; } = null!;
}
