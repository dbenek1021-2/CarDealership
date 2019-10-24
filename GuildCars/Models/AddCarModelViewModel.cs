using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class AddCarModelViewModel
    {
        public IEnumerable<Tables.CarModelView> CarModelViewList { get; set; }
        public List<GetCarMake> CarMakeList { get; set; }
    }
}