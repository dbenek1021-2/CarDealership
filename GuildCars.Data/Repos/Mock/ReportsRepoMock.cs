using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repos.Mock
{
    public class ReportsRepoMock : IReportsRepo
    {
        private List<InventoryReport> _inventoryReports;
        private List<SalesReport> _salesReports;

        public ReportsRepoMock()
        {
            if (_inventoryReports == null)
            {
                _inventoryReports = new List<InventoryReport>()
                {
                    new InventoryReport(){Year = 2016, CarMake = "Toyota", CarModel = "Camry", Count = 5, StockValue = 105000},
                    new InventoryReport(){Year = 2015, CarMake = "Toyota", CarModel = "Corolla", Count = 2, StockValue = 45000},
                    new InventoryReport(){Year = 2018, CarMake = "Honda", CarModel = "Civic", Count = 2, StockValue = 45000}

                };
            }
            if (_salesReports == null)
            {
                _salesReports = new List<SalesReport>()
                {
                    new SalesReport(){ User = "David Smith", TotalSales = 1005000, TotalVehicles = 7},
                    new SalesReport(){ User = "Danielle Smith", TotalSales = 1027000, TotalVehicles = 8},
                    new SalesReport(){ User = "Jane Doe", TotalSales = 555000, TotalVehicles = 2}

                };
            }

        }
        public List<InventoryReport> GetNewInventoryList()
        {
            return _inventoryReports;
        }

        public List<SalesReport> GetSalesReports(string user, DateTime startDate, DateTime endDate)
        {
            return _salesReports;
        }

        public List<InventoryReport> GetUsedInventoryList()
        {
            return _inventoryReports;
        }
    }
}
