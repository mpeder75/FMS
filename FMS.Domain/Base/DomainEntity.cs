using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Base
{
    public abstract class DomainEntity
    {
        public int Id { get; protected set; }
        [Timestamp]
        public byte[] RowVersion { get; protected set; } = null!;
    }
}
