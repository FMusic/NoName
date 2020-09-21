using System.Collections.Generic;

namespace Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceId { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
