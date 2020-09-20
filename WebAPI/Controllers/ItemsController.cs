using DataLayer.DataServices;
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
    public class ItemsController : ApiController
    {
        /// <summary>
        /// Gets all Items.
        /// </summary>
        [HttpGet]
        [ResponseType(typeof(List<Item>))]
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

        /// <summary>
        /// Gets Items for Category ID.
        /// </summary>
        /// <param name="categoryId">Category ID</param>
        [HttpGet]
        [ResponseType(typeof(List<Item>))]
        public async Task<IHttpActionResult> GetItemsForCategory([FromUri] int categoryId)
        {
            try
            {
                return Ok(await WebApiApplication.ItemsDataService.GetItemsForCategoryIdAsync(categoryId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Gets Item for ID.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns null if not found.</returns>
        [HttpGet]
        [ResponseType(typeof(Item))]
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

        /// <summary>
        /// Create Item.
        /// </summary>
        /// <returns>Returns Item ID.</returns>
        [HttpPost]
        [ResponseType(typeof(int))]
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

        /// <summary>
        /// Update Item.
        /// </summary>
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

        /// <summary>
        /// Delete Item.
        /// </summary>
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
