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
    public class CategoriesController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetCategories()
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetAllAsync<Category>());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddCategory([FromBody]Category category)
        {
            try
            {
                await WebApiApplication.GenericDataService.AddAsync(category);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateCategory([FromBody]Category category)
        {
            try
            {
                await WebApiApplication.GenericDataService.UpdateAsync(category);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCategory([FromBody]Category category)
        {
            try
            {
                await WebApiApplication.GenericDataService.DeleteAsync(category);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
