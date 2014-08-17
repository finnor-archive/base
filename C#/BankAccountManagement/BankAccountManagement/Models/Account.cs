using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;

namespace BankAccountManagement.Models
{
    public partial class Account
    {
        public bool IsValid
        {
            get
            {
                return (GetRuleViolations().Count() == 0);
            }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {           
            if (String.IsNullOrEmpty(Last_Name))                                                        //validate Last Name
                yield return new RuleViolation("The Last Name is required", "Last_Name");
            
            if (String.IsNullOrEmpty(First_Name) )                                                       //validate First Name
                yield return new RuleViolation("The First Name is required", "First_Name");
            
            if (String.IsNullOrEmpty(Address))                                                          //validate Address
                yield return new RuleViolation("The Address is required", "Address");
            
            if (String.IsNullOrEmpty(City))                                                             //validate City
                yield return new RuleViolation("The City is required", "City");
            
            if (String.IsNullOrEmpty(State))                                                            //validate State
                yield return new RuleViolation("The State is required", "State");
            
            if (String.IsNullOrEmpty(Zip))                                                              //validate Zip Code
                yield return new RuleViolation("The Zip Code is required", "Zip");
            if (!ZipCodeValidator.IsValidNumber(Zip))
                yield return new RuleViolation("The Zip Code is invalid", "Zip");

            //not validated Account Number
            //not validated Balance
            //not validated Overdraftable
            //not validated Overraft Amount
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Invalid Transaction");
        }
    }
}