using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GuildCars.Models;
using System.Dynamic;
using GuildCars.Data;
using GuildCars.Data.Factories;

namespace GuildCars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = HomeFactory.GetRepo().GetHomePage();
            return View(model);
        }

        public ActionResult Specials()
        {
            var model = HomeFactory.GetRepo().GetSpecials();
            return View(model);
        }

        public ActionResult Contact(string vinNumber)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = HomeFactory.GetRepo();

                try
                {
                    repo.AddContact(model.contactUs);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return View();
            }

        }
    }
}