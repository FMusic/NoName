using Newtonsoft.Json;
using NoNameAppDataModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace NoNameRestService
{
    public class SupplyReportsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            List<SupplyReport> billReports = DatabaseManager.GetSupplyReports();

            return new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(billReports))
            };
        }
    }
}