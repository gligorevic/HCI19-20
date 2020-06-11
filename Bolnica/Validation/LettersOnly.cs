using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bolnica.Validation
{
    public class LettersOnly : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var word = value as string;

                if (word.Length == 0)
                    return new ValidationResult(false, null);
                else if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                    return new ValidationResult(true, null);
                else
                    return new ValidationResult(false, "Pogrešan unos, ovo polje prima samo slova.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
