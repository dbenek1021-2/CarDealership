using GuildCars.Data.Interfaces;
using GuildCars.Data.Repos.EF;
using GuildCars.Data.Repos.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class VehicleFactory
    {
        public static IVehicleRepo GetRepo()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new VehicleRepoMock();
                case "PROD":
                    return new VehicleRepoEF();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
