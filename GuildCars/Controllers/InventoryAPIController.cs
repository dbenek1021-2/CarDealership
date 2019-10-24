using GuildCars.Data.Factories;
using GuildCars.Data.Repos.EF;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("api/newInventory/newSearch")]
        [AcceptVerbs("GET")]
        public IHttpActionResult NewCarSearch(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string searchTerm)
        {
            var repo = InventoryFactory.GetRepo();

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

                var result = repo.NewCarSearch(parameters);
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

        [Route("api/usedInventory/usedSearch")]
        [AcceptVerbs("GET")]
        public IHttpActionResult UsedCarSearch(decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, string searchTerm)
        {
            var repo = InventoryFactory.GetRepo();

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

                var result = repo.UsedCarSearch(parameters);
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
