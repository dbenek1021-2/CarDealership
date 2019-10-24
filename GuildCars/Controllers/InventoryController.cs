using GuildCars.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class InventoryController : Controller
    {
        // GET: NewInventory
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var repo = InventoryFactory.GetRepo();
            var model = repo.GetDetails(id);

            return View(model);
        }
    }
}