using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class CarModelView
    {
        public int CarModelId { get; set; }
        public int CarMakeId { get; set; }
        public string CarMakeName { get; set; }
        public string ModelName { get; set; }
        public string User { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
