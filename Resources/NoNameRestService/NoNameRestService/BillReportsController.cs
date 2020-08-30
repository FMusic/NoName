using Newtonsoft.Json;
using NoNameAppDataModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace NoNameRestService
{
    public class BillReportsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            List<BillReport> billReports = DatabaseManager.GetBillReports();

            return new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(billReports))
            };
        }
    }
}
