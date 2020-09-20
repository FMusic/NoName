using DataLayer.Models;
using DataLayer.Models.DB;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        /// <summary>
        /// User Login.
        /// </summary>
        /// <returns> Returns User or 401 Unauthorized.</returns>
        [Route("api/Users/Login")]
        [HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Login([FromBody] LoginInfo loginInfo)
        {
            try
            {
                var user = await WebApiApplication.UsersDataService.GetUserForLoginInfoAsync(loginInfo);
                if (user == null)
                {
                    return Unauthorized();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Checks if username exists.
        /// </summary>
        /// <returns>Returns true if username exists or false.</returns>
        /// <param>username</param>
        [HttpGet]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> CheckUsernameExists([FromUri] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest();
            }

            try
            {
                return Ok(await WebApiApplication.UsersDataService.CheckUsernameExistsAsync(username));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Gets User for ID.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Returns null if not found.</returns>
        [HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUserForId([FromUri] int id)
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetByIdAsync<User>(id));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Create User.
        /// </summary>
        /// <returns>Returns User ID.</returns>
        [HttpPost]
        [ResponseType(typeof(int))]
        public async Task<IHttpActionResult> AddUser([FromBody] User user)
        {
            try
            {
                await WebApiApplication.GenericDataService.AddAsync(user);
                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Update User.
        /// </summary>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                await WebApiApplication.GenericDataService.UpdateAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Delete User.
        /// </summary>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser([FromBody] User user)
        {
            try
            {
                await WebApiApplication.GenericDataService.DeleteAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }
    }
}
