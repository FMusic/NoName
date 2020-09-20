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
        public async Task<User> GetUserForLoginInfoAsync(LoginInfo loginInfo)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.Users.Where(x => x.Username == loginInfo.Usr && x.Password == loginInfo.Pwd).SingleOrDefault());
            }
        }

        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.Users.Any(x => x.Username == username));
            }
        }

        public async Task<List<User>> GetUsersForPlaceIdAndUserEnumAsync(int placeId, UserEnum userEnum)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.Users.Where(x => x.PlaceId == placeId && x.UserEnum == userEnum).OrderBy(x => x.Id).ToList());
            }
        }
    }
}
