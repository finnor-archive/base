using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace BankAccountManagement.Models
{
    public class RoutingNumberValidator
    {
        static Regex routingNumberRegex = new Regex(@"\d{9}");           //routing number is any nine digits

        public static bool IsValidNumber (String otherPartyRoutingNumber)
        {
            return routingNumberRegex.IsMatch(otherPartyRoutingNumber);
        }
    }
}