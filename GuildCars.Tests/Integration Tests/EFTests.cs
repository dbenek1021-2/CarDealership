using GuildCars.Data;
using GuildCars.Data.Mapper;
using GuildCars.Data.Repos.EF;
using GuildCars.Models.Mapper;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.Integration_Tests.EFTests
{
    [TestFixture]
    public class EFTests
    {
        private GuildCarsEntities _ctx;

        public EFTests()
        {
            _ctx = new GuildCarsEntities();
        }

        [Test]
        public void GetNewInventoryTest()
        {
            InventoryRepoEF repo = new InventoryRepoEF();
            int total = 2;
            var parameters = new InventorySearchParameters()
            {
                SearchTerm = "2020 Honda Civic",
                MinPrice = null,
                MaxPrice = null,
                MinYear = null,
                MaxYear = null
            };
            var search = repo.NewCarSearch(parameters);

            var list = new List<CarView>();

            var dbList = _ctx.Cars.ToList();
            foreach (var car in dbList)
            {
                list.Add(VehicleView.Car(car));
            }

            Assert.AreEqual(total, list.Count);
        }

        [Test]
        public void GetUsedInventoryTest()
        {
            InventoryRepoEF repo = new InventoryRepoEF();
            int total = 2;
            var parameters = new InventorySearchParameters()
            {
                SearchTerm = "2012 Toyota Camry",
                MinPrice = null,
                MaxPrice = null,
                MinYear = null,
                MaxYear = null
            };
            var search = repo.NewCarSearch(parameters);

            var list = new List<CarView>();

            var dbList = _ctx.Cars.ToList();
            foreach (var car in dbList)
            {
                list.Add(VehicleView.Car(car));
            }

            Assert.AreEqual(total, list.Count);
        }

        [Test]
        public void GetCarDetailsTest()
        {
            Vehicle editCar = new Vehicle();
            VehicleRepoEF repo = new VehicleRepoEF();
            int id = 1;

            var getCar = _ctx.GetAllByCarId(id).FirstOrDefault();
            editCar = VehicleData.Car(getCar);

            Assert.AreEqual(id, editCar.CarId);
            Assert.AreEqual(2012, editCar.Year);
            Assert.AreEqual(25000, editCar.Mileage);
        }
    }
}
