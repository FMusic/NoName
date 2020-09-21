using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class BillStatus
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("statusTimestamp")]
        public string StatusTimestamp { get; set; }

        [JsonProperty("billId")]
        public int? BillId { get; set; }
    }
}
