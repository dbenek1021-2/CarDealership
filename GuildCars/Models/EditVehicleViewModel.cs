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
    public class EditVehicleViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> CarMakeList { get; set; }
        public IEnumerable<SelectListItem> CarModelList { get; set; }
        public IEnumerable<SelectListItem> CarTypeList { get; set; }
        public IEnumerable<SelectListItem> BodyStyleList { get; set; }
        public IEnumerable<SelectListItem> TransmissionList { get; set; }
        public IEnumerable<SelectListItem> ColorList { get; set; }
        public IEnumerable<SelectListItem> InteriorList { get; set; }
        public Tables.CarView CarView { get; set; }
        public Tables.Vehicle CarWithIds { get; set; }
        public Tables.CarMake carMakeModel { get; set; }
        public Tables.CarModel carModelModel { get; set; }
        public Tables.CarType carTypeModel { get; set; }
        public Tables.BodyStyle bodyStyleModel { get; set; }
        public Tables.Transmission transmissionModel { get; set; }
        public Tables.Color colorModel { get; set; }
        public Tables.Interior interiorModel { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public bool? IsFeatured { get; set; }
        public bool noNullIsFeatured { get { return IsFeatured ?? false; } set { IsFeatured = value; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            var curYrPlusOne = DateTime.Now.Year + 1;

            if (string.IsNullOrEmpty(CarWithIds.CarDescription))
            {
                errors.Add(new ValidationResult("Please enter a car description"));
            }

            if (string.IsNullOrEmpty(CarWithIds.SalePrice.ToString()))
            {
                errors.Add(new ValidationResult("Please enter a sale price"));
            }

            if (CarWithIds.SalePrice.ToString().Contains('$'))
            {
                int.Parse(CarView.SalePrice.ToString().Remove('$'));
            }

            if (CarWithIds.SalePrice.ToString().Contains(','))
            {
                int.Parse(CarView.SalePrice.ToString().Remove(','));
            }

            if (!Regex.Match(CarWithIds.Year.ToString(), @"^\d{4}$").Success || !(CarWithIds.Year <= curYrPlusOne) && !(CarWithIds.Year >= 2000))
            {
                errors.Add(new ValidationResult("Please enter a valid year"));
            }

            if (CarWithIds.CarTypeId == 1 && !(CarWithIds.Mileage <= 1000))
            {
                errors.Add(new ValidationResult("A new car can not have a mileage over 1,000"));
            }

            if (CarWithIds.CarTypeId == 2 && !(CarWithIds.Mileage > 1000))
            {
                errors.Add(new ValidationResult("A used car must have a mileage over 1,000"));
            }

            if (string.IsNullOrEmpty(CarWithIds.VINnumber))
            {
                errors.Add(new ValidationResult("Please enter a VIN number"));
            }

            if (!string.IsNullOrEmpty(CarWithIds.VINnumber) && !Regex.Match(CarWithIds.VINnumber, @"^(?=.*[0-9])(?=.*[A-z])[0-9A-z-]{17}$").Success)
            {
                errors.Add(new ValidationResult("Please enter a valid VIN vumber"));
            }

            if (CarWithIds.MSRP <= 0)
            {
                errors.Add(new ValidationResult("Please enter a valid MSRP"));
            }

            if (CarWithIds.SalePrice > CarWithIds.MSRP)
            {
                errors.Add(new ValidationResult("Sale price can not be greater than MSRP)"));
            }

            return errors;
        }
    }
}