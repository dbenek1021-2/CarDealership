using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL
{
    public class GuildCarsManager
    {
        private IHomePageRepo _repo;

        public GuildCarsManager(IHomePageRepo repo)
        {
            _repo = repo;
        }


    }
}
