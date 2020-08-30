using Newtonsoft.Json;
using NoNameAppDataModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoNameRestService
{
    public class FileDataController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            FileData fileData = DatabaseManager.GetFileData(id);

            if (fileData == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(fileData))
            };
        }
    }
}