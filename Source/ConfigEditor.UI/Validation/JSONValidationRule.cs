using System.Globalization;
using System.Windows.Controls;

namespace ConfigEditor.UI.Validation
{
    public class JSONValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (JsonParser.ValidateJson(value?.ToString(), out var errorMessage))
            {
                return ValidationResult.ValidResult;
            }
            
            return new ValidationResult(false, errorMessage);
        }
    }
}
