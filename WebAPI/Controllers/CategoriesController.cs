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
    public class CategoriesController : ApiController
    {
        /// <summary>
        /// Gets all Categories.
        /// </summary>
        [HttpGet]
        [ResponseType(typeof(List<Category>))]
        public async Task<IHttpActionResult> GetCategories()
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetAllAsync<Category>());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Gets Categories for Place ID.
        /// </summary>
        /// <param name="placeId">Place ID</param>
        [HttpGet]
        [ResponseType(typeof(List<Category>))]
        public async Task<IHttpActionResult> GetCategoriesForPlace([FromUri] int placeId)
        {
            try
            {
                return Ok(await WebApiApplication.CategoriesDataService.GetCategoriesForPlaceIdAsync(placeId));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Gets Category for ID.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns null if not found.</returns>
        [HttpGet]
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategoryForId([FromUri] int id)
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetByIdAsync<Category>(id));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Create Category.
        /// </summary>
        /// <returns>Returns Category ID.</returns>
        [HttpPost]
        [ResponseType(typeof(int))]
        public async Task<IHttpActionResult> AddCategory([FromBody]Category category)
        {
            try
            {
                await WebApiApplication.GenericDataService.AddAsync(category);
                return Ok(category.Id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Update Category.
        /// </summary>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCategory([FromBody]Category category)
        {
            try
            {
                await WebApiApplication.GenericDataService.UpdateAsync(category);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Delete Category.
        /// </summary>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCategory([FromBody]Category category)
        {
            try
            {
                await WebApiApplication.GenericDataService.DeleteAsync(category);
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
