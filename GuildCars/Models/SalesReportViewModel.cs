using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class SalesReportViewModel
    {
        public List<SalesReport> SalesList { get; set; }
        public List<User> UserList { get; set; }
    }
}