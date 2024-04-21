using Mine.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Mine.Domain.Entities.XMine
{
    public class XToolEntity
    {
        public Guid Id { get; set; }
        public Guid MinerId { get; set; }
        public XToolType Type { get; set; }
        public int Health { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
