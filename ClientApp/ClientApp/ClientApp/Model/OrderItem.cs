namespace Model
{
    public class OrderItem
    {
            public int Id { get; set; }
            public double Quantity { get; set; }
            public double Price { get; set; }
            public int? ItemId { get; set; }
            public int OrderId { get; set; }
    }
}
