using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class InventoryReport
    {
        public int Year { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int? Count { get; set; }
        public decimal? StockValue { get; set; }
    }
}
