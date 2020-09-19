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
    public class OrdersController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetOrders()
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetAllAsync<Order>());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOrdersForPlace([FromUri] int placeId)
        {
            try
            {
                return Ok(await WebApiApplication.OrdersDataService.GetOrdersForPlaceIdAsync(placeId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOrdersForUser([FromUri] int userId)
        {
            try
            {
                return Ok(await WebApiApplication.OrdersDataService.GetOrdersForUserIdAsync(userId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOrderForId([FromUri] int id)
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetByIdAsync<Order>(id));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddOrder([FromBody] Order order)
        {
            try
            {
                await WebApiApplication.GenericDataService.AddAsync(order);
                return Ok(order.Id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateOrder([FromBody] Order order)
        {
            try
            {
                await WebApiApplication.GenericDataService.UpdateAsync(order);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOrder([FromBody] Order order)
        {
            try
            {
                await WebApiApplication.GenericDataService.DeleteAsync(order);
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
