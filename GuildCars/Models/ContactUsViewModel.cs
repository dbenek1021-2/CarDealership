using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using GuildCars.Data;

namespace GuildCars.Models
{
    public class ContactUsViewModel : IValidatableObject
    {
        public Tables.ContactUs contactUs { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(contactUs.Name))
            {
                errors.Add(new ValidationResult("Name is required"));
            }

            if (string.IsNullOrEmpty(contactUs.Email) && string.IsNullOrEmpty(contactUs.Phone))
            {
                errors.Add(new ValidationResult("Email or Phone is required"));
            }

            if (!string.IsNullOrEmpty(contactUs.Email) && !Regex.Match(contactUs.Email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$").Success)
            {
                errors.Add(new ValidationResult("Please enter a valid email"));
            }

            if (!string.IsNullOrEmpty(contactUs.Phone) && !Regex.Match(contactUs.Phone, @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$").Success)
            {
                errors.Add(new ValidationResult("Please enter a valid phone number"));
            }

            if (string.IsNullOrEmpty(contactUs.Message))
            {
                errors.Add(new ValidationResult("Message is required"));
            }

            return errors;
        }
    }
}