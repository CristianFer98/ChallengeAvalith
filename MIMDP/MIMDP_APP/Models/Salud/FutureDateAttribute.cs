using System.ComponentModel.DataAnnotations;
using System;

namespace MIMDP_APP.Models.Salud
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime selectedDate;
                bool isValid = DateTime.TryParse(value.ToString(), out selectedDate);
                if (!isValid)
                {
                    return new ValidationResult("La fecha no es válida.");
                }

                if (selectedDate <= DateTime.Today)
                {
                    return new ValidationResult("La fecha debe ser un día futuro.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
