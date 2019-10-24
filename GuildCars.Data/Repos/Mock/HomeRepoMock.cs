using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repos.Mock
{
    public class HomeRepoMock : IHomeRepo
    {
        List<Models.Tables.CarView> _cars = new List<Models.Tables.CarView>();
        List<Models.Tables.Special> _specials = new List<Models.Tables.Special>();
        List<Models.Tables.ContactUs> _contact = new List<Models.Tables.ContactUs>();

        Models.Tables.CarView car1 = new Models.Tables.CarView();

        Models.Tables.Special special1 = new Models.Tables.Special();
        Models.Tables.Special special2 = new Models.Tables.Special();

        public HomeRepoMock()
        {
            car1.CarId = 1;
            car1.Year = 2019;
            car1.MakeName = "Toyota";
            car1.ModelName = "Camery";
            car1.TypeName = "New";
            car1.BodyStyleName = "Car";
            car1.TransmissionName = "Automatic";
            car1.ColorName = "Black";
            car1.InteriorName = "Black";
            car1.Mileage = 250;
            car1.VINnumber = "1HGBH41JXMN109186";
            car1.SalePrice = 28000;
            car1.MSRP = 9000;
            car1.CarDescription = "This car is a nice car!";
            car1.ImageFileName = "car2.jpg";
            car1.IsFeatured = true;
            car1.IsPurchased = false;

            _cars.Add(car1);

            special1.SpecialId = 0;
            special1.SpecialTitle = "This is a special";
            special1.SpecialDescription = "Like I said, this is a special";

            special2.SpecialId = 0;
            special2.SpecialTitle = "This is another special";
            special2.SpecialDescription = "Like I said, this is another special";

            _specials.Add(special2);
        }
        
        public void AddContact(Models.Tables.ContactUs contactInfo)
        {
            _contact.Add(contactInfo);              
        }

        public IEnumerable<GetHomePage> GetHomePage()
        {
            List<GetHomePage> cars = new List<GetHomePage>();

            if (car1.IsFeatured == true)
            {
                GetHomePage hp = new GetHomePage();

                hp.CarId = car1.CarId;
                hp.Year = car1.Year;
                hp.MakeName = car1.MakeName;
                hp.ModelName = car1.ModelName;
                hp.SalePrice = car1.SalePrice;
                hp.ImageFileName = car1.ImageFileName;

                hp.SpecialId = special1.SpecialId;
                hp.SpecialTitle = special1.SpecialTitle;
                hp.SpecialDescription = special1.SpecialDescription;

                cars.Add(hp);
            }
            return cars;
        }

        public IEnumerable<GetSpecials> GetSpecials()
        {
            List<GetSpecials> specials = new List<GetSpecials>();
            GetSpecials hp = new GetSpecials();

            foreach (var spec in specials)
            {
                spec.SpecialId = hp.SpecialId;
                spec.SpecialTitle = hp.SpecialTitle;
                spec.SpecialDescription = hp.SpecialDescription;

                specials.Add(spec);

            }

            return specials;
        }
    }
}
