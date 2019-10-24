using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IAdminRepo
    {
        List<Models.Tables.CarView> AllCarSearch(InventorySearchParameters parameters);
        List<Models.Tables.CarMake> GetCarMakesWUsers();
        IEnumerable<Models.Tables.CarModelView> GetCarModelsWUsers();
        List<Models.Tables.Special> GetAllSpecials();
        List<Models.Tables.CarModel> GetCarModelsByMakeId(int id);
        void AddSpecial(Models.Tables.Special special);
        void AddMake(Models.Tables.CarMake carMake);
        void AddModel(Models.Tables.CarModelView carModel);
        void DeleteSpecial(int id);
        List<User> GetAllUsers();
        List<Roles> GetAllRoles();
        User GetUserById(string id);
    }
}
