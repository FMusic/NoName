using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class FileData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fileTimestamp")]
        public string FileTimestamp { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
