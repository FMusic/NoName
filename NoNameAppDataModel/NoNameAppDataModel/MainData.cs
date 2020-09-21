using Newtonsoft.Json;
using System.Collections.Generic;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class MainData
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        public static UserData UserData { get; set; }

        public static int TableNumberCounter { get; set; }
    }
}
