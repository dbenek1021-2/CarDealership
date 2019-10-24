using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repos.Mock
{
    public class SalesRepoMock : ISalesRepo
    {
        private List<CarView> _testVehicleList;
        private List<PurchaseVehicle> _testPurchaseList = new List<PurchaseVehicle>();
        private List<States> _states = new List<States>();
        private States state1 = new States();
        private States state2 = new States();
        private List<GetPurchaseType> _list = new List<GetPurchaseType>();

        public SalesRepoMock()
        {
            if (_testVehicleList == null)
            {
                _testVehicleList = new List<CarView>()
                {
                    new CarView(){CarId = 1, Year = 2016, ImageFileName = "", MakeName= "Toyota", ModelName = "Camry", SalePrice = 21000, Mileage = 500,  BodyStyleName = "Car", ColorName = "Black", CarDescription="Blah It's a toyota", IsFeatured = false, IsPurchased=false, MSRP = 23000, TransmissionName = "Automatic", VINnumber = "1C4NJPBA0CD722387"},
                    new CarView(){CarId = 2, Year = 2018, ImageFileName = "", MakeName= "Honda", ModelName = "Accord", SalePrice = 22000, Mileage = 1300,  BodyStyleName = "Car", ColorName = "Black", CarDescription="Blah It's a honda", IsFeatured = false, IsPurchased=false, MSRP = 23000, TransmissionName = "Automatic", VINnumber = "1C4NJPBA0CD722388"},
                };
            }
            if (_testPurchaseList == null)
            {
                _testPurchaseList = new List<PurchaseVehicle>()
                {
                    new PurchaseVehicle(){PurchaseId = 1, CarId = 1, CustomerId = 1, Name = "John Doe", Address1 = "123 Main St", Address2 = "", City = "Akron", StateId = "OH", Zipcode = 44311, Phone = "330-555-5555", Email = "jdoe@gmail.com", IsPurchased = true, PurchasePrice = 21000, PurchaseTypeId = 1, PurchaseType = "Cash", DatePurchasaed = DateTime.Now.Date},
                    new PurchaseVehicle(){PurchaseId = 2, CarId = 2, CustomerId = 2, Name = "Jane Doe", Address1 = "456 Main St", Address2 = "", City = "Akron", StateId = "OH", Zipcode = 44311, Phone = "330-555-4444", Email = "jadoe@gmail.com", IsPurchased = true, PurchasePrice = 15000, PurchaseTypeId = 1, PurchaseType = "Bank Finance", DatePurchasaed = DateTime.Now.Date},
                };
            }

            if (_list == null)
            {
                _list = new List<GetPurchaseType>()
                {
                    new GetPurchaseType(){PurchaseTypeId = 1, PurchaseTypeName= "Bank Finance"},
                    new GetPurchaseType(){PurchaseTypeId = 2, PurchaseTypeName= "Sales"},
                    new GetPurchaseType(){PurchaseTypeId = 3, PurchaseTypeName= "Admin"}
                };
            }

            state1.StateId = "OH";
            state1.StateName = "Ohio";

            state2.StateId = "CA";
            state2.StateName = "California";

            _states.Add(state1);
            _states.Add(state2);

        }

        public List<CarView> AllCarSearch(InventorySearchParameters parameters)
        {
            return _testVehicleList;
        }

        public List<States> GetStates()
        {
            return _states;
        }

        public List<GetPurchaseType> GetPurchaseType()
        {
            return _list;
        }

        public CarView GetDetails(int carId)
        {
            return _testVehicleList.Find(c => c.CarId == carId);
        }

        public void SubmitPurchase(PurchaseVehicle purchase)
        {
            _testPurchaseList.Add(purchase);
        }
    }
}
