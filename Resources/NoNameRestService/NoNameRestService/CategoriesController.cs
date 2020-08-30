using Newtonsoft.Json;
using NoNameAppDataModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NoNameRestService
{
    public class CategoriesController : ApiController
    {
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            string categoryJson = await request.Content.ReadAsStringAsync();
            Category receivedCategory = JsonConvert.DeserializeObject<Category>(categoryJson);
            bool categoryCreated = DatabaseManager.CreateCategory(receivedCategory);

            if (categoryCreated)
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
            string categoryJson = await request.Content.ReadAsStringAsync();
            Category receivedCategory = JsonConvert.DeserializeObject<Category>(categoryJson);
            bool categoryUpdated = DatabaseManager.UpdateCategory(receivedCategory);

            if (categoryUpdated)
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
            bool categoryDeleted = DatabaseManager.DeleteCategory(id);

            if (categoryDeleted)
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