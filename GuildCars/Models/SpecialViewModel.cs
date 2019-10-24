using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class SpecialViewModel
    {
        public Tables.Special Special { get; set; }
        public List<Tables.Special> Specials { get; set; }
    }
}