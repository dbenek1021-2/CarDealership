using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mapper
{
    public class MakeView
    {
        public static Models.Tables.CarMake Make(CarMake makeList)
        {
            Models.Tables.CarMake make = new Models.Tables.CarMake();

            make.CarMakeId = makeList.CarMakeId;
            make.MakeName = makeList.MakeName;
            make.DateAdded = makeList.DateAdded;
            make.User = makeList.User;

            return make;
        }
    }
}
