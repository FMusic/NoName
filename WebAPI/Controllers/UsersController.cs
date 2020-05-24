using DataLayer.Models.DB;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Login([FromBody]JObject data)
        {
            if (!(data.ContainsKey("usr") && data.ContainsKey("pwd")))
            {
                return BadRequest();
            }

            try
            {
                var user = await WebApiApplication.UsersDataService.GetUserForLoginDetailsAsync(data["usr"].ToString(), data["pwd"].ToString());
                if (user == null)
                {
                    return Unauthorized();
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddUser([FromBody]User user)
        {
            try
            {
                await WebApiApplication.GenericDataService.AddAsync(user);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser([FromBody]User user)
        {
            try
            {
                await WebApiApplication.GenericDataService.UpdateAsync(user);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser([FromBody]User user)
        {
            try
            {
                await WebApiApplication.GenericDataService.DeleteAsync(user);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
