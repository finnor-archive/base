using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace BankAccountManagement.Models
{
    public class ZipCodeValidator
    {
        static Regex zipCodeRegex = new Regex(@"\d{5}");                 //zip code is any 5 digits

        public static bool IsValidNumber (String zipCode)
        {
            return zipCodeRegex.IsMatch(zipCode);
        }
    }
}