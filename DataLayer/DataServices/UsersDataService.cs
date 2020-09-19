using DataLayer.Models;
using DataLayer.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataServices
{
    public class UsersDataService : DataService
    {
        public async Task<User> GetUserForLoginDetailsAsync(string usr, string pwd)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.Users.Where(x => x.Email == usr && x.Password == pwd).SingleOrDefault());
            }
        }

        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.Users.Any(x => x.Username == username));
            }
        }
    }
}
