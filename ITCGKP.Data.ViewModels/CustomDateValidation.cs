using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels
{
    public class CustomDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Date Field required");
            }
            else
            {
                DateTime tempDate;
                bool IsDateFormateCorrect = DateTime.TryParse(value.ToString(), out tempDate);
                if (IsDateFormateCorrect)
                {
                return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Date not in a correct format (dd/mm/yyyy).");
                }
            }             
        }
    }
}
