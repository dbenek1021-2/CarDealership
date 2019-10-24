using GuildCars.Data.Interfaces;
using GuildCars.Data.Mapper;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repos.Mock
{
    public class AdminRepoMock : IAdminRepo
    {
        private List<CarView> _testVehicleList;
        private List<Models.Tables.CarMake> _makeList = new List<Models.Tables.CarMake>();
        private List<Models.Tables.CarModelView> _modelList = new List<Models.Tables.CarModelView>();
        private List<Models.Tables.Special> _specials = new List<Models.Tables.Special>();
        private List<Models.Tables.User> _users = new List<User>();
        private List<Models.Tables.Roles> _roles = new List<Roles>();

        public AdminRepoMock()
        {
            if (_testVehicleList == null)
            {
                _testVehicleList = new List<CarView>()
                {
                    new CarView(){CarId = 1, Year = 2016, ImageFileName = "", MakeName= "Toyota", ModelName = "Camry", SalePrice = 21000, Mileage = 500,  BodyStyleName = "Car", ColorName = "Black", CarDescription="Blah It's a toyota", IsFeatured = false, IsPurchased=false, MSRP = 23000, TransmissionName = "Automatic", VINnumber = "1C4NJPBA0CD722387"},
                    new CarView(){CarId = 2, Year = 2018, ImageFileName = "", MakeName= "Honda", ModelName = "Accord", SalePrice = 22000, Mileage = 1300,  BodyStyleName = "Car", ColorName = "Black", CarDescription="Blah It's a honda", IsFeatured = false, IsPurchased=false, MSRP = 23000, TransmissionName = "Automatic", VINnumber = "1C4NJPBA0CD722388"},
                };
            }

            if (_makeList == null)
            {
                _makeList = new List<Models.Tables.CarMake>();
                Models.Tables.CarMake make1 = new Models.Tables.CarMake();
                Models.Tables.CarMake make2 = new Models.Tables.CarMake();

                make1.CarMakeId = 1;
                make1.MakeName = "Toyota";
                make1.User = "00000000-0000-0000-0000-000000000000";
                make1.DateAdded = DateTime.Now.Date;

                make2.CarMakeId = 2;
                make2.MakeName = "Honda";
                make2.User = "00000000-0000-0000-0000-000000000000";
                make2.DateAdded = DateTime.Now.Date;

                _makeList.Add(make1);
                _makeList.Add(make2);
            }
            if (_modelList == null)
            {
                _modelList = new List<Models.Tables.CarModelView>();
                Models.Tables.CarModelView model1 = new Models.Tables.CarModelView();
                Models.Tables.CarModelView model2 = new Models.Tables.CarModelView();

                model1.CarModelId = 1;
                model1.ModelName = "Camery";
                model1.CarMakeName = "Toyota";
                model1.User = "00000000-0000-0000-0000-000000000000";
                model1.DateAdded = DateTime.Now.Date;

                model2.CarModelId = 2;
                model2.ModelName = "Fit";
                model2.CarMakeName = "Honda";
                model2.User = "00000000-0000-0000-0000-000000000000";
                model2.DateAdded = DateTime.Now.Date;

                _modelList.Add(model1);
                _modelList.Add(model2);
            }

            if (_specials == null)
            {
                Models.Tables.Special special1 = new Models.Tables.Special();
                Models.Tables.Special special2 = new Models.Tables.Special();
                special1.SpecialId = 0;
                special1.SpecialTitle = "This is a special";
                special1.SpecialDescription = "Like I said, this is a special";

                special2.SpecialId = 0;
                special2.SpecialTitle = "This is another special";
                special2.SpecialDescription = "Like I said, this is another special";

                _specials.Add(special2);
            }
        }

        public void AddMake(Models.Tables.CarMake carMake)
        {
            _makeList.Add(carMake);
        }

        public void AddModel(Models.Tables.CarModelView carModel)
        {
            _modelList.Add(carModel);
        }

        public void AddSpecial(Models.Tables.Special special)
        {
            _specials.Add(special);
        }

        public List<CarView> AllCarSearch(InventorySearchParameters parameters)
        {
            return _testVehicleList;
        }

        public void DeleteSpecial(int id)
        {
            _specials.Remove(_specials.First(s => s.SpecialId == id));
        }

        public List<Roles> GetAllRoles()
        {
            return _roles;
        }

        public List<Models.Tables.Special> GetAllSpecials()
        {
            return _specials;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public List<Models.Tables.CarMake> GetCarMakesWUsers()
        {
            return _makeList;
        }

        public List<Models.Tables.CarModel> GetCarModelsByMakeId(int id)
        {
            List<Models.Tables.CarModel> newModel = new List<Models.Tables.CarModel>();
            var model = _modelList.Where(m => m.CarModelId == id);
            
            return newModel;
        }

        public IEnumerable<CarModelView> GetCarModelsWUsers()
        {
            var list = new List<CarModelView>();

            foreach (var model in _modelList)
            {
                CarModelView view = new CarModelView();

                view.CarModelId = model.CarModelId;
                view.ModelName = model.ModelName;
                view.User = model.User;
                view.DateAdded = model.DateAdded;
            }

            return list;
        }

        public User GetUserById(string id)
        {
            var user = _users.Where(u => u.UserId == id).FirstOrDefault();
            return user;
        }
    }
}
