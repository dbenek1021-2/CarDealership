using GuildCars.Data.Interfaces;
using GuildCars.Models.Mapper;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repos.EF
{
    public class HomeRepoEF : IHomeRepo
    {
        private GuildCarsEntities _ctx;

        public HomeRepoEF()
        {
            _ctx = new GuildCarsEntities();
        }

        public IEnumerable<GetHomePage> GetHomePage()
        {
            List<GetHomePage> cars = new List<GetHomePage>();

            using (_ctx)
            {
                var featuredCars = _ctx.GetAllFeatured();

                foreach (var featured in featuredCars)
                {
                    if (featured.IsPurchased != true)
                    {
                        GetHomePage hp = new GetHomePage();

                        hp.CarId = featured.CarId;
                        hp.Year = featured.Year;
                        hp.MakeName = featured.MakeName;
                        hp.ModelName = featured.ModelName;
                        hp.SalePrice = featured.SalePrice;
                        hp.ImageFileName = featured.ImageFileName;

                        cars.Add(hp);
                    }
                }

                var listOfSpecials = GetSpecials();
                foreach (var s in listOfSpecials)
                {
                    GetHomePage hp = new GetHomePage();

                    hp.SpecialId = s.SpecialId;
                    hp.SpecialTitle = s.SpecialTitle;
                    hp.SpecialDescription = s.SpecialDescription;

                    cars.Add(hp);
                }
            }
            return cars;
        }

        public IEnumerable<GetSpecials> GetSpecials()
        {
            List<GetSpecials> specials = new List<GetSpecials>();

            using (_ctx)
            {
                var listOfSpecials = _ctx.GetAllSpecials();

                foreach (var s in listOfSpecials)
                {
                    GetSpecials hp = new GetSpecials();

                    hp.SpecialId = s.SpecialId;
                    hp.SpecialTitle = s.SpecialTitle;
                    hp.SpecialDescription = s.SpecialDescription;

                    specials.Add(hp);
                }
            }
            return specials;
        }

        public void AddContact(ContactUs contact)
        {
            using (_ctx)
            {
                ContactUs info = new ContactUs();

                info.Name = contact.Name;
                info.Email = contact.Email;
                info.Phone = contact.Phone;
                info.Message = contact.Message;

                if(string.IsNullOrEmpty(info.Email) && !string.IsNullOrEmpty(info.Phone))
                {
                    info.Email = "";
                }

                if (string.IsNullOrEmpty(info.Phone) && !string.IsNullOrEmpty(info.Email))
                {
                    info.Phone = "";
                }
                _ctx.SubmitContactUs(info.Name, info.Email, info.Phone, info.Message);
            }
        }
    }
}
