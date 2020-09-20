using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DB
{
    [Table("Place")]
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public virtual User Owner { get; set; }
        public int? OwnerId { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Category> Categories { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Order> Orders { get; set; }
    }
}
