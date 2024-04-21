namespace Mine.Application.DTOs
{
    public class GetMinersResponseDto
    {
        public List<Miner> miners { get; set; }
    }

    public class Miner
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string strength { get; set; }
        public string stamina { get; set; }
        public string speed { get; set; }
        public int cost { get; set; }
    }
}
