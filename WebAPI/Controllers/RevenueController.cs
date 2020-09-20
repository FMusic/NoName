using DataLayer.Models;
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
    public class RevenueController : ApiController
    {
        /// <summary>
        /// Gets Revenue for Place ID and date.
        /// </summary>
        /// <param name="placeId">Place ID</param>
        /// <param name="date">Date</param>
        [HttpGet]
        [ResponseType(typeof(Revenue))]
        public async Task<IHttpActionResult> GetRevenueForPlaceAndDate([FromUri] int placeId, DateTime date)
        {
            try
            {
                return Ok(await WebApiApplication.RevenueDataService.GetRevenueForPlaceIdAndDateAsync(placeId, date.Date));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Gets Revenue for Place ID and month.
        /// </summary>
        /// <param name="placeId">Place ID</param>
        /// <param name="month">Month</param>
        [HttpGet]
        [ResponseType(typeof(List<Revenue>))]
        public async Task<IHttpActionResult> GetRevenueForPlaceAndMonth([FromUri] int placeId, DateTime month)
        {
            try
            {
                return Ok(await WebApiApplication.RevenueDataService.GetRevenueForPlaceIdAndMonthAsync(placeId, month.Date));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                return InternalServerError();
            }
        }
    }
}
