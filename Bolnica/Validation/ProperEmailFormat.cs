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
    public class ProperEmailFormat : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var email = value as string;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if(email.Length == 0)
                    return new ValidationResult(false, null);
                else if (match.Success)
                    return new ValidationResult(true, null);
                else
                    return new ValidationResult(false, "Pogrešan email format. (Pokusajte sa examlpe@gmail.com)");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
