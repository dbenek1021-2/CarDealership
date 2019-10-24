using GuildCars.Data.Interfaces;
using GuildCars.Data.Mapper;
using GuildCars.Models.Mapper;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repos.EF
{
    public class AdminRepoEF : IAdminRepo
    {
        private GuildCarsEntities _ctx;

        public AdminRepoEF()
        {
            _ctx = new GuildCarsEntities();
        }

        public void AddSpecial(Models.Tables.Special special)
        {
            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    _ctx.AddSpecial(special.SpecialTitle, special.SpecialDescription);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<CarView> AllCarSearch(InventorySearchParameters parameters)
        {
            var list = new List<CarView>();

            var dbList = _ctx.Cars.ToList();

            dbList = dbList.Where(c => c.IsPurchased == false).ToList();
            if (string.IsNullOrEmpty(parameters.SearchTerm) && parameters.MaxPrice == null && parameters.MinPrice == null && parameters.MaxYear == null && parameters.MinYear == null && parameters.SearchTerm == null)
            {
                dbList = dbList.OrderByDescending(c => c.MSRP).ToList();
            }
            else
            {
                if (!string.IsNullOrEmpty(parameters.SearchTerm) && parameters.SearchTerm.Length > 2)
                {
                    if (parameters.SearchTerm.Contains(" "))
                    {
                        var secondTerm = "";
                        var thirdTerm = "";
                        var splitTerm = parameters.SearchTerm.Split(' ');
                        var firstTerm = splitTerm[0];
                        if (splitTerm[1].Length > 0)
                        {
                            secondTerm = splitTerm[1];

                            if (splitTerm.Length > 2)
                            {
                                thirdTerm = splitTerm[2];
                            }
                        }

                        if (firstTerm != null)
                        {
                            dbList = dbList.Where(c =>
                               c.Year.ToString().Contains(firstTerm) ||
                               c.CarMake.MakeName.ToUpper().Contains(firstTerm.ToUpper()) ||
                               c.CarModel.ModelName.ToUpper().Contains(firstTerm.ToUpper())).ToList();
                        }
                        if (secondTerm != null)
                        {
                            dbList = dbList.Where(c =>
                               c.Year.ToString().Contains(secondTerm) ||
                               c.CarMake.MakeName.ToUpper().Contains(secondTerm.ToUpper()) ||
                               c.CarModel.ModelName.ToUpper().Contains(secondTerm.ToUpper())).ToList();
                        }
                        if (thirdTerm != null)
                        {
                            dbList = dbList.Where(c =>
                               c.Year.ToString().Contains(secondTerm) ||
                               c.CarMake.MakeName.ToUpper().Contains(secondTerm.ToUpper()) ||
                               c.CarModel.ModelName.ToUpper().Contains(secondTerm.ToUpper())).ToList();
                        }
                    }
                }
                if (!string.IsNullOrEmpty(parameters.SearchTerm) && !parameters.SearchTerm.Contains(" "))
                {
                    dbList = dbList.Where(c =>
                         c.Year.ToString().Contains(parameters.SearchTerm.ToUpper()) ||
                         c.CarMake.MakeName.ToUpper().Contains(parameters.SearchTerm.ToUpper()) ||
                         c.CarModel.ModelName.ToUpper().Contains(parameters.SearchTerm.ToUpper())).ToList();

                    if (dbList.Count() == 0)
                    {
                        return list;
                    }
                    else
                    {

                    }
                }
                if (parameters.MaxPrice != null)
                {
                    dbList = dbList.Where(c => c.SalePrice < parameters.MaxPrice).ToList();
                }
                if (parameters.MinPrice != null)
                {
                    dbList = dbList.Where(c => c.SalePrice > parameters.MinPrice).ToList();
                }
                if (parameters.MaxYear != null)
                {
                    dbList = dbList.Where(c => c.Year <= parameters.MaxYear).ToList();
                }
                if (parameters.MinYear != null)
                {
                    dbList = dbList.Where(c => c.Year >= parameters.MinYear).ToList();
                }
            }

            dbList = dbList.Take(20).ToList();
            foreach (var car in dbList)
            {
                list.Add(VehicleView.Car(car));
            }

            return list;
        }

        public void DeleteSpecial(int id)
        {
            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    _ctx.DeleteSpecial(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Models.Tables.CarMake> GetCarMakesWUsers()
        {
            List<Models.Tables.CarMake> list = new List<Models.Tables.CarMake>();
            var makeView = new Models.Tables.CarMake();

            using (_ctx = new GuildCarsEntities())
            {
                var carMakes = _ctx.GetCarMake();

                foreach (var make in carMakes)
                {
                    CarMake carMake = new CarMake();

                    carMake.CarMakeId = make.CarMakeId;
                    carMake.MakeName = make.MakeName;
                    carMake.User = make.User;
                    carMake.DateAdded = make.DateAdded;

                    makeView = MakeView.Make(carMake);

                    list.Add(makeView);
                }

            }
            return list;
        }

        public IEnumerable<CarModelView> GetCarModelsWUsers()
        {
            var list = new List<CarModelView>();

            using (_ctx = new GuildCarsEntities())
            {
                var carModels = _ctx.GetCarModel();

                foreach (var model in carModels)
                {
                    list.Add(ModelView.Model(model));
                }

            }
            return list;
        }

        public List<Models.Tables.Special> GetAllSpecials()
        {
            List<Models.Tables.Special> specials = new List<Models.Tables.Special>();

            using (_ctx = new GuildCarsEntities())
            {
                var listOfSpecials = _ctx.GetAllSpecials();

                foreach (var s in listOfSpecials)
                {
                    Models.Tables.Special hp = new Models.Tables.Special();

                    hp.SpecialId = s.SpecialId;
                    hp.SpecialTitle = s.SpecialTitle;
                    hp.SpecialDescription = s.SpecialDescription;

                    specials.Add(hp);
                }
            }
            return specials;
        }

        public void AddMake(Models.Tables.CarMake carMake)
        {
            User user = new User();

            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    var userInfo = _ctx.GetUserByName(carMake.User);
                    foreach (var u in userInfo)
                    {
                        user.Email = u.Email;
                    }
                    _ctx.AddVehicleMake(carMake.MakeName, user.Email);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void AddModel(CarModelView carModel)
        {
            User user = new User();

            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    var userInfo = _ctx.GetUserByName(carModel.User);
                    foreach (var u in userInfo)
                    {
                        user.Email = u.Email;
                    }
                    _ctx.AddVehicleModel(carModel.ModelName, carModel.CarMakeId, user.Email);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (_ctx = new GuildCarsEntities())
            {
                var listOfUsers = _ctx.GetAllUsers();

                foreach (var user in listOfUsers)
                {
                    User userToList = new User();

                    userToList.UserId = user.Id;
                    userToList.Email = user.Email;
                    userToList.Role = user.Name;
                    string userName = user.UserName;
                    string[] splitName = userName.Split(' ');
                    userToList.FirstName = splitName[0];
                    if (splitName.Length > 1)
                    {
                        userToList.LastName = splitName[1];
                    }

                    users.Add(userToList);

                }
            }

            return users;
        }

        public User GetUserById(string id)
        {
            User user = new User();

            using (_ctx = new GuildCarsEntities())
            {
                try
                {

                    var getUser = _ctx.GetUserById(id).FirstOrDefault();

                    user.UserId = getUser.Id;
                    string userName = getUser.UserName;
                    string[] splitName = userName.Split(' ');
                    user.FirstName = splitName[0];
                    if (splitName[1] != null)
                    {
                        user.LastName = splitName[1];
                    }
                    user.Email = getUser.Email;
                    user.Role = getUser.Name;
                    user.Password = getUser.PasswordHash;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return user;
        }

        public List<Models.Tables.CarModel> GetCarModelsByMakeId(int id)
        {
            //Need to implement this.
            List<Models.Tables.CarModel> newModels = new List<Models.Tables.CarModel>();

            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    var modelList = _ctx.GetCarModelsByMakeId(id);

                    foreach(var mdl in modelList)
                    {
                        Models.Tables.CarModel model = new Models.Tables.CarModel();

                        model.CarModelId = mdl.CarModelId;
                        model.ModelName = mdl.ModelName;

                        newModels.Add(model);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return newModels;
        }

        public List<Roles> GetAllRoles()
        {
            List<Roles> roles = new List<Roles>();

            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    var list = _ctx.GetAllRoles();

                    foreach(var role in list)
                    {
                        Roles addRole = new Roles();

                        addRole.RoleId = role.Id;
                        addRole.RoleName = role.Name;

                        roles.Add(addRole);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return roles;
        }
    }
}
