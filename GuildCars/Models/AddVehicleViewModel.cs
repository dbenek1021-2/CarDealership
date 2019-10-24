using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class AddVehicleViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> CarMakeList { get; set; }
        public IEnumerable<SelectListItem> CarModelList { get; set; }
        public IEnumerable<SelectListItem> CarTypeList { get; set; }
        public IEnumerable<SelectListItem> BodyStyleList { get; set; }
        public IEnumerable<SelectListItem> TransmissionList { get; set; }
        public IEnumerable<SelectListItem> ColorList { get; set; }
        public IEnumerable<SelectListItem> InteriorList { get; set; }
        public Tables.CarView CarView { get; set; }
        public Tables.CarMake carMakeModel { get; set; }
        public Tables.CarModel carModelModel { get; set; }
        public Tables.CarType carTypeModel { get; set; }
        public Tables.BodyStyle bodyStyleModel { get; set; }
        public Tables.Transmission transmissionModel { get; set; }
        public Tables.Color colorModel { get; set; }
        public Tables.Interior interiorModel { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            var curYr = DateTime.Now.Year;
            var curYrPlusOne = DateTime.Now.Year + 1;

            if (string.IsNullOrEmpty(CarView.CarDescription))
            {
                errors.Add(new ValidationResult("Please enter a car description"));
            }

            if (string.IsNullOrEmpty(CarView.SalePrice.ToString()))
            {
                errors.Add(new ValidationResult("Please enter a sale price"));
            }

            if (CarView.SalePrice.ToString().Contains('$'))
            {
                int.Parse(CarView.SalePrice.ToString().Remove('$'));
            }

            if (CarView.SalePrice.ToString().Contains(','))
            {
                int.Parse(CarView.SalePrice.ToString().Remove(','));
            }

            if (string.IsNullOrEmpty(CarView.SalePrice.ToString()))
            {
                errors.Add(new ValidationResult("Please enter a sale price"));
            }

            if (!Regex.Match(CarView.Year.ToString(), @"^\d{4}$").Success || !(CarView.Year <= curYrPlusOne) && !(CarView.Year >= 2000))
            {
                errors.Add(new ValidationResult("Please enter a valid year"));
            }

            if (carTypeModel.TypeId == 1 && !(CarView.Mileage <= 1000))
            {
                errors.Add(new ValidationResult("A new car can not have a mileage over 1,000"));
            }

            if (carTypeModel.TypeId == 2 && !(CarView.Mileage > 1000))
            {
                errors.Add(new ValidationResult("A used car must have a mileage over 1,000"));
            }

            if (string.IsNullOrEmpty(CarView.VINnumber))
            {
                errors.Add(new ValidationResult("Please enter a VIN number"));
            }

            if (!string.IsNullOrEmpty(CarView.VINnumber) && !Regex.Match(CarView.VINnumber, @"^(?=.*[0-9])(?=.*[A-z])[0-9A-z-]{17}$").Success)
            {
                errors.Add(new ValidationResult("Please enter a valid VIN vumber"));
            }

            if (CarView.MSRP <= 0)
            {
                errors.Add(new ValidationResult("Please enter a valid MSRP"));
            }

            if (CarView.SalePrice > CarView.MSRP)
            {
                errors.Add(new ValidationResult("Sale price can not be greater than MSRP)"));
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, or jpeg."));
                }
            }
            else
            {
                errors.Add(new ValidationResult("Image file is required"));
            }

            return errors;
        }
        
    }
}