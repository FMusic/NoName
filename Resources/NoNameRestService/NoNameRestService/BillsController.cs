using Newtonsoft.Json;
using NoNameAppDataModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NoNameRestService
{
    public class BillsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            List<Bill> bills = DatabaseManager.GetBills();

            return new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(bills))
            };
        }

        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            string billJson = await request.Content.ReadAsStringAsync();
            Bill receivedBill = JsonConvert.DeserializeObject<Bill>(billJson);
            bool billCreated = DatabaseManager.CreateBill(receivedBill);

            if (billCreated)
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }

        public async Task<HttpResponseMessage> Put(HttpRequestMessage request)
        {
            string billJson = await request.Content.ReadAsStringAsync();
            Bill receivedBill = JsonConvert.DeserializeObject<Bill>(billJson);
            bool billUpdated = DatabaseManager.UpdateBill(receivedBill);

            if (billUpdated)
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }

        public HttpResponseMessage Delete(int id)
        {
            bool billDeleted = DatabaseManager.DeleteBill(id);

            if (billDeleted)
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}