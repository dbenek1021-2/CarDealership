using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mapper
{
    public class ModelView
    {
        public static Models.Tables.CarModelView Model(CarModel modelList)
        {
            Models.Tables.CarModelView model = new Models.Tables.CarModelView();
            model.CarModelId = modelList.CarModelId;
            model.ModelName = modelList.ModelName;
            model.CarMakeName = modelList.CarMake.MakeName;
            model.DateAdded = modelList.DateAdded;
            model.User = modelList.User;

            return model;
        }
    }
}
