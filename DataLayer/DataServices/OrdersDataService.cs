using DataLayer.DAO;
using DataLayer.Models;
using DataLayer.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataServices
{
    public class OrdersDataService : DataService
    {
        public async Task<List<Order>> GetOrdersForPlaceIdAsync(int placeId)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.Orders.Where(x => x.PlaceId == placeId).OrderBy(x => x.Id).ToList());
            }
        }

        public async Task<List<Order>> GetOrdersForUserIdAsync(int userId)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.Orders.Where(x => x.UserId == userId).OrderBy(x => x.Id).ToList());
            }
        }
    }
}
