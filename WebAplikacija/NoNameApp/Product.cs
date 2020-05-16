namespace NoNameApp
{
    [System.Serializable]
    public class Product
    {
        public string Name { get; private set; }
        public int Quantity { get; set; }

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}