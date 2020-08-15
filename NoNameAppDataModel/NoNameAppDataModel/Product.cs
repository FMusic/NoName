using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class Product
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("availableQuantity")]
        public int AvailableQuantity { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
    }
}
