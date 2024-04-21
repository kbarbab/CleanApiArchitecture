using Mine.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Mine.Domain.Entities.XMine
{
    public class XMinerEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? ToolId { get; set; }
        public XMinerType Type { get; set; }
        public int Coins { get; set; }
        public int Stamina { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int MaxStamina { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int Position { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
