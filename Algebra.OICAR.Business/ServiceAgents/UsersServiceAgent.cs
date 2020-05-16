using Algebra.OICAR.Types.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.OICAR.Business.ServiceAgents
{
    public class UsersServiceAgent
    {
        public static UserList GetUsers()
        {
            UserList output = new UserList();

            output.Add(new User()
            {
                ID = 1,
                Name = "Andrej",
                Surname = "Begović",
                Role = new UserRole() { RoleName = "Voditelj" }
            });
            output.Add(new User()
            {
                ID = 2,
                Name = "Dario",
                Surname = "Pudić",
                Role = new UserRole() { RoleName = "Konobar" }
            }); 
            output.Add(new User()
            {
                ID = 3,
                Name = "Milan",
                Surname = "Šikić",
                Role = new UserRole() { RoleName = "Kupac" }
            }); 
            output.Add(new User()
            {
                ID = 4,
                Name = "Frane",
                Surname = "Mušić",
                Role = new UserRole() { RoleName = "Admin" }
            });

            return output;
        }
    }
}
