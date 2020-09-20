using DataLayer.DAO;
using DataLayer.Models;
using DataLayer.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataServices
{
    public class RevenueDataService : DataService
    {
        public async Task<Revenue> GetRevenueForPlaceIdAndDateAsync(int placeId, DateTime date)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() =>
                {
                    var orders = db.Orders.Where(x => x.PlaceId == placeId && x.DateTime.Year == date.Year && x.DateTime.Month == date.Month && x.DateTime.Day == date.Day).ToList();
                    return new Revenue
                    {
                        Date = date,
                        TotalRevenue = orders.Any() ? orders.Sum(x => x.TotalPrice) : 0
                    };
                });
            }
        }

        public async Task<List<Revenue>> GetRevenueForPlaceIdAndMonthAsync(int placeId, DateTime month)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() =>
                {
                    var revenues = new List<Revenue>();
                    for (DateTime date = month; date <= month.AddMonths(1).AddDays(-1); date = date.AddDays(1))
                    {
                        var orders = db.Orders.Where(x => x.PlaceId == placeId && x.DateTime.Year == date.Year && x.DateTime.Month == date.Month && x.DateTime.Day == date.Day).ToList();
                        revenues.Add(new Revenue
                        {
                            Date = date,
                            TotalRevenue = orders.Any() ? orders.Sum(x => x.TotalPrice) : 0
                        });
                    }
                    return revenues;
                });
            }
        }
    }
}
