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
    public class SalesFactory
    {
        public static ISalesRepo GetRepo()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new SalesRepoMock();
                case "PROD":
                    return new SalesRepoEF();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
