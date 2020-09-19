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
    public class PlacesController : ApiController
    {
        [HttpGet]
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

        [HttpGet]
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

        [HttpPost]
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
