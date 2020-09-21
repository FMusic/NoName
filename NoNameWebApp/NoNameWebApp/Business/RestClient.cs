using Newtonsoft.Json;
using NoNameAppDataModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NoNameWebApp.Business
{
    public class RestClient
    {
        private const string MAIN_URI = "http://40.68.47.205/Api/";

        // POST /login
        public static async Task<UserData> CheckLogin(UserData userData)
        {
            userData.Usr = userData.Username;
            userData.Pwd = userData.Password;

            string uri = string.Format("{0}/users/login", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                string content = await message.Content.ReadAsStringAsync();
                userData = JsonConvert.DeserializeObject<UserData>(content);
                MainData.UserData = userData;
                return userData;
            }

            return null;
        }

        // GET /maindata
        public static async Task<MainData> GetMainData()
        {
            MainData result = new MainData();
            result.Categories = await GetCategories();
            result.Products = await GetProducts();
            int PlaceId;
            return result;
        }

        // GET /categories //test
        private static async Task<List<Category>> GetCategories()
        {
            string uri = string.Format("{0}/Categories?placeId={1}", MAIN_URI, MainData.UserData.PlaceId);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return new List<Category>();
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Category>>(content);
        }

        // GET /products //test
        private static async Task<List<Product>> GetProducts()
        {
            string uri = string.Format("{0}/items", MAIN_URI);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return new List<Product>();
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Product>>(content);
        }

        // GET /product //single product
        private static async Task<Product> GetProduct(int id)
        {
            string uri = string.Format("{0}/Items/{1}", MAIN_URI, id);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return new Product();
            }


            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Product>(content);
        }

        // POST /bills
        public static async Task<bool> CreateBill(Bill bill)
        {
            string uri = string.Format("{0}/orders", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(bill, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);

            string content = await message.Content.ReadAsStringAsync();
            int OrderId = JsonConvert.DeserializeObject<int>(content);

            foreach (BillContent item in bill.Contents)
            {
                item.OrderId = OrderId;
                await CreateBillContent(item);
            }

            return true;
        }

        public static async Task<bool> CreateBillContent(BillContent billContent)
        {
            billContent.ItemId = billContent.CorrespondingProduct.Id;

            string uri = string.Format("{0}/orderItems", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(billContent), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);

            return true;
        }

        // PUT /bills
        public static async Task<bool> UpdateBill(Bill bill)
        {
            string uri = string.Format("{0}/orders", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(bill), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // DELETE /bills/{id}
        public static async Task<bool> DeleteBill(int id)
        {
            string uri = string.Format("{0}/orders", MAIN_URI);

            Bill entity = new Bill();
            entity.Id = id;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // GET /bills
        public static async Task<List<Bill>> GetBills()
        {
            string uri = string.Format("{0}/orders?userId={1}", MAIN_URI, MainData.UserData.Id);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return new List<Bill>();
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Bill>>(content);
        }

        // GET /bill/{id}
        public static async Task<Bill> GetBill(int id)
        {
            Bill bill = await GetOrders(id);
            List<BillContent> BillContentList = await GetOrderItems(id);
            foreach (BillContent content in BillContentList)
            {
                Product Product = await GetProduct(content.ItemId);
                content.CorrespondingProduct = Product;
            }

            bill.Contents = BillContentList;

            return bill;
        }

        // GET /bills/{id} //GetOrderItems
        public static async Task<List<BillContent>> GetOrderItems(int id)
        {
            string uri = string.Format("{0}/OrderItems?orderId={1}", MAIN_URI, id);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<BillContent>>(content);
        }

        // GET /bills/{id} //orders
        public static async Task<Bill> GetOrders(int id)
        {
            string uri = string.Format("{0}/orders/{1}", MAIN_URI, id);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Bill>(content);
        }

        // POST /categories
        public static async Task<bool> AddCategory(Category category)
        {
            string uri = string.Format("{0}/categories", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // PUT /categories
        public static async Task<bool> UpdateCategory(Category category)
        {
            string uri = string.Format("{0}/categories", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // DELETE /categories/{id}
        public static async Task<bool> DeleteCategory(int id)
        {
            string uri = string.Format("{0}/categories", MAIN_URI);

            Category entity = new Category();
            entity.Id = id;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // POST /products
        public static async Task<bool> AddProduct(Product product)
        {
            string uri = string.Format("{0}/items", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // PUT /products
        public static async Task<bool> UpdateProduct(Product product)
        {
            string uri = string.Format("{0}/items", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // DELETE /products/{id}
        public static async Task<bool> DeleteProduct(int id)
        {
            string uri = string.Format("{0}/items", MAIN_URI);

            Product entity = new Product();
            entity.Id = id;

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);
            return message.StatusCode == HttpStatusCode.OK;
        }

        public static async Task<Revenue> GetRevenue(string date, int placeId)
        {
            string uri = string.Format("{0}/Revenue?placeId={1}&date={2}", MAIN_URI, placeId, date);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Revenue>(content);
        }
    }
}
