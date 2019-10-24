using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepo
    {
        List<GetCarMake> GetCarMake();
        List<GetCarModel> GetCarModel();
        List<GetSpecials> GetAllSpecials();
        List<GetCarType> GetCarType();
        List<GetBodyStyle> GetBodyStyle();
        List<GetTransmission> GetTransmission();
        List<GetColor> GetColor();
        List<GetInterior> GetInterior();
        int AddVehicle(Vehicle addCar);
        void EditVehicle(Vehicle editCar);
        void DeleteVehicle(int id);
        void SaveImageToCar(int id, string image);
        Vehicle GetAllByCarId(int id);
    }
}
