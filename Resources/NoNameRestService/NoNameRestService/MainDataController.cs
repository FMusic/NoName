using Newtonsoft.Json;
using NoNameAppDataModel;
using System.Net.Http;
using System.Web.Http;

namespace NoNameRestService
{
    public class MainDataController : ApiController
    {
        public HttpResponseMessage Get()
        {
            MainData mainData = DatabaseManager.GetMainData();

            return new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(mainData))
            };
        }
    }
}
