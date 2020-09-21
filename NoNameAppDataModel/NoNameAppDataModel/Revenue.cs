using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoNameAppDataModel
{
    public class Revenue
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("totalRevenue")]
        public double TotalRevenue { get; set; }
    }
}
