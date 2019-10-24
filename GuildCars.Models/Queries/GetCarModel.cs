using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class GetCarModel
    {
        public int CarModelId { get; set; }
        public int CarMakeId { get; set; }
        public string ModelName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
