using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class Bill
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("tableNumber")]
        public string TableNumber { get; set; }

        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }

        [JsonProperty("charged")]
        public bool Charged { get; set; }

        [JsonProperty("userId")]
        public int? UserId { get; set; }

        [JsonProperty("placeId")]
        public int? PlaceId { get; set; }

        //public string Number { get; set; }

        public List<BillContent> Contents { get; set; }
    }
}
