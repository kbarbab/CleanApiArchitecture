namespace Mine.Application.DTOs
{
    public class GetToolsResponseDto
    {
        public List<Tools> tools { get; set; }
    }

    public class Tools
    {
        public string id { get; set; }
        public string name { get; set; }
        public string strength { get; set; }
        public int cost { get; set; }
        public int hits { get; set; }
    }
}
