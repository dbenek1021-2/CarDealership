using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISalesRepo
    {
        List<Models.Tables.CarView> AllCarSearch(InventorySearchParameters parameters);
        Models.Tables.CarView GetDetails(int carId);
        List<States> GetStates();
        List<GetPurchaseType> GetPurchaseType();
        void SubmitPurchase(Models.Tables.PurchaseVehicle purchase);
    }
}
