using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tasks.DAL.Models
{
    public class NoNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string strValue = value.ToString();
                if (Regex.IsMatch(strValue, @"\d"))
                {
                    return new ValidationResult("Course name should not contain numbers.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
