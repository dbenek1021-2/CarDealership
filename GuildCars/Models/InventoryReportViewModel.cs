using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class InventoryReportViewModel
    {
        public List<InventoryReport> NewInventory { get; set; }
        public List<InventoryReport> UsedInventory { get; set; }
    }
}