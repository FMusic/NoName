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
    public class PlacesController : ApiController
    {
        /// <summary>
        /// Gets all Places.
        /// </summary>
        [HttpGet]
        [ResponseType(typeof(List<Place>))]
        public async Task<IHttpActionResult> GetPlaces()
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetAllAsync<Place>());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Gets Place for ID.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns null if not found.</returns>
        [HttpGet]
        [ResponseType(typeof(Place))]
        public async Task<IHttpActionResult> GetPlaceForId([FromUri] int id)
        {
            try
            {
                return Ok(await WebApiApplication.GenericDataService.GetByIdAsync<Place>(id));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Create Place.
        /// </summary>
        /// <returns>Returns Place ID.</returns>
        [HttpPost]
        [ResponseType(typeof(int))]
        public async Task<IHttpActionResult> AddPlace([FromBody] Place place)
        {
            try
            {
                await WebApiApplication.GenericDataService.AddAsync(place);
                return Ok(place.Id);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Update Place.
        /// </summary>
        [HttpPut]
        public async Task<IHttpActionResult> UpdatePlace([FromBody] Place place)
        {
            try
            {
                await WebApiApplication.GenericDataService.UpdateAsync(place);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Delete Place.
        /// </summary>
        [HttpDelete]
        public async Task<IHttpActionResult> DeletePlace([FromBody] Place place)
        {
            try
            {
                await WebApiApplication.GenericDataService.DeleteAsync(place);
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
