using Newtonsoft.Json;
using NoNameAppDataModel;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NoNameWebApp.Business
{
    public class RestClient
    {
        private const string MAIN_URI = "http://localhost:59518/api/";

        // POST /login
        public static async Task<UserData> CheckLogin(UserData userData)
        {
            string uri = string.Format("{0}/login", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                string content = await message.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserData>(content);
            }

            return null;
        }

        // GET /maindata
        public static async Task<MainData> GetMainData()
        {
            string uri = string.Format("{0}/maindata", MAIN_URI);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MainData>(content);
        }

        // POST /bills
        public static async Task<bool> CreateBill(Bill bill)
        {
            string uri = string.Format("{0}/bills", MAIN_URI);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(bill), Encoding.UTF8, "application/json")
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.SendAsync(request);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // PUT /bills
        public static async Task<bool> UpdateBill(Bill bill)
        {
            string uri = string.Format("{0}/bills", MAIN_URI);

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
            string uri = string.Format("{0}/bills/{1}", MAIN_URI, id);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync(uri);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // GET /bills
        public static async Task<List<Bill>> GetBills()
        {
            string uri = string.Format("{0}/bills", MAIN_URI);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return new List<Bill>();
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Bill>>(content);
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
            string uri = string.Format("{0}/categories/{1}", MAIN_URI, id);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync(uri);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // POST /products
        public static async Task<bool> AddProduct(Product product)
        {
            string uri = string.Format("{0}/products", MAIN_URI);

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
            string uri = string.Format("{0}/products", MAIN_URI);

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
            string uri = string.Format("{0}/products/{1}", MAIN_URI, id);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync(uri);
            return message.StatusCode == HttpStatusCode.OK;
        }

        // GET /billreports
        public static async Task<List<BillReport>> GetBillReports()
        {
            string uri = string.Format("{0}/billreports", MAIN_URI);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return new List<BillReport>();
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<BillReport>>(content);
        }

        // GET /supply-reports
        public static async Task<List<SupplyReport>> GetSupplyReports()
        {
            string uri = string.Format("{0}/supplyreports", MAIN_URI);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return new List<SupplyReport>();
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<SupplyReport>>(content);
        }

        // GET /filedata/{id}
        public static async Task<FileData> GetFileData(int id)
        {
            string uri = string.Format("{0}/filedata/{1}", MAIN_URI, id);
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(uri);

            if (message.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            string content = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FileData>(content);
        }
    }
}
