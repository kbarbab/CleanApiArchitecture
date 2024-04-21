namespace Mine.Domain.Entities.XMine
{
    public class XPerkEntity
    {
        public Guid Id { get; set; }
        public Guid MinerId { get; set; }
        public int Perk { get; set; }
        public DateTime Expire { get; set; }
    }
}
