using Newtonsoft.Json;
using NoNameAppDataModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NoNameRestService
{
    public class LoginController : ApiController
    {
        public string Get()
        {
            return "Test succeeded at: " + DateTime.Now;
        }

        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            string userDataJson = await request.Content.ReadAsStringAsync();
            UserData receivedUserData = JsonConvert.DeserializeObject<UserData>(userDataJson);
            UserData userDataFromDB = DatabaseManager.CheckLogin(receivedUserData);

            if (userDataFromDB == null)
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
            
            return new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(userDataFromDB))
            };
        }
    }
}
