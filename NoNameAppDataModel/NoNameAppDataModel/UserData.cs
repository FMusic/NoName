using Newtonsoft.Json;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class UserData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("userEnum")]
        public int UserEnum { get; set; }

        [JsonProperty("placeId")]
        public int? PlaceId { get; set; }

        //---------------------------------------------------

        [JsonProperty("usr")]
        public string Usr { get; set; }

        [JsonProperty("pwd")]
        public string Pwd { get; set; }
    }
}
