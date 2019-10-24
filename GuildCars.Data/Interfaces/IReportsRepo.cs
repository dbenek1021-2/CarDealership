using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IReportsRepo
    {
        List<InventoryReport> GetNewInventoryList();
        List<InventoryReport> GetUsedInventoryList();
        List<SalesReport> GetSalesReports(string user, DateTime startDate, DateTime endDate);
    }
}
