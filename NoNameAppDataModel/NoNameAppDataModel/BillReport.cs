using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class BillReport
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("fileDataId")]
        public int FileDataId { get; set; }
    }
}
