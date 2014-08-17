using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAccountManagement.Models
{
    public class RuleViolation
    {
        public String ErrorMessage
        {
            get;
            private set;
        }

        public String PropertyName
        {
            get;
            private set;
        }

        public RuleViolation(String errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public RuleViolation(String errorMessage, String propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}