using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfAppEditeur
{
    class CValidateByRegex
    {
        public static bool ValidateByRegexIsMatch(string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
        public static bool IsAdressIpv4(string AdressIpv4)
        {
            return ValidateByRegexIsMatch(AdressIpv4, @"^(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}$");
        }
        public static bool IsPortNumber(string PortNumber)
        {
            return ValidateByRegexIsMatch(PortNumber, @"(^\d{1,4}$)|((^[1-5][0-9][0-9][0-9][0-9]$|^6[0-4][0-9][0-9][0-9]$)|(^65[0-4][0-9][0-9]$)| (^655[0-2][0-9]$)|(^6553[0-5]$))");
        }
    }
}
