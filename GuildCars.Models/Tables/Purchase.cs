using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int CarId { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeID { get; set; }
        public string SalesPerson { get; set; }
        public DateTime DatePurchased { get; set; }
    }
}
