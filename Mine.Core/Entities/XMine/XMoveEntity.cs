using System.ComponentModel.DataAnnotations;

namespace Mine.Domain.Entities.XMine
{
    public class XMoveEntity
    {
        public Guid Id { get; set; }
        public Guid MinerId { get; set; }
        public int Start { get; set; }
        public int Destination { get; set; }
        public double Speed { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
