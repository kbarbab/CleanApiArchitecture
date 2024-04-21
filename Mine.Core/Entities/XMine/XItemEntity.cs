using Mine.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Mine.Domain.Entities.XMine
{
    public class XItemEntity
    {
        public Guid Id { get; set; }
        public Guid MinerId { get; set; }
        public XItemType Type { get; set; }
        public int Count { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
