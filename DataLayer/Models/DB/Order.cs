using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DB
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string TableNumber { get; set; }
        public double TotalPrice { get; set; }
        public bool Charged { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual Place Place { get; set; }
        public int PlaceId { get; set; }
    }
}
