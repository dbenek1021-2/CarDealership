using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IInventoryRepo
    {
        List<Models.Tables.CarView> NewCarSearch(InventorySearchParameters parameters);
        List<Models.Tables.CarView> UsedCarSearch(InventorySearchParameters parameters);
        Models.Tables.CarView GetDetails(int carId);
    }
}
