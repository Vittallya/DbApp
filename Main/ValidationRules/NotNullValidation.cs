using System.Globalization;
using System.Windows.Controls;

namespace Main.ValidationRules;

public class NotNullValidation : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if(value != null && value.ToString().Length > 0)
        {
            return ValidationResult.ValidResult;
        }

        return new ValidationResult(false, "Поле должно быть заполнено");
    }
}
