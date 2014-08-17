using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountManagement.Models;

namespace BankAccountManagement.Tests.Model
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void AccountShouldNotBeValidWhenSomePropertiesIncorrect()
        {
            Account account = new Account()             //arange
            {
                Last_Name = "Valid Name",
                Zip = "Invalid Zip"
            };

            bool isValid = account.IsValid;             //act

            Assert.IsFalse(isValid);                    //assert
        }

        [TestMethod]
        public void AccountShouldBeValidWhenAllPropertiesCorrect()
        {
            Account account = new Account()             //arange
            {
                Last_Name = "Valid Last Name",
                First_Name = "Valid First Name",
                Address = "Valid Address",
                City = "Valid City",
                State = "Valid State",
                Zip = "00000",
                Balance = 0.00M,
                Overdraftable = true,
                OverdraftAmount = 10.00M,
                IsShadowDeleted = false
            };

            bool isValid = account.IsValid;             //act

            Assert.IsTrue(isValid);                    //assert
        }
    }
}
