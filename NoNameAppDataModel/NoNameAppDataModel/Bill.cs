using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace NoNameAppDataModel
{
    [System.Serializable]
    public class Bill
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("totalPrice")]
        public float TotalPrice { get; set; }

        [JsonProperty("contents")]
        public List<BillContent> Contents { get; set; }

        [JsonProperty("statuses")]
        public List<BillStatus> Statuses { get; set; }

        public BillStatus LastStatus
        {
            get
            {
                if (Statuses == null)
                {
                    return null;
                }

                return Statuses.OrderByDescending(s => s.StatusTimestamp).FirstOrDefault();
            }
        }
    }
}
