using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;

namespace BankAccountManagement.Models
{
    public partial class Transaction
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
            if (AccountNumber==0)                                                                       //validate Account Number
                yield return new RuleViolation("The Account Number is required", "AccountNumber");
            
            if (Decimal.Round(Amount, 2)==0)                                                            //validate Amount
                yield return new RuleViolation("The Amount is required", "Amount");

            if (OtherParty != null)                                                                     //validate Other Party
            {
                if (OtherParty.Equals(""))
                    yield return new RuleViolation("The Other Party is not set", "OtherParty");
            }

            if (OtherPartyAccount != null)                                                              //validate Other Party's Account Number
            {
                if (OtherPartyAccount.Equals(""))
                    yield return new RuleViolation("The Other Party's Account Number is required", "OtherPartyAccount");
            }

            if (OtherPartyRoutingNumber != null)                                                        //validate Other Party Routing Number
            {
                if (!RoutingNumberValidator.IsValidNumber(OtherPartyRoutingNumber))
                    yield return new RuleViolation("The Other Party's Routing Number is invalid", "OtherPartyRoutingNumber");
            }

            //not Validated Date
            //not Validated IsOverdraftFee
        }

        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Invalid Transaction");
        }
    }
}