using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repos.Mock
{
    public class VehicleRepoMock : IVehicleRepo
    {
        private List<Vehicle> _cars = new List<Vehicle>();
        private Vehicle car1 = new Vehicle();
        private List<Models.Tables.Special> _specials = new List<Models.Tables.Special>();
        private Models.Tables.Special special1 = new Models.Tables.Special();
        private Models.Tables.Special special2 = new Models.Tables.Special();
        private List<GetBodyStyle> _bodyStyles = new List<GetBodyStyle>();
        private GetBodyStyle style1 = new GetBodyStyle();
        private GetBodyStyle style2 = new GetBodyStyle();
        private List<GetCarMake> _makes = new List<GetCarMake>();
        private GetCarMake make1 = new GetCarMake();
        private GetCarMake make2 = new GetCarMake();
        private List<GetCarModel> _models = new List<GetCarModel>();
        private GetCarModel model1 = new GetCarModel();
        private GetCarModel model2 = new GetCarModel();
        private List<GetColor> _colors = new List<GetColor>();
        private GetColor color1 = new GetColor();
        private List<GetInterior> _interior = new List<GetInterior>();
        private GetInterior interior1 = new GetInterior();

        public VehicleRepoMock()
        {
            car1.CarId = 1;
            car1.Year = 2019;
            car1.CarMakeId = 1;
            car1.CarModelId = 1;
            car1.CarTypeId = 1;
            car1.BodyStyleId = 1;
            car1.TransmissionId = 1;
            car1.ColorId = 1;
            car1.InteriorId = 1;
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
            _specials.Add(special1);
            _specials.Add(special2);

            style1.BodyStyleId = 0;
            style1.BodyStyleName = "Car";
            style2.BodyStyleId = 1;
            style2.BodyStyleName = "Truck";
            _bodyStyles.Add(style1);
            _bodyStyles.Add(style2);

            make1.CarMakeId = 0;
            make1.MakeName = "Toyota";
            make1.DateAdded = DateTime.Today;
            make1.UserId = "1-1";
            make2.CarMakeId = 1;
            make2.MakeName = "Honda";
            make2.DateAdded = DateTime.Today;
            make2.UserId = "2-2";
            _makes.Add(make1);
            _makes.Add(make2);

            model1.CarModelId = 0;
            model1.CarMakeId = 0;
            model1.ModelName = "Corolla";
            model1.DateAdded = DateTime.Today;
            model1.CarModelId = 1;
            model2.CarMakeId = 1;
            model2.ModelName = "Civic";
            model2.DateAdded = DateTime.Today;
            _models.Add(model1);
            _models.Add(model2);

            color1.ColorId = 0;
            color1.ColorName = "Black";
            _colors.Add(color1);

            interior1.InteriorId = 0;
            interior1.InteriorName = "Black";
            _interior.Add(interior1);

        }

        public int AddVehicle(Vehicle addCar)
        {
            _cars.Add(addCar);
            return addCar.CarId;
        }

        public void DeleteVehicle(int id)
        {
            _cars.Remove(_cars.FirstOrDefault(v => v.CarId == id));
        }

        public void EditVehicle(Vehicle editCar)
        {
            int x = _cars.IndexOf(_cars.FirstOrDefault(v => v.CarId == editCar.CarId));
            _cars[x].CarModelId = editCar.CarModelId;
            _cars[x].BodyStyleId = editCar.BodyStyleId;
            _cars[x].ColorId = editCar.ColorId;
            _cars[x].CarDescription = editCar.CarDescription;
            _cars[x].IsFeatured = editCar.IsFeatured;
            _cars[x].IsPurchased = editCar.IsPurchased;
            _cars[x].InteriorId = editCar.InteriorId;
            _cars[x].CarMakeId = editCar.CarMakeId;
            _cars[x].CarModelId = editCar.CarModelId;
            _cars[x].Mileage = editCar.Mileage;
            _cars[x].MSRP = editCar.MSRP;
            _cars[x].SalePrice = editCar.SalePrice;
            _cars[x].TransmissionId = editCar.TransmissionId;
            _cars[x].Year = editCar.Year;
        }

        public Vehicle GetAllByCarId(int id)
        {
            return _cars.Find(c => c.CarId == id);
        }

        public List<GetSpecials> GetAllSpecials()
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

        public List<GetBodyStyle> GetBodyStyle()
        {
            return _bodyStyles;
        }

        public List<GetCarMake> GetCarMake()
        {
            return _makes;
        }

        public List<GetCarModel> GetCarModel()
        {
            return _models;
        }

        public List<GetCarType> GetCarType()
        {
            throw new NotImplementedException();
        }

        public List<GetColor> GetColor()
        {
            return _colors;
        }

        public List<GetInterior> GetInterior()
        {
            return _interior;
        }

        public List<GetTransmission> GetTransmission()
        {
            throw new NotImplementedException();
        }

        public void SaveImageToCar(int id, string image)
        {
            if (!string.IsNullOrEmpty(image))
            {
                var saveToCar = _cars.Find(c => c.CarId == id);
                saveToCar.ImageFileName.Replace(saveToCar.ImageFileName, image);
            }
        }
    }
}
