using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DB
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Item> Items { get; set; }

        [JsonIgnore]
        public virtual Place Place { get; set; }
        public int PlaceId { get; set; }
    }
}
