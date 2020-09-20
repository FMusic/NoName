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
    public class OrdersController : ApiController
    {
        /// <summary>
        /// Gets all Orders.
        /// </summary>
        [HttpGet]
        [ResponseType(typeof(List<Order>))]
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

        /// <summary>
        /// Gets Orders for Place ID.
        /// </summary>
        /// <param name="placeId">Place ID</param>
        [HttpGet]
        [ResponseType(typeof(List<Order>))]
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

        /// <summary>
        /// Gets Orders for User ID.
        /// </summary>
        /// <param name="userId">User ID</param>
        [HttpGet]
        [ResponseType(typeof(List<Order>))]
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

        /// <summary>
        /// Gets Order for ID.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns null if not found.</returns>
        [HttpGet]
        [ResponseType(typeof(Order))]
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

        /// <summary>
        /// Create Order.
        /// </summary>
        /// <returns>Returns Order ID.</returns>
        [HttpPost]
        [ResponseType(typeof(int))]
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

        /// <summary>
        /// Update Order.
        /// </summary>
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

        /// <summary>
        /// Delete Order.
        /// </summary>
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
