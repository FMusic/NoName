using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class Category
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
