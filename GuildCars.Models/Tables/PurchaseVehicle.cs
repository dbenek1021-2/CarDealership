using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class PurchaseVehicle
    {
        public int PurchaseId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        public int Zipcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? IsPurchased { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeId { get; set; }
        public string PurchaseType { get; set; }
        public string SalesPerson { get; set; }
        public DateTime? DatePurchasaed { get; set; }
    }
}
