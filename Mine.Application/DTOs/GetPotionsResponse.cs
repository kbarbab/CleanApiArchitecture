
namespace Mine.Application.DTOs
{
    public class GetPotionsResponse
    {
        public List<Potion> potions { get; set; }
    }

    public class Potion
    {
        public string id { get; set; }
        public string name { get; set; }
        public string expire { get; set; }
        public int cost { get; set; }
    }
}
