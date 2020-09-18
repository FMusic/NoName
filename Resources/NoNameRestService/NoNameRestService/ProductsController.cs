using Newtonsoft.Json;
using NoNameAppDataModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NoNameRestService
{
    public class ProductsController : ApiController
    {
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            string productJson = await request.Content.ReadAsStringAsync();
            Product receivedProduct = JsonConvert.DeserializeObject<Product>(productJson);
            bool productCreated = DatabaseManager.CreateProduct(receivedProduct);

            if (productCreated)
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
            string productJson = await request.Content.ReadAsStringAsync();
            Product receivedProduct = JsonConvert.DeserializeObject<Product>(productJson);
            bool productUpdated = DatabaseManager.UpdateProduct(receivedProduct);

            if (productUpdated)
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
            bool productDeleted = DatabaseManager.DeleteProduct(id);

            if (productDeleted)
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