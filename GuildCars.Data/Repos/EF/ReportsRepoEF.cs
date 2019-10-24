using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repos.EF
{
    public class ReportsRepoEF : IReportsRepo
    {
        private GuildCarsEntities _ctx;

        public ReportsRepoEF()
        {
            _ctx = new GuildCarsEntities();
        }

        public List<InventoryReport> GetNewInventoryList()
        {
            List<InventoryReport> list = new List<InventoryReport>();

            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    var newList = _ctx.NewInventoryReport();
                    
                    foreach (var car in newList)
                    {
                        InventoryReport report = new InventoryReport();

                        report.Year = car.Year;
                        report.CarMake = car.MakeName;
                        report.CarModel = car.ModelName;
                        report.Count = car.TotalVehicles;
                        report.StockValue = car.TotalValue;

                        list.Add(report);
                        
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                return list;
            }
        }

        public List<InventoryReport> GetUsedInventoryList()
        {
            List<InventoryReport> list = new List<InventoryReport>();

            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    var newList = _ctx.UsedInventoryReport();

                    foreach (var car in newList)
                    {
                        InventoryReport report = new InventoryReport();

                        report.Year = car.Year;
                        report.CarMake = car.MakeName;
                        report.CarModel = car.ModelName;
                        report.Count = car.TotalVehicles;
                        report.StockValue = car.TotalValue;

                        list.Add(report);

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return list;
            }

        }

        public List<SalesReport> GetSalesReports(string user, DateTime startDate, DateTime endDate)
        {
            List<SalesReport> report = new List<SalesReport>();

            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    if (user != null)
                    {
                        var getUser = _ctx.GetUserById(user).FirstOrDefault();
                        string userName = getUser.UserName;
                        var list = _ctx.SalesReport(userName, startDate, endDate).ToList();
                        foreach (var r in list)
                        {
                            SalesReport newReport = new SalesReport();

                            newReport.User = r.SalesPerson;
                            newReport.TotalSales = decimal.Parse(r.TotalValue.ToString());
                            newReport.TotalVehicles = int.Parse(r.TotalVehicles.ToString());

                            report.Add(newReport);
                        }

                        report = report.Where(u => u.User == userName).ToList();
                    }
                    if (user == null && startDate.ToString() == "1/1/1970 12:00:00 AM" && endDate.ToString() == "1/1/2150 12:00:00 AM")
                    {
                        var list = _ctx.AllSalesReports().ToList();

                        foreach (var r in list)
                        {
                            SalesReport newReport = new SalesReport();

                            newReport.User = r.SalesPerson;
                            newReport.TotalSales = decimal.Parse(r.TotalValue.ToString());
                            newReport.TotalVehicles = int.Parse(r.TotalVehicles.ToString());

                            report.Add(newReport);
                        }
                    }

                    if (user == null && startDate.ToString() != "1/1/1970 12:00:00 AM" || endDate.ToString() != "1/1/2150 12:00:00 AM")
                    {
                        var list = _ctx.SalesReportByDate(startDate, endDate).ToList();

                        foreach (var r in list)
                        {
                            SalesReport newReport = new SalesReport();

                            newReport.User = r.SalesPerson;
                            newReport.TotalSales = decimal.Parse(r.TotalValue.ToString());
                            newReport.TotalVehicles = int.Parse(r.TotalVehicles.ToString());

                            report.Add(newReport);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return report;
        }
    }
}
