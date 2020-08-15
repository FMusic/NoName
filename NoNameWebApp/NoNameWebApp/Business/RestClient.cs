using NoNameAppDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoNameWebApp.Business
{
    // TODO: Kod u svakoj od metoda treba zamijeniti pozivom odgovarajuce metode REST servisa.
    // Ne treba mijenjati potpise funkcija ni ostatak koda u aplikaciji.
    public class RestClient
    {
        // POST /login
        public static async Task<UserData> CheckLogin(UserData userData)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            UserData userDataFromDB = DummyData
                .userDataList
                .FirstOrDefault(ud =>
                    ud.UserName.Equals(userData.UserName) &&
                    ud.Password.Equals(userData.Password));

            return userDataFromDB;
        }

        // GET /main-data
        public static async Task<MainData> GetMainData()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            MainData mainData = new MainData
            {
                Categories = new List<Category>(DummyData.categories),
                Products = new List<Product>(DummyData.products)
            };

            return mainData;
        }

        // POST /bills
        public static async Task<bool> CreateBill(Bill bill)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            // Prvo treba izracunati novi ID.
            int? maxBillId = DummyData.bills.Max(b => b.Id);
            bill.Id = (maxBillId == null) ? 1 : (maxBillId.Value + 1);

            // Zatim treba odrediti novi broj racuna.
            string billNumberPrefix = string.Format(
                "{0:0000}-{1:00}-{2:00}",
                DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            string lastNumberAsString = DummyData
                .bills
                .Select(b => b.Number)
                .Where(n => n.StartsWith(billNumberPrefix))
                .OrderByDescending(n => n)
                .FirstOrDefault();

            int nextNumber = (lastNumberAsString == null) ? 1 : Convert.ToInt32(lastNumberAsString.Split('-')[3]) + 1;
            bill.Number = string.Format("{0}-{1:0000}", billNumberPrefix, nextNumber);

            // Spremimo racun u listu racuna.
            DummyData.bills.Add(bill);

            // Spremimo svaku sastavnicu racuna u listu sastavnica.
            foreach (BillContent content in bill.Contents)
            {
                int? maxBillContentId = DummyData.billContents.Max(bc => bc.Id);
                content.Id = (maxBillContentId == null) ? 1 : (maxBillContentId.Value + 1);
                content.BillId = bill.Id;
                DummyData.billContents.Add(content);
            }

            // Spremimo svaki status listu statusa.
            foreach (BillStatus status in bill.Statuses)
            {
                int? maxBillStatusId = DummyData.billStatuses.Max(bs => bs.Id);
                status.Id = (maxBillStatusId == null) ? 1 : (maxBillStatusId.Value + 1);
                status.BillId = bill.Id;
                status.StatusTimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DummyData.billStatuses.Add(status);
            }

            return true;
        }

        // GET /bills
        public static async Task<List<Bill>> GetBills()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            return new List<Bill>(DummyData.bills);
        }

        // DELETE /bills/{id}
        public static async Task<bool> DeleteBill(int id)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            // Prvo obrisemo sve contente koji se odnose na racun s tim ID-em.
            DummyData.billContents.RemoveAll(bc => bc.BillId == id);

            // Zatim obrisemo sve statuse koji se odnose na racun s tim ID-em.
            DummyData.billStatuses.RemoveAll(bs => bs.BillId == id);

            // Na kraju obrisemo i sam racun.
            DummyData.bills.RemoveAll(b => b.Id == id);

            return true;
        }

        // PUT /bills
        public static async Task<bool> UpdateBill(Bill bill)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            Bill billFromDB = DummyData
                .bills
                .SingleOrDefault(b => b.Id == bill.Id);

            if (billFromDB == null)
            {
                return false;
            }

            // Trazimo status koji nema ID i ubacimo ga u bazu.
            BillStatus status = bill.Statuses.FirstOrDefault(s => !s.Id.HasValue);

            if (status == null)
            {
                return false;
            }


            int? maxBillStatusId = DummyData.billStatuses.Max(bs => bs.Id);
            status.Id = (maxBillStatusId == null) ? 1 : (maxBillStatusId.Value + 1);
            status.BillId = bill.Id;
            status.StatusTimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            billFromDB.Statuses.Add(status);
            DummyData.billStatuses.Add(status);

            return true;
        }

        // GET /bill-reports
        public static async Task<List<BillReport>> GetBillReports()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            return new List<BillReport>(DummyData.billReports);
        }

        // GET /supply-reports
        public static async Task<List<SupplyReport>> GetSupplyReports()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            return new List<SupplyReport>(DummyData.supplyReports);
        }

        // GET /file-data/{id}
        public static async Task<FileData> GetFileData(int id)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            return DummyData.fileDataList.SingleOrDefault(fd => fd.Id == id);
        }

        // POST /categories
        public static async Task<bool> AddCategory(Category category)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            bool categoryNameAlreadyPresent = DummyData
                .categories
                .Count(c => c.Name.Equals(category.Name)) > 0;

            if (categoryNameAlreadyPresent)
            {
                return false;
            }

            int? maxId = DummyData.categories.Max(b => b.Id);
            category.Id = (maxId == null) ? 1 : (maxId.Value + 1);
            DummyData.categories.Add(category);

            return true;
        }

        // PUT /categories
        public static async Task<bool> UpdateCategory(Category category)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            Category categoryFromDB = DummyData
                .categories
                .SingleOrDefault(c => c.Id == category.Id);

            if (categoryFromDB == null)
            {
                return false;
            }

            bool categoryNameAlreadyPresent = DummyData
                .categories
                .Count(c => c.Id != category.Id && c.Name.Equals(category.Name)) > 0;

            if (categoryNameAlreadyPresent)
            {
                return false;
            }

            categoryFromDB.Name = category.Name;

            return true;
        }

        // DELETE /categories/{id}
        public static async Task<bool> DeleteCategory(int id)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            bool hasChildren = DummyData
                .products
                .Count(p => p.CategoryId == id) > 0;

            if (hasChildren)
            {
                return false;
            }

            DummyData.categories.RemoveAll(c => c.Id == id);
            return true;
        }

        // POST /products
        public static async Task<bool> AddProduct(Product product)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            bool productNameAlreadyPresent = DummyData
                .products
                .Count(p => p.Name.Equals(product.Name)) > 0;

            if (productNameAlreadyPresent)
            {
                return false;
            }

            int? maxId = DummyData.products.Max(b => b.Id);
            product.Id = (maxId == null) ? 1 : (maxId.Value + 1);
            DummyData.products.Add(product);

            return true;
        }

        // PUT /products
        public static async Task<bool> UpdateProduct(Product product)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            Product productFromDB = DummyData
                .products
                .SingleOrDefault(p => p.Id == product.Id);

            if (productFromDB == null)
            {
                return false;
            }

            productFromDB.AvailableQuantity = product.AvailableQuantity;
            productFromDB.Price = product.Price;
            productFromDB.CategoryId = product.CategoryId;

            return true;
        }

        // DELETE /products/{id}
        public static async Task<bool> DeleteProduct(int id)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));

            bool presentInSomeBill = DummyData
                .billContents
                .Count(bc => bc.CorrespondingProduct.Id == id) > 0;

            if (presentInSomeBill)
            {
                return false;
            }

            DummyData.products.RemoveAll(p => p.Id == id);
            return true;
        }
    }
}
