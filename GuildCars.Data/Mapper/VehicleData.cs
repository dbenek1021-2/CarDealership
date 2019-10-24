using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mapper
{
    public class VehicleData
    {
        public static Vehicle Car (GuildCars.Data.Car dbCar)
        {
            Vehicle car = new Vehicle();

            car.CarId = dbCar.CarId;
            car.Year = dbCar.Year;
            car.CarMakeId = dbCar.CarMake.CarMakeId;
            car.CarModelId = dbCar.CarModel.CarModelId;
            car.CarTypeId = dbCar.CarType.TypeId;
            car.BodyStyleId = dbCar.BodyStyle.BodyStyleId;
            car.TransmissionId = dbCar.Transmission.TransmissionId;
            car.ColorId = dbCar.Color.ColorId;
            car.InteriorId = dbCar.Interior.InteriorId;
            car.Mileage = dbCar.Mileage;
            car.VINnumber = dbCar.VINnumber;
            car.SalePrice = dbCar.SalePrice;
            car.MSRP = dbCar.MSRP;
            car.CarDescription = dbCar.CarDescription;
            car.ImageFileName = dbCar.ImageFileName;
            car.IsFeatured = dbCar.IsFeatured;
            car.IsPurchased = dbCar.IsPurchased;

            return car;
        }
    }
}
