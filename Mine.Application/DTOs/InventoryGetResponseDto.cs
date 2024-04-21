using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine.Application.DTOs
{
    public class InventoryGetResponseDto
    {
        public List<Tool> tools { get; set; }
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string count { get; set; }
    }

    public class Tool
    {
        public string id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string health { get; set; }
        public int hits { get; set; }
    }
}
