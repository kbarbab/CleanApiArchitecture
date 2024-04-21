namespace Mine.Application.DTOs
{
    public class Buf
    {
        public string type { get; set; }
        public int size { get; set; }
        public int Expire { get; set; }
    }

    public class XMineInfoDto
    {
        public string id { get; set; }
        public object toolId { get; set; }
        public int type { get; set; }
        public int coins { get; set; }
        public int stamina { get; set; }
        public int speed { get; set; }
        public int strength { get; set; }
        public int maxStamina { get; set; }
        public int level { get; set; }
        public int xp { get; set; }
        public int position { get; set; }
        public List<Buf> bufs { get; set; }
    }
}
