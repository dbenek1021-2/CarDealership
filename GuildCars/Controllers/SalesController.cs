using GuildCars.Data.Factories;
using GuildCars.Models;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    [Authorize(Roles = "Admin, Sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Purchase(int id)
        {
            var model = new PurchaseViewModel();

            var statesRepo = SalesFactory.GetRepo();
            var purchaseTypesRepo = SalesFactory.GetRepo();
            var detailsRepo = SalesFactory.GetRepo().GetDetails(id);

            model.States = new SelectList(statesRepo.GetStates(), "StateId", "StateId");
            model.PurchaseType = new SelectList(purchaseTypesRepo.GetPurchaseType(), "PurchaseTypeId", "PurchaseTypeName");
            model.Car = new CarView();
            model.Car = detailsRepo;
            model.Customer = new Customer();
            model.Purchase = new Purchase();

            return View(model);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            if (ModelState.IsValid)
            {
                var salesRepo = SalesFactory.GetRepo();

                try
                {
                    model.Car.IsPurchased = true;
                    int purchaseId = 0;
                    int customerId = 0;

                    PurchaseVehicle purchaseDetails = new PurchaseVehicle();

                    purchaseDetails.PurchaseId = purchaseId;
                    purchaseDetails.CustomerId = customerId;
                    purchaseDetails.CarId = model.Car.CarId;
                    purchaseDetails.Name = model.Customer.Name;
                    purchaseDetails.Address1 = model.Customer.Address1;
                    purchaseDetails.Address2 = model.Customer.Address2;
                    purchaseDetails.City = model.Customer.City;
                    purchaseDetails.StateId = model.Customer.StateId;
                    purchaseDetails.Zipcode = model.Customer.Zipcode;
                    purchaseDetails.Phone = model.Customer.Phone;
                    purchaseDetails.Email = model.Customer.Email;
                    purchaseDetails.IsPurchased = model.Car.IsPurchased;
                    purchaseDetails.PurchasePrice = model.Purchase.PurchasePrice;
                    purchaseDetails.PurchaseTypeId = model.Purchase.PurchaseTypeID;
                    purchaseDetails.SalesPerson = User.Identity.Name;

                    salesRepo.SubmitPurchase(purchaseDetails);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var statesRepo = SalesFactory.GetRepo();
                var purchaseTypesRepo = SalesFactory.GetRepo();

                model.States = new SelectList(statesRepo.GetStates(), "StateId", "StateId");
                model.PurchaseType = new SelectList(purchaseTypesRepo.GetPurchaseType(), "PurchaseTypeId", "PurchaseTypeName");

                return View(model);
            }

            ViewBag.message = "Thank you for your purchase!";
            return View();
        }
    }
}