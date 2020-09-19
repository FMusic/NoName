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
    public class OrderItemsDataService : DataService
    {
        public async Task<List<OrderItem>> GetOrderItemsForOrderIdAsync(int orderId)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.OrderItems.Where(x => x.OrderId == orderId).OrderBy(x => x.Id).ToList());
            }
        }
    }
}
