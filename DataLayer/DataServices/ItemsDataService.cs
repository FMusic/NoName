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
    public class ItemsDataService : DataService
    {
        public async Task<List<Item>> GetItemsForCategoryIdAsync(int categoryId)
        {
            using (var db = CreateDbContext())
            {
                return await Task.Run(() => db.Items.Where(x => x.CategoryId == categoryId).OrderBy(x => x.Id).ToList());
            }
        }
    }
}
