using System;
using System.Globalization;
using System.Windows.Controls;

namespace Main.ValidationRules;

internal class NonNegativeRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if(value != null && int.TryParse(value.ToString(), out int valueInt))
        {
            if (int.IsNegative(valueInt))
                return new ValidationResult(false, "Значение не должно быть отрицательным");

            return ValidationResult.ValidResult;
        }

        return new ValidationResult(false, "Значение должно быть целочисленным");
    }
}
