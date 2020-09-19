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
    public class CategoriesDataService : DataService
    {
        public async Task<List<Category>> GetCategoriesForPlaceIdAsync(int placeId)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.Categories.Where(x => x.PlaceId == placeId).OrderBy(x => x.Name).ToList());
            }
        }
    }
}
