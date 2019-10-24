using GuildCars.Data.Interfaces;
using GuildCars.Models.Mapper;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repos.Mock
{
    public class InventoryRepoMock : IInventoryRepo
    {
        private List<Models.Tables.CarView> _testVehicleList;

        public InventoryRepoMock()
        {
            if (_testVehicleList == null)
            {
                _testVehicleList = new List<Models.Tables.CarView>()
                {
                    new Models.Tables.CarView(){CarId = 1, Year = 2016, ImageFileName = "", MakeName= "Toyota", ModelName = "Camry", SalePrice = 21000, Mileage = 500,  BodyStyleName = "Car", ColorName = "Black", CarDescription="Blah It's a toyota", IsFeatured = false, IsPurchased=false, MSRP = 23000, TransmissionName = "Automatic", VINnumber = "1C4NJPBA0CD722387"},
                    new Models.Tables.CarView(){CarId = 2, Year = 2018, ImageFileName = "", MakeName= "Honda", ModelName = "Accord", SalePrice = 22000, Mileage = 1300,  BodyStyleName = "Car", ColorName = "Black", CarDescription="Blah It's a honda", IsFeatured = false, IsPurchased=false, MSRP = 23000, TransmissionName = "Automatic", VINnumber = "1C4NJPBA0CD722388"},
                };
            }

        }

        public CarView GetDetails(int carId)
        {
            return _testVehicleList.Find(c => c.CarId == carId);
        }

        public List<Models.Tables.CarView> NewCarSearch(InventorySearchParameters parameters)
        {
            var list = new List<Models.Tables.CarView>();
            var newCars = _testVehicleList.Where(c => c.Mileage <= 10000).ToList();
            newCars = newCars.Take(20).ToList();
            foreach (var car in newCars)
            {
                list.Add(car);
            }

            return list;

        }

        public List<Models.Tables.CarView> UsedCarSearch(InventorySearchParameters parameters)
        {
            var list = new List<Models.Tables.CarView>();
            var newCars = _testVehicleList.Where(c => c.Mileage > 10000).ToList();
            newCars = newCars.Take(20).ToList();
            foreach (var car in newCars)
            {
                list.Add(car);
            }

            return list;
        }
    }
}
