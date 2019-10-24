using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class GetHomePage
    {
        public int CarId { get; set; }
        public int Year { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public decimal SalePrice { get; set; }
        public string ImageFileName { get; set; }

        public int SpecialId { get; set; }
        public string SpecialTitle { get; set; }
        public string SpecialDescription { get; set; }
    }
}
