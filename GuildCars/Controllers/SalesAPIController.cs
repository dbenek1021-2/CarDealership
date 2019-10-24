using GuildCars.Data.Factories;
using GuildCars.Models;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.Controllers
{
    public class SalesAPIController : ApiController
    {
        [Route("api/sales")]
        [AcceptVerbs("GET")]
        public IHttpActionResult AllCarSearch(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string searchTerm)
        {
            var repo = SalesFactory.GetRepo();

            try
            {
                var parameters = new InventorySearchParameters()
                {
                    SearchTerm = searchTerm,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear
                };

                var result = repo.AllCarSearch(parameters);
                if (result.Count == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}