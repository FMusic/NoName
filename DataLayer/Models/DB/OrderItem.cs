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
        public double Quantity { get; set; }
        public double Price { get; set; }

        [JsonIgnore]
        public virtual Item Item { get; set; }
        public int? ItemId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
