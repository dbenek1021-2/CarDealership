using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class CarMake
    {
        public int CarMakeId { get; set; }
        public string MakeName { get; set; }
        public string User { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
