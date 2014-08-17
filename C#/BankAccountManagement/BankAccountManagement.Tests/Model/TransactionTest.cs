using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountManagement.Models;

namespace BankAccountManagement.Tests.Model
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void TransactionShouldNotBeValidWhenSomePropertiesIncorrect()
        {
            Transaction transaction = new Transaction()             //arange
            {
                AccountNumber = 1,
                Amount = 10.00M,
                OtherParty = "OParty",
                OtherPartyAccount = "OPAccount",
                OtherPartyRoutingNumber = "InvalidRoutingNumber",
                Date = DateTime.Now,
                IsOverdraftFee = false
            };

            bool isValid = transaction.IsValid;             //act

            Assert.IsFalse(isValid);                    //assert
        }

        [TestMethod]
        public void TransactionShouldNotBeValidWhenAccountNumberIsEmpty()
        {
            Transaction transaction = new Transaction()             //arange
            {
                Amount = 10.00M,
                OtherParty = "OParty",
                OtherPartyAccount = "OPAccount",
                OtherPartyRoutingNumber = "000000001",
                Date = DateTime.Now,
                IsOverdraftFee = false
                //empty non nullable fields like amount
            };

            bool isValid = transaction.IsValid;             //act

            Assert.IsFalse(isValid);                    //assert
        }

        [TestMethod]
        public void TransactionShouldNotBeValidWhenAmountIsEmpty()
        {
            Transaction transaction = new Transaction()             //arange
            {
                AccountNumber = 1,
                OtherParty = "OParty",
                OtherPartyAccount = "OPAccount",
                OtherPartyRoutingNumber = "000000001",
                Date = DateTime.Now,
                IsOverdraftFee = false
            };

            bool isValid = transaction.IsValid;             //act

            Assert.IsFalse(isValid);                    //assert
        }   


        [TestMethod]
        public void TransactionShouldBeValidWhenAllPropertiesCorrect()
        {
            Transaction transaction = new Transaction()             //arange
            {
                AccountNumber = 1,
                Amount = 10.00M,
                OtherParty = "OParty",
                OtherPartyAccount = "OPAccount",
                OtherPartyRoutingNumber = "000000001",
                Date = DateTime.Now,
                IsOverdraftFee = false
            };

            bool isValid = transaction.IsValid;             //act

            Assert.IsTrue(isValid);                    //assert
        }

        [TestMethod]
        public void TransactionShouldBeValidWhenOPDetailsIsEmpty()
        {
            Transaction transaction = new Transaction()             //arange
            {
                AccountNumber = 1,
                Amount = 10.00M,
                Date = DateTime.Now,
                IsOverdraftFee = false
            };

            bool isValid = transaction.IsValid;             //act

            Assert.IsTrue(isValid);                    //assert
        }
    }
}
