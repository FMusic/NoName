using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DB
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserEnum UserEnum { get; set; }

        [JsonIgnore]
        public virtual Place Place { get; set; }
        public int? PlaceId { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Order> Orders { get; set; }
    }
}
