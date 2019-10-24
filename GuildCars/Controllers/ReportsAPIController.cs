using GuildCars.Data.Factories;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.Controllers
{
    public class ReportsAPIController : ApiController
    {
        [Route("api/reports/salesReport")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SalesReport(string user, string fromDate, string toDate)
        {
            var repo = ReportsFactory.GetRepo();
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            if (fromDate != null)
            {
                if (fromDate.Length < 6 || fromDate.Length > 10)
                {
                    Exception ex = new Exception();
                    return BadRequest(ex.Message);
                }
                
            }
            if (toDate != null)
            {
                if (toDate.Length < 6 || toDate.Length > 10)
                {
                    Exception ex = new Exception();
                    return BadRequest(ex.Message);
                }

            }
            if (fromDate != null)
            {
                if (fromDate.Length >= 6 || fromDate.Length <= 10)
                {
                    var chkYrFromDate = fromDate.Substring(fromDate.Length - 4);
                    if (int.Parse(chkYrFromDate) > DateTime.Now.Year)
                    {
                        Exception ex = new Exception();
                        return BadRequest(ex.Message);
                    }
                }
                
            }
            if (toDate != null)
            {
                if (toDate.Length >= 6 || toDate.Length <= 10)
                {
                    var chkYrToDate = toDate.Substring(toDate.Length - 4);
                    if (int.Parse(chkYrToDate) > DateTime.Now.Year)
                    {
                        Exception ex = new Exception();
                        return BadRequest(ex.Message);
                    }
                }

            }

            if (fromDate == null)
            {
                startDate = new DateTime(1970, 1, 1);
            }
            else
            {
                startDate = DateTime.Parse(fromDate);
            }

            if (toDate == null)
            {
                endDate = new DateTime(2150, 1, 1);
            }
            else
            {
                endDate = DateTime.Parse(toDate);
            }

            try
            {
                var result = repo.GetSalesReports(user, startDate, endDate);
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
