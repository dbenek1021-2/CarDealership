using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Mapper
{
    public class VehicleView
    {
        public static CarView Car(GuildCars.Data.Car dbList)
        {
            Tables.CarView car = new Tables.CarView();
            car.CarId = dbList.CarId;
            car.Year = dbList.Year;
            car.MakeName = dbList.CarMake.MakeName;
            car.ModelName = dbList.CarModel.ModelName;
            car.TypeName = dbList.CarType.TypeName;
            car.BodyStyleName = dbList.BodyStyle.BodyStyleName;
            car.TransmissionName = dbList.Transmission.TransmissionName;
            car.ColorName = dbList.Color.ColorName;
            car.InteriorName = dbList.Interior.InteriorName;
            car.Mileage = dbList.Mileage;
            car.VINnumber = dbList.VINnumber;
            car.SalePrice = dbList.SalePrice;
            car.MSRP = dbList.MSRP;
            car.CarDescription = dbList.CarDescription;
            car.ImageFileName = dbList.ImageFileName;
            car.IsFeatured = dbList.IsFeatured;
            car.IsPurchased = dbList.IsPurchased;

            return car;
        }

    }
}
