using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class UserViewModel : IValidatableObject
    {
        public Tables.User User { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(User.FirstName))
            {
                errors.Add(new ValidationResult("Please enter a first name"));
            }

            if (string.IsNullOrEmpty(User.LastName))
            {
                errors.Add(new ValidationResult("Please enter a last name"));
            }

            if (string.IsNullOrEmpty(User.Role))
            {
                errors.Add(new ValidationResult("Please select a role"));
            }

            return errors;
        }
    }
}