using GuildCars.Data.Factories;
using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sales()
        {
            var model = new SalesReportViewModel();
            var repo = AdminFactory.GetRepo();

            model.UserList = repo.GetAllUsers();
            model.SalesList = new List<Models.Tables.SalesReport>();
            
            return View(model);
        }

        public ActionResult Inventory()
        {
            var model = new InventoryReportViewModel();
            var repo = ReportsFactory.GetRepo();

            model.NewInventory = repo.GetNewInventoryList();
            model.UsedInventory = repo.GetUsedInventoryList();
            return View(model);
        }
    }
}