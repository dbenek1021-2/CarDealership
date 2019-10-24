using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class PurchaseViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> PurchaseType { get; set; }
        public Tables.CarView Car { get; set; }
        public Tables.Customer Customer { get; set; }
        public Tables.Purchase Purchase { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Customer.Email) && string.IsNullOrEmpty(Customer.Phone))
            {
                errors.Add(new ValidationResult("Email and/or Phone is required"));
            }

            if (!string.IsNullOrEmpty(Customer.Email) && !Regex.Match(Customer.Email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$").Success)
            {
                errors.Add(new ValidationResult("Please enter a valid email"));
            }

            if (!string.IsNullOrEmpty(Customer.Phone) && !Regex.Match(Customer.Phone, @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$").Success)
            {
                errors.Add(new ValidationResult("Please enter a valid phone number"));
            }

            if (string.IsNullOrEmpty(Customer.Address2))
            {
                Customer.Address2 = "";
            }

            if (string.IsNullOrEmpty(Customer.Name))
            {
                errors.Add(new ValidationResult("Name is required"));
            }

            if (string.IsNullOrEmpty(Customer.Address1))
            {
                errors.Add(new ValidationResult("Street address is required"));
            }

            if (string.IsNullOrEmpty(Customer.City))
            {
                errors.Add(new ValidationResult("City is required"));
            }

            if (string.IsNullOrEmpty(Customer.StateId))
            {
                errors.Add(new ValidationResult("State is required"));
            }

            if (string.IsNullOrEmpty(Customer.Zipcode.ToString()) || !Regex.Match(Customer.Zipcode.ToString(), @"^\d{5}(?:[-\s]\d{4})?$").Success)
            {
                errors.Add(new ValidationResult("Please enter a valid zipcode"));
            }

            if (string.IsNullOrEmpty(Purchase.PurchasePrice.ToString()))
            {
                errors.Add(new ValidationResult("Purchase price is required"));
            }

            if (Purchase.PurchasePrice > Car.MSRP || Purchase.PurchasePrice < (Car.SalePrice * 95)/100)
            {
                errors.Add(new ValidationResult("Purchase price can not exceed MSRP and at least 95% of the price is required for purchase"));
            }

            if (string.IsNullOrEmpty(Purchase.PurchaseTypeID.ToString()))
            {
                errors.Add(new ValidationResult("Purchase type is required"));
            }

            return errors;
        }
    }
}