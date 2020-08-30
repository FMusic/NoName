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

        [JsonProperty("contents")]
        public List<BillContent> Contents { get; set; }

        [JsonProperty("statuses")]
        public List<BillStatus> Statuses { get; set; }

        public float TotalPrice
        {
            get
            {
                if (Contents == null || Contents.Count == 0)
                {
                    return 0.0f;
                }

                return Contents.Sum(c => c.ProductPrice * c.ProductQuantity);
            }
        }

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
