using GuildCars.Data;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Repos.ADO;
using GuildCars.Data.Repos.EF;
using GuildCars.Data.Repos.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class HomeFactory
    {
        public static IHomeRepo GetRepo()
        {
            switch(Settings.GetRepositoryType())
            {
                case "QA":
                    return new HomeRepoMock();
                case "ADO":
                    return new HomeRepoADO();
                case "PROD":
                    return new HomeRepoEF();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
