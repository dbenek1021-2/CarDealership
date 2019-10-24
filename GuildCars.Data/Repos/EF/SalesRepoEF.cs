using GuildCars.Data.Interfaces;
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
    public class SalesRepoEF : ISalesRepo
    {
        private GuildCarsEntities _ctx;

        public SalesRepoEF()
        {
            _ctx = new GuildCarsEntities();
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

        public CarView GetDetails(int carId)
        {
            var carDetails = new CarView();

            using (_ctx)
            {
                var dbDetails = _ctx.GetAllByCarId(carId).FirstOrDefault();

                if (!string.IsNullOrEmpty(dbDetails.ToString()))
                {
                    carDetails = VehicleView.Car(dbDetails);
                }
            }
            return carDetails;
        }

        public List<GetPurchaseType> GetPurchaseType()
        {
            List<GetPurchaseType> purchaseTypeList = new List<GetPurchaseType>();

            using (_ctx)
            {
                var purchaseTypes = _ctx.GetPurchaseType();

                foreach (var type in purchaseTypes)
                {
                    GetPurchaseType s = new GetPurchaseType();

                    s.PurchaseTypeId = type.PurchaseTypeId;
                    s.PurchaseTypeName = type.PurchaseTypeName;

                    purchaseTypeList.Add(s);
                }

            }
            return purchaseTypeList;
        }

        public List<States> GetStates()
        {
            List<States> statesList = new List<States>();

            using (_ctx)
            {
                var states = _ctx.GetStates();

                foreach (var state in states)
                {
                    States s = new States();

                    s.StateId = state.StateId;
                    s.StateName = state.StateName;

                    statesList.Add(s);
                }

            }
            return statesList;
        }

        public void SubmitPurchase(PurchaseVehicle p)
        {
            using (_ctx)
            {
                try
                {
                    var newPurchase = _ctx.PurchaseVehicle(p.CarId, p.Name, p.Address1, p.Address2, p.City, p.StateId, p.Zipcode, p.Phone, p.Email, p.IsPurchased, p.PurchasePrice, p.PurchaseTypeId, p.SalesPerson, p.DatePurchasaed);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
