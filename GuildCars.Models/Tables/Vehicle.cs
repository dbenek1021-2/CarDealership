using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicle
    {
        public int CarId { get; set; }
        public int Year { get; set; }
        public int CarMakeId { get; set; }
        public int CarModelId { get; set; }
        public int CarTypeId { get; set; }
        public int BodyStyleId { get; set; }
        public int TransmissionId { get; set; }
        public int ColorId { get; set; }
        public int InteriorId { get; set; }
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
