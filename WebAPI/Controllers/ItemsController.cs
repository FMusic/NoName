using DataLayer.DataServices;
using DataLayer.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ItemsController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetItems()
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetAllAsync<Item>());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetItemForId([FromUri] int id)
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetByIdAsync<Item>(id));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddItem([FromBody]Item item)
        {
            try
            {
                await WebApiApplication.GenericDataService.AddAsync(item);
                return Ok(item.Id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateItem([FromBody]Item item)
        {
            try
            {
                await WebApiApplication.GenericDataService.UpdateAsync(item);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteItem([FromBody]Item item)
        {
            try
            {
                await WebApiApplication.GenericDataService.DeleteAsync(item);
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
