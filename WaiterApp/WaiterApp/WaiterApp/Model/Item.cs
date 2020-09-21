namespace Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }

    }
}
