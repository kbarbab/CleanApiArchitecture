namespace Mine.Application.DTOs
{
    public class Bank
    {
        public string id { get; set; }
        public int location { get; set; }
    }

    public class PositionInfoDto
    {
        public List<Player> players { get; set; }
        public List<Rock> rocks { get; set; }
        public List<Bank> banks { get; set; }

    }

    public class Player
    {
        public string username { get; set; }
        public int location { get; set; }
        public int destination { get; set; }
        public double speed { get; set; }
    }

    public class Rock
    {
        public string id { get; set; }
        public int type { get; set; }
        public int location { get; set; }
    }
}
