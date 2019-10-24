using GuildCars.Data;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Repos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL.Factories
{
    public class InventoryFactory
    {
        public static IInventoryRepo GetRepo()
        {
            switch (Settings.GetRepositoryType())
            {
                //case "QA":
                //    return new HomePageRepoMock();
                case "PROD":
                    return new InventoryRepoEF();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
