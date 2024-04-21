using System.ComponentModel.DataAnnotations;

namespace Mine.Domain.Entities.XMine
{
    public class XRockEntity
    {
        public Guid Id { get; set; }
        public int Coins { get; set; }
        public int Item { get; set; }
        public int Tool { get; set; }
        public int Position { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
