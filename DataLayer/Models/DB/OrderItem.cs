using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DB
{
    [Table("OrderItem")]
    public class OrderItem
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string TableNumber { get; set; }
        public double Quantity { get; set; }
        public double TotalPrice { get; set; }
        public bool Charged { get; set; }

        [JsonIgnore]
        public virtual Item Item { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
