using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class CarView
    {
        public int CarId { get; set; }
        public int Year { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string TypeName { get; set; }
        public string BodyStyleName { get; set; }
        public string TransmissionName { get; set; }
        public string ColorName { get; set; }
        public string InteriorName { get; set; }
        public decimal Mileage { get; set; }
        public string VINnumber { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string CarDescription { get; set; }
        public string ImageFileName { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsPurchased { get; set; }
    }
}
