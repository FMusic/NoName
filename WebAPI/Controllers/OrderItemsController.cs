using DataLayer.Models.DB;
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
    public class OrderItemsController : ApiController
    {
        /// <summary>
        /// Gets all Order Items.
        /// </summary>
        [HttpGet]
        [ResponseType(typeof(List<OrderItem>))]
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

        /// <summary>
        /// Gets Order Items for Order ID.
        /// </summary>
        /// <param name="orderId">Order ID</param>
        [HttpGet]
        [ResponseType(typeof(List<OrderItem>))]
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

        /// <summary>
        /// Gets Order Item for ID.
        /// </summary>
        /// <param name="id">Order Item ID</param>
        /// <returns>Returns null if not found.</returns>
        [HttpGet]
        [ResponseType(typeof(OrderItem))]
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

        /// <summary>
        /// Create Order Item.
        /// </summary>
        /// /// <returns>Returns Order Item ID.</returns>
        [HttpPost]
        [ResponseType(typeof(int))]
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

        /// <summary>
        /// Update Order Item..
        /// </summary>
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

        /// <summary>
        /// Delete Order Item.
        /// </summary>
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
