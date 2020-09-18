using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class UserData
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("userType")]
        public UserType userType { get; set; }
    }
}
