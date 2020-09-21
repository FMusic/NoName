using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class BillContent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        public Product CorrespondingProduct { get; set; }
    }
}
