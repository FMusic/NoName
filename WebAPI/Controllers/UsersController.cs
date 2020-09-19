﻿using DataLayer.Models.DB;
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
        public async Task<IHttpActionResult> Login([FromBody] JObject data)
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
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
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

        [HttpGet]
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

        [HttpPost]
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
