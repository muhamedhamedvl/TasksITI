using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Task1.Models
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
