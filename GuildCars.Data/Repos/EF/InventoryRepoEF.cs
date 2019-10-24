using GuildCars.Data.Interfaces;
using GuildCars.Models.Mapper;
using GuildCars.Models.Tables;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace GuildCars.Data.Repos.EF
{
    public class InventoryRepoEF : IInventoryRepo
    {
        private GuildCarsEntities _ctx;

        public InventoryRepoEF()
        {
            _ctx = new GuildCarsEntities();
        }

        public CarView GetDetails(int carId)
        {
            var carDetails = new Models.Tables.CarView();

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

        public List<CarView> NewCarSearch(InventorySearchParameters parameters)
        {
            var list = new List<CarView>();

            var dbList = _ctx.Cars.ToList();
            var newCars = dbList.Where(c => c.IsPurchased == false).ToList();
            newCars = dbList.Where(c => c.Mileage <= 1000).ToList();

            if (string.IsNullOrEmpty(parameters.SearchTerm) && parameters.MaxPrice == null && parameters.MinPrice == null && parameters.MaxYear == null && parameters.MinYear == null && parameters.SearchTerm == null)
            {
                newCars = newCars.OrderByDescending(c => c.MSRP).ToList();
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
                            newCars = newCars.Where(c =>
                               c.Year.ToString().Contains(firstTerm) ||
                               c.CarMake.MakeName.ToUpper().Contains(firstTerm.ToUpper()) ||
                               c.CarModel.ModelName.ToUpper().Contains(firstTerm.ToUpper())).ToList();
                        }
                        if (secondTerm != null)
                        {
                            newCars = newCars.Where(c =>
                               c.Year.ToString().Contains(secondTerm) ||
                               c.CarMake.MakeName.ToUpper().Contains(secondTerm.ToUpper()) ||
                               c.CarModel.ModelName.ToUpper().Contains(secondTerm.ToUpper())).ToList();
                        }
                        if (thirdTerm != null)
                        {
                            newCars = newCars.Where(c =>
                               c.Year.ToString().Contains(secondTerm) ||
                               c.CarMake.MakeName.ToUpper().Contains(secondTerm.ToUpper()) ||
                               c.CarModel.ModelName.ToUpper().Contains(secondTerm.ToUpper())).ToList();
                        }
                    }
                }
                if (!string.IsNullOrEmpty(parameters.SearchTerm) && !parameters.SearchTerm.Contains(" "))
                {                    
                    newCars = newCars.Where(c =>
                        c.Year.ToString().Contains(parameters.SearchTerm) ||
                        c.CarMake.MakeName.ToUpper().Contains(parameters.SearchTerm.ToUpper()) ||
                        c.CarModel.ModelName.ToUpper().Contains(parameters.SearchTerm.ToUpper())).ToList();

                    if (newCars.Count() == 0)
                    {
                        return list;
                    }
                    else
                    {

                    }
                }
                if (parameters.MaxPrice != null)
                {
                    newCars = newCars.Where(c => c.SalePrice < parameters.MaxPrice).ToList();
                }
                if (parameters.MinPrice != null)
                {
                    newCars = newCars.Where(c => c.SalePrice > parameters.MinPrice).ToList();
                }
                if (parameters.MaxYear != null)
                {
                    newCars = newCars.Where(c => c.Year <= parameters.MaxYear).ToList();
                }
                if (parameters.MinYear != null)
                {
                    newCars = newCars.Where(c => c.Year >= parameters.MinYear).ToList();
                }
            }

            newCars = newCars.Take(20).ToList();
            foreach (var car in newCars)
            {
                list.Add(VehicleView.Car(car));
            }

            return list;
        }

        public List<CarView> UsedCarSearch(InventorySearchParameters parameters)
        {
            var list = new List<CarView>();

            var dbList = _ctx.Cars.ToList();
            var usedCars = dbList.Where(c => c.Mileage > 1000).ToList();

            if (string.IsNullOrEmpty(parameters.SearchTerm) && parameters.MaxPrice == null && parameters.MinPrice == null && parameters.MaxYear == null && parameters.MinYear == null && parameters.SearchTerm == null)
            {
                usedCars = usedCars.OrderByDescending(c => c.MSRP).ToList();
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
                            usedCars = usedCars.Where(c =>
                               c.Year.ToString().Contains(firstTerm) ||
                               c.CarMake.MakeName.ToUpper().Contains(firstTerm.ToUpper()) ||
                               c.CarModel.ModelName.ToUpper().Contains(firstTerm.ToUpper())).ToList();
                        }
                        if (secondTerm != null)
                        {
                            usedCars = usedCars.Where(c =>
                               c.Year.ToString().Contains(secondTerm) ||
                               c.CarMake.MakeName.ToUpper().Contains(secondTerm.ToUpper()) ||
                               c.CarModel.ModelName.ToUpper().Contains(secondTerm.ToUpper())).ToList();
                        }
                        if (thirdTerm != null)
                        {
                            usedCars = usedCars.Where(c =>
                               c.Year.ToString().Contains(secondTerm) ||
                               c.CarMake.MakeName.ToUpper().Contains(secondTerm.ToUpper()) ||
                               c.CarModel.ModelName.ToUpper().Contains(secondTerm.ToUpper())).ToList();
                        }
                    }
                }
                if (!string.IsNullOrEmpty(parameters.SearchTerm) && !parameters.SearchTerm.Contains(" "))
                {
                    usedCars = usedCars.Where(c =>
                        c.Year.ToString().Contains(parameters.SearchTerm.ToUpper()) ||
                        c.CarMake.MakeName.ToUpper().Contains(parameters.SearchTerm.ToUpper()) ||
                        c.CarModel.ModelName.ToUpper().Contains(parameters.SearchTerm.ToUpper())).ToList();

                    if (usedCars.Count() == 0)
                    {
                        return list;
                    }
                    else
                    {

                    }
                }
                if (parameters.MaxPrice != null)
                {
                    usedCars = usedCars.Where(c => c.SalePrice < parameters.MaxPrice).ToList();
                }
                if (parameters.MinPrice != null)
                {
                    usedCars = usedCars.Where(c => c.SalePrice > parameters.MinPrice).ToList();
                }
                if (parameters.MaxYear != null)
                {
                    usedCars = usedCars.Where(c => c.Year <= parameters.MaxYear).ToList();
                }
                if (parameters.MinYear != null)
                {
                    usedCars = usedCars.Where(c => c.Year >= parameters.MinYear).ToList();
                }
            }

            usedCars = usedCars.Take(20).ToList();
            foreach (var car in usedCars)
            {
                list.Add(VehicleView.Car(car));
            }

            return list;
        }
    }
}
