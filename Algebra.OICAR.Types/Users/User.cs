using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.OICAR.Types.Users
{
    public class User : IComparable<User>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public UserRole Role { get; set; }

        public int CompareTo(User other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{ Name } { Surname } - { Role.RoleName }";
        }
    }
}
