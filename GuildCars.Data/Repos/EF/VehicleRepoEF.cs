using GuildCars.Data.Interfaces;
using GuildCars.Models.Mapper;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using GuildCars.Data.Mapper;

namespace GuildCars.Data.Repos.EF
{
    public class VehicleRepoEF : IVehicleRepo
    {
        private GuildCarsEntities _ctx;

        public int AddVehicle(Vehicle addCar)
        {
            int id = 0;
            var test = new List<decimal?>();
            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    var newId = _ctx.AddVehicle(addCar.Year,
                                addCar.CarMakeId, addCar.CarModelId, addCar.CarTypeId, 
                                addCar.BodyStyleId, addCar.TransmissionId, addCar.ColorId, 
                                addCar.InteriorId, addCar.Mileage, addCar.VINnumber, addCar.SalePrice,
                                addCar.MSRP, addCar.CarDescription, addCar.ImageFileName, addCar.IsFeatured,
                                addCar.IsPurchased);
                    test = newId.ToList();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if(test != null && test.Count > 0)
            {
                id =  int.Parse(test[0].ToString());
            }

            return id;
        }

        public void DeleteVehicle(int id)
        {
            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    _ctx.DeleteVehicle(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void EditVehicle(Vehicle editCar)
        {
            Car newCar = new Car();
            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    _ctx.EditVehicle(editCar.CarId, editCar.Year, editCar.CarMakeId,
                        editCar.CarModelId, editCar.CarTypeId, editCar.BodyStyleId,
                        editCar.TransmissionId, editCar.ColorId, editCar.InteriorId,
                        editCar.Mileage, editCar.VINnumber, editCar.SalePrice, editCar.MSRP,
                        editCar.CarDescription, editCar.ImageFileName, editCar.IsFeatured, editCar.IsPurchased);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Vehicle GetAllByCarId(int id)
        {
            Vehicle editCar = new Vehicle();

            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    var getCar = _ctx.GetAllByCarId(id).FirstOrDefault();
                    editCar = VehicleData.Car(getCar);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return editCar;
        }

        public List<GetBodyStyle> GetBodyStyle()
        {
            List<GetBodyStyle> list = new List<GetBodyStyle>();

            using (_ctx = new GuildCarsEntities())
            {
                var bodyStyles = _ctx.GetBodyStyle();

                foreach (var style in bodyStyles)
                {
                    GetBodyStyle c = new GetBodyStyle();

                    c.BodyStyleId = style.BodyStyleId;
                    c.BodyStyleName = style.BodyStyleName;

                    list.Add(c);
                }

            }
            return list;
        }

        public List<GetCarMake> GetCarMake()
        {
            List<GetCarMake> list = new List<GetCarMake>();
            var makeView = new Models.Tables.CarMake();

            using (_ctx = new GuildCarsEntities())
            {
                var carMakes = _ctx.GetCarMake();

                foreach (var make in carMakes)
                {
                    GetCarMake c = new GetCarMake();

                    c.CarMakeId = make.CarMakeId;
                    c.DateAdded = make.DateAdded;
                    c.MakeName = make.MakeName;

                    list.Add(c);
                }

            }
            return list;
        }

        public List<GetCarModel> GetCarModel()
        {
            List<GetCarModel> list = new List<GetCarModel>();

            using (_ctx = new GuildCarsEntities())
            {
                var carModels = _ctx.GetCarModel();

                foreach (var model in carModels)
                {
                    GetCarModel c = new GetCarModel();

                    c.CarModelId = model.CarModelId;
                    c.CarMakeId = model.CarMakeId;
                    c.DateAdded = model.DateAdded;
                    c.ModelName = model.ModelName;

                    list.Add(c);
                }

            }
            return list;
        }

        public List<GetCarType> GetCarType()
        {
            List<GetCarType> list = new List<GetCarType>();

            using (_ctx = new GuildCarsEntities())
            {
                var carTypes = _ctx.GetCarType();

                foreach (var type in carTypes)
                {
                    GetCarType c = new GetCarType();

                    c.TypeId = type.TypeId;
                    c.TypeName = type.TypeName;

                    list.Add(c);
                }

            }
            return list;
        }

        public List<GetColor> GetColor()
        {
            List<GetColor> list = new List<GetColor>();

            using (_ctx = new GuildCarsEntities())
            {
                var colors = _ctx.GetColor();

                foreach (var color in colors)
                {
                    GetColor c = new GetColor();

                    c.ColorId = color.ColorId;
                    c.ColorName = color.ColorName;

                    list.Add(c);
                }

            }
            return list;
        }

        public List<GetInterior> GetInterior()
        {
            List<GetInterior> list = new List<GetInterior>();

            using (_ctx = new GuildCarsEntities())
            {
                var interiors = _ctx.GetInterior();

                foreach (var interior in interiors)
                {
                    GetInterior c = new GetInterior();

                    c.InteriorId = interior.InteriorId;
                    c.InteriorName = interior.InteriorName;

                    list.Add(c);
                }

            }
            return list;
        }

        public List<GetTransmission> GetTransmission()
        {
            List<GetTransmission> list = new List<GetTransmission>();

            using (_ctx = new GuildCarsEntities())
            {
                var trans = _ctx.GetTransmission();

                foreach (var t in trans)
                {
                    GetTransmission c = new GetTransmission();

                    c.TransmissionId = t.TransmissionId;
                    c.TransmissionName = t.TransmissionName;

                    list.Add(c);
                }

            }
            return list;
        }

        public void SaveImageToCar(int id, string image)
        {
            using (_ctx = new GuildCarsEntities())
            {
                try
                {
                    _ctx.SaveImageToCar(id, image);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<GetSpecials> GetAllSpecials()
        {
            List<GetSpecials> specials = new List<GetSpecials>();

            using (_ctx = new GuildCarsEntities())
            {
                var listOfSpecials = _ctx.GetAllSpecials();

                foreach (var s in listOfSpecials)
                {
                    GetSpecials hp = new GetSpecials();

                    hp.SpecialId = s.SpecialId;
                    hp.SpecialTitle = s.SpecialTitle;
                    hp.SpecialDescription = s.SpecialDescription;

                    specials.Add(hp);
                }
            }
            return specials;

            //throw new NotImplementedException();
        }
    }
}
