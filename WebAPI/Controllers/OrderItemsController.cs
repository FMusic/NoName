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
    public class OrderItemsController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetOrderItems()
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetAllAsync<OrderItem>());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOrderItemsForOrder([FromUri] int orderId)
        {
            try
            {
                return Ok(await WebApiApplication.OrderItemsDataService.GetOrderItemsForOrderIdAsync(orderId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOrderItemForId([FromUri] int id)
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetByIdAsync<OrderItem>(id));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddOrderItem([FromBody] OrderItem orderItem)
        {
            try
            {
                await WebApiApplication.GenericDataService.AddAsync(orderItem);
                return Ok(orderItem.Id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateOrderItem([FromBody] OrderItem orderItem)
        {
            try
            {
                await WebApiApplication.GenericDataService.UpdateAsync(orderItem);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOrderItem([FromBody] OrderItem orderItem)
        {
            try
            {
                await WebApiApplication.GenericDataService.DeleteAsync(orderItem);
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
