using GuildCars.Data.Factories;
using GuildCars.Data.Mapper;
using GuildCars.Models;
using GuildCars.Models.Mapper;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin
        //[Authorize(Roles = "Admin")]
        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult AddVehicle()
        {
            var model = new AddVehicleViewModel();
            var repo = VehicleFactory.GetRepo();

            model.BodyStyleList = new SelectList(repo.GetBodyStyle(), "BodyStyleId", "BodyStyleName");
            model.CarMakeList = new SelectList(repo.GetCarMake(), "CarMakeId", "MakeName");
            model.CarModelList = new SelectList(repo.GetCarModel(), "CarModelId", "ModelName");
            model.CarTypeList = new SelectList(repo.GetCarType(), "TypeId", "TypeName");
            model.ColorList = new SelectList(repo.GetColor(), "ColorId", "ColorName");
            model.InteriorList = new SelectList(repo.GetInterior(), "InteriorId", "InteriorName");
            model.TransmissionList = new SelectList(repo.GetTransmission(), "TransmissionId", "TransmissionName");
            model.CarView = new CarView();
            model.carMakeModel = new CarMake();
            model.carModelModel = new CarModel();
            model.carTypeModel = new CarType();
            model.bodyStyleModel = new BodyStyle();
            model.transmissionModel = new Transmission();
            model.colorModel = new Color();
            model.interiorModel = new Interior();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleFactory.GetRepo();
                Vehicle addcar = new Vehicle();

                try
                {
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        model.CarView.IsFeatured = false;
                        model.CarView.IsPurchased = false;

                        addcar.Year = model.CarView.Year;
                        addcar.CarMakeId = model.carMakeModel.CarMakeId;
                        addcar.CarModelId = model.carModelModel.CarModelId;
                        addcar.CarTypeId = model.carTypeModel.TypeId;
                        addcar.BodyStyleId = model.bodyStyleModel.BodyStyleId;
                        addcar.TransmissionId = model.transmissionModel.TransmissionId;
                        addcar.ColorId = model.colorModel.ColorId;
                        addcar.InteriorId = model.interiorModel.InteriorId;
                        addcar.Mileage = model.CarView.Mileage;
                        addcar.VINnumber = model.CarView.VINnumber;
                        addcar.SalePrice = model.CarView.SalePrice;
                        addcar.MSRP = model.CarView.MSRP;
                        addcar.CarDescription = model.CarView.CarDescription;
                        addcar.IsFeatured = model.CarView.IsFeatured;
                        addcar.IsPurchased = model.CarView.IsPurchased;

                        addcar.CarId = repo.AddVehicle(addcar);

                        var savePath = Server.MapPath("~/Images/Cars");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string newFileName = "inventory-" + addcar.CarId;
                        fileName = newFileName;
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savePath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savePath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        addcar.ImageFileName = Path.GetFileName(filePath);
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                repo.SaveImageToCar(addcar.CarId, addcar.ImageFileName);
                return RedirectToAction("EditVehicle", new { id = addcar.CarId });
            }
            else
            {
                var repo = VehicleFactory.GetRepo();

                model.BodyStyleList = new SelectList(repo.GetBodyStyle(), "BodyStyleId", "BodyStyleName");
                model.CarMakeList = new SelectList(repo.GetCarMake(), "CarMakeId", "MakeName");
                model.CarModelList = new SelectList(repo.GetCarModel(), "CarModelId", "ModelName");
                model.CarTypeList = new SelectList(repo.GetCarType(), "TypeId", "TypeName");
                model.ColorList = new SelectList(repo.GetColor(), "ColorId", "ColorName");
                model.InteriorList = new SelectList(repo.GetInterior(), "InteriorId", "InteriorName");
                model.TransmissionList = new SelectList(repo.GetTransmission(), "TransmissionId", "TransmissionName");
                model.CarView = new Models.Tables.CarView();

                return View(model);
            }
        }

        public ActionResult EditVehicle(int id)
        {
            var model = new EditVehicleViewModel();
            var repo = VehicleFactory.GetRepo();

            model.BodyStyleList = new SelectList(repo.GetBodyStyle(), "BodyStyleId", "BodyStyleName");
            model.CarMakeList = new SelectList(repo.GetCarMake(), "CarMakeId", "MakeName");
            model.CarModelList = new SelectList(repo.GetCarModel(), "CarModelId", "ModelName");
            model.CarTypeList = new SelectList(repo.GetCarType(), "TypeId", "TypeName");
            model.ColorList = new SelectList(repo.GetColor(), "ColorId", "ColorName");
            model.InteriorList = new SelectList(repo.GetInterior(), "InteriorId", "InteriorName");
            model.TransmissionList = new SelectList(repo.GetTransmission(), "TransmissionId", "TransmissionName");

            model.carMakeModel = new CarMake();
            model.carModelModel = new CarModel();
            model.carTypeModel = new CarType();
            model.bodyStyleModel = new BodyStyle();
            model.transmissionModel = new Transmission();
            model.colorModel = new Color();
            model.interiorModel = new Interior();
            model.CarView = new Models.Tables.CarView();
            model.CarWithIds = new Vehicle();
            model.CarWithIds = repo.GetAllByCarId(id);

            return View(model);

        }

        [HttpPost]
        public ActionResult EditVehicle(EditVehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleFactory.GetRepo();
                Models.Tables.Vehicle editcar = new Models.Tables.Vehicle();

                try
                {
                    editcar.CarId = model.CarWithIds.CarId;
                    editcar.Year = model.CarWithIds.Year;
                    editcar.CarMakeId = model.CarWithIds.CarMakeId;
                    editcar.CarModelId = model.CarWithIds.CarModelId;
                    editcar.CarTypeId = model.CarWithIds.CarTypeId;
                    editcar.BodyStyleId = model.CarWithIds.BodyStyleId;
                    editcar.TransmissionId = model.CarWithIds.TransmissionId;
                    editcar.ColorId = model.CarWithIds.ColorId;
                    editcar.InteriorId = model.CarWithIds.InteriorId;
                    editcar.Mileage = model.CarWithIds.Mileage;
                    editcar.VINnumber = model.CarWithIds.VINnumber;
                    editcar.SalePrice = model.CarWithIds.SalePrice;
                    editcar.MSRP = model.CarWithIds.MSRP;
                    editcar.CarDescription = model.CarWithIds.CarDescription;
                    editcar.IsFeatured = model.IsFeatured;
                    editcar.IsPurchased = model.CarWithIds.IsPurchased;

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images/Cars");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.CarView.ImageFileName = Path.GetFileName(filePath);

                        var oldPath = Path.Combine(savepath, model.CarWithIds.ImageFileName);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    else
                    {
                        editcar.ImageFileName = model.CarWithIds.ImageFileName;
                    }

                    repo.EditVehicle(editcar);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction("Vehicles");
            }
            else
            {
                var repo = VehicleFactory.GetRepo();

                model.BodyStyleList = new SelectList(repo.GetBodyStyle(), "BodyStyleId", "BodyStyleName");
                model.CarMakeList = new SelectList(repo.GetCarMake(), "CarMakeId", "MakeName");
                model.CarModelList = new SelectList(repo.GetCarModel(), "CarModelId", "ModelName");
                model.CarTypeList = new SelectList(repo.GetCarType(), "TypeId", "TypeName");
                model.ColorList = new SelectList(repo.GetColor(), "ColorId", "ColorName");
                model.InteriorList = new SelectList(repo.GetInterior(), "InteriorId", "InteriorName");
                model.TransmissionList = new SelectList(repo.GetTransmission(), "TransmissionId", "TransmissionName");
                model.CarView = new Models.Tables.CarView();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteVehicle(int id)
        {
            var repo = VehicleFactory.GetRepo();

            string filename = "inventory-" + id + ".jpg";

            string _path = Path.Combine(Server.MapPath("~/Images/Cars"), filename);

            if (System.IO.File.Exists(_path))
            {
                System.IO.File.Delete(_path);
            }

            try
            {
                repo.DeleteVehicle(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Vehicles");
        }

        public ActionResult Makes()
        {
            var repo = AdminFactory.GetRepo();
            var model = repo.GetCarMakesWUsers();

            return View(model);
        }

        [HttpPost]
        public ActionResult Makes(CarMake carMake)
        {
            if (string.IsNullOrEmpty(carMake.MakeName))
            {
                ModelState.AddModelError("error", "Please enter a new make");
            }

            var repo = AdminFactory.GetRepo();
            if (ModelState.IsValid)
            {
                try
                {
                    carMake.User = User.Identity.Name;
                    carMake.MakeName = carMake.MakeName.Substring(0, 1).ToUpper() + carMake.MakeName.Substring(1);
                    repo.AddMake(carMake);
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                var model = repo.GetCarMakesWUsers();
                return View("Makes", model);
            }
            else
            {
                var model = repo.GetCarMakesWUsers();

                return View(model);
            }
        }

        public ActionResult Models()
        {
            var model = new AddCarModelViewModel();
            var repoAdmin = AdminFactory.GetRepo();
            var repoVehicle = VehicleFactory.GetRepo();

            model.CarMakeList = new List<GetCarMake>();
            model.CarMakeList = repoVehicle.GetCarMake();

            model.CarModelViewList = new List<CarModelView>();
            model.CarModelViewList = repoAdmin.GetCarModelsWUsers().OrderBy(x => x.ModelName);

            return View(model);
        }

        [HttpPost]
        public ActionResult Models(string modelName, int makeid)
        {
            if (string.IsNullOrEmpty(modelName) || makeid == 0)
            {
                ModelState.AddModelError("error", "Please enter a new model");
            }

            var repo = AdminFactory.GetRepo();
            if (ModelState.IsValid)
            {
                try
                {
                    CarModelView newModel = new CarModelView();
                    newModel.ModelName = modelName.Substring(0, 1).ToUpper() + modelName.Substring(1);
                    newModel.CarMakeId = makeid;
                    newModel.User = User.Identity.Name;

                    repo.AddModel(newModel);
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                return RedirectToAction("Models");
            }
            else
            {
                var model = new AddCarModelViewModel();
                var repoAdmin = AdminFactory.GetRepo();
                var repoVehicle = VehicleFactory.GetRepo();

                model.CarMakeList = new List<GetCarMake>();
                model.CarMakeList = repoVehicle.GetCarMake();

                model.CarModelViewList = new List<CarModelView>();
                model.CarModelViewList = repoAdmin.GetCarModelsWUsers();

                return View(model);
            }
        }

        public ActionResult Specials()
        {
            var repo = AdminFactory.GetRepo();
            var model = repo.GetAllSpecials();
            return View(model);
        }

        [HttpPost]
        public ActionResult Specials(string title, string description)
        {
            var repo = AdminFactory.GetRepo();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                ModelState.AddModelError("error", "Please enter a new special title & description");
            }

            if (ModelState.IsValid)
            {
                Special special = new Special();
                special.SpecialTitle = title.First().ToString().ToUpper() + title.Substring(1);
                special.SpecialDescription = description.First().ToString().ToUpper() + description.Substring(1);
                
                repo.AddSpecial(special);
                var model = repo.GetAllSpecials();
                return View(model);
            }
            else
            {
                var model = repo.GetAllSpecials();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteSpecial(int id)
        {
            var repo = AdminFactory.GetRepo();
            repo.DeleteSpecial(id);
            var model = repo.GetAllSpecials();
            return View("Specials" ,model);
        }

        public ActionResult Users()
        {
            var repo = AdminFactory.GetRepo();
            var model = repo.GetAllUsers();
            
            return View(model);
        }

        public ActionResult AddUser()
        {
            var model = new UserViewModel();
            var repo = AdminFactory.GetRepo();

            model.User = new User();
            model.Roles = new SelectList(repo.GetAllRoles(), "RoleName", "RoleName"); 

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(UserViewModel model)
        {
            var repo = AdminFactory.GetRepo();

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = new ApplicationUser();
                    user.Email = model.User.Email;
                    user.UserName = model.User.FirstName.Substring(0, 1).ToUpper() + model.User.FirstName.Substring(1) + " " + model.User.LastName.Substring(0, 1).ToUpper() + model.User.LastName.Substring(1);

                    var chkUser = await UserManager.CreateAsync(user, model.User.Password);

                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, model.User.Role);
                        return RedirectToAction("EditUser", new { id = user.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("error", "An error occurred. Email may already be taken");
                        model.Roles = new SelectList(repo.GetAllRoles(), "RoleName", "RoleName");
                        return View(model);
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            model.User = new User();
            model.Roles = new SelectList(repo.GetAllRoles(), "RoleName", "RoleName");

            return View(model);
        }

        public ActionResult EditUser(string id)
        {
            var model = new UserViewModel();
            var repo = AdminFactory.GetRepo();

            model.User = repo.GetUserById(id);
            model.Roles = new SelectList(repo.GetAllRoles(), "RoleName", "RoleName");

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(UserViewModel model)
        {
            var repo = AdminFactory.GetRepo();

            if (ModelState.IsValid)
            {
                try
                {
                    var editUser = UserManager.FindById(model.User.UserId);
                    editUser.Email = model.User.Email;
                    editUser.UserName = model.User.FirstName.Substring(0, 1).ToUpper() + model.User.FirstName.Substring(1) + " " + model.User.LastName.Substring(0, 1).ToUpper() + model.User.LastName.Substring(1);
                    var roles = await UserManager.GetRolesAsync(editUser.Id);
                    await UserManager.RemoveFromRolesAsync(editUser.Id, roles.ToArray());
                    var result1 = UserManager.AddToRole(editUser.Id, model.User.Role);

                    var chkUser = await UserManager.UpdateAsync(editUser);

                    if (chkUser.Succeeded && !string.IsNullOrEmpty(model.User.Password))
                    {
                        ApplicationDbContext context = new ApplicationDbContext();
                        UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
                        UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);
                        string newPassword = model.User.Password;
                        string hashedNewPassword = UserManager.PasswordHasher.HashPassword(newPassword);
                        ApplicationUser cUser = await store.FindByIdAsync(model.User.UserId);
                        await store.SetPasswordHashAsync(cUser, hashedNewPassword);
                        await store.UpdateAsync(cUser);
                    }

                    if (chkUser.Succeeded)
                    {
                        var result = UserManager.Update(editUser);
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Users");
        }

    }
}