using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class BillContent
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("productPrice")]
        public float ProductPrice { get; set; }

        [JsonProperty("productQuantity")]
        public int ProductQuantity { get; set; }

        [JsonProperty("correspondingProduct")]
        public Product CorrespondingProduct { get; set; }

        [JsonProperty("billId")]
        public int? BillId { get; set; }
    }
}
