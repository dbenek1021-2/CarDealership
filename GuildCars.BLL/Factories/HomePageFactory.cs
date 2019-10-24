using GuildCars.Data;
using GuildCars.Data.Interfaces;
using GuildCars.Data.Repos.EF;
using GuildCars.Data.Repos.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL.Factories
{
    public class HomePageFactory
    {
        public static IHomePageRepo GetRepo()
        {
            switch(Settings.GetRepositoryType())
            {
                case "QA":
                    return new HomePageRepoMock();
                case "PROD":
                    return new HomePageRepoEF();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
