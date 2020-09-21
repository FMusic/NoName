using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
    }
}
