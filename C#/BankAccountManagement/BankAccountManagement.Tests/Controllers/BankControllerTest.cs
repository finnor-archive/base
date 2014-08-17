using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountManagement.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using BankAccountManagement.Tests.Dependencies;
using BankAccountManagement.Models;
using BankAccountManagement.Classes;

namespace BankAccountManagement.Tests.Controllers
{
    [TestClass]
    public class BankControllerTest
    {
        List<Account> populateAccountList()
        {
            List<Account> accounts = new List<Account>();

            for (int i=0; i<101; i++)
            {
                Account sampleAccount = new Account()
                {
                    AccountNumber = i,
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
                accounts.Add(sampleAccount);
            }
            return accounts;
        }

        List<Transaction> populateTransactionList()
        {
            List<Transaction> transactions = new List<Transaction>();

            for (int i=0; i<101; i++)
            {
                Transaction sampleTransaction = new Transaction()
                {
                    TransactionID = i,
                    AccountNumber = 1,
                    Amount = 10.00M,
                    OtherParty = "OParty",
                    OtherPartyAccount = "OPAccount",
                    OtherPartyRoutingNumber = "000000001",
                    Date = DateTime.Now,
                    IsOverdraftFee = false
                };
                transactions.Add(sampleTransaction);
            }
            return transactions;
        }

        BankController createBankController()
        {
            var transactionRepository = new TransactionRepoDependency(populateAccountList(), populateTransactionList());
            return new BankController(transactionRepository);
        }

        /*********************************************************************************
         * 
         * 
         *                              Index Tests
         *                              
         * 
         *********************************************************************************/

        [TestMethod]
        public void IndexShouldReturnView()
        {
            var controller = createBankController();                    //arrange

            var result = controller.Index() as ViewResult;           //act

            Assert.IsNotNull(result, "Expected View");                  //assert
        }


        [TestMethod]
        public void IndexShouldReturnViewForValidTransactions()
        {
            var controller = createBankController();                    //arrange

            var result = controller.Index() as ViewResult;           //act

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IEnumerable<Transaction>));                //assert
        }


        /*********************************************************************************
         * 
         * 
         *                              IndexAccount Tests
         *                              
         * 
         *********************************************************************************/
        [TestMethod]
        public void IndexAccountShouldReturnView()
        {
            var controller = createBankController();                    //arrange

            var result = controller.IndexAccount() as ViewResult;           //act

            Assert.IsNotNull(result, "Expected View");                  //assert
        }


        [TestMethod]
        public void IndexAccountShouldReturnViewForValidTransactions()
        {
            var controller = createBankController();                    //arrange

            var result = controller.IndexAccount() as ViewResult;           //act

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IEnumerable<Account>));                //assert
        }



        /*********************************************************************************
         * 
         * 
         *                              Details Tests
         *                              
         * 
         *********************************************************************************/

        [TestMethod]
        public void DetailsShouldReturnViewForExistingTransaction()
        {
            var controller = createBankController();                    //arrange

            var result = controller.Details(1) as ViewResult;           //act

            Assert.IsNotNull(result, "Expected View");                  //assert
        }

        [TestMethod]
        public void DetailsShouldReturnNotFoundViewForInvalidTransaction()
        {
            var controller = createBankController();                    //arrange

            var result = controller.Details(999) as ViewResult;           //act

            Assert.AreEqual("NotFound", result.ViewName);                  //assert
        }


        /*********************************************************************************
         * 
         * 
         *                              DetailsAccount Tests
         *                              
         * 
         *********************************************************************************/

        [TestMethod]
        public void DetailsAccountShouldReturnViewForExistingAccount()
        {
            var controller = createBankController();                    //arrange

            var result = controller.DetailsAccount(1) as ViewResult;           //act

            Assert.IsNotNull(result, "Expected View");                  //assert
        }

        [TestMethod]
        public void DetailsAccountShouldReturnNotFoundViewForInvalidAccount()
        {
            var controller = createBankController();                    //arrange

            var result = controller.DetailsAccount(999) as ViewResult;           //act

            Assert.AreEqual("NotFound", result.ViewName);                  //assert
        }

        /*********************************************************************************
         * 
         * 
         *                              EditAccount Tests
         *                              
         * 
         *********************************************************************************/

        [TestMethod]
        public void EditAccountShouldReturnViewForValidAccount()
        {
            var controller = createBankController();                    //arrange

            var result = controller.EditAccount(1) as ViewResult;           //act

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Account));                //assert
        }


        [TestMethod]
        public void EditAccountShouldReturnNotFoundViewForInvalidAccount()
        {
            var controller = createBankController();                    //arrange

            var result = controller.DetailsAccount(999) as ViewResult;           //act

            Assert.AreEqual("NotFound", result.ViewName);                  //assert
        }



        /*********************************************************************************
         * 
         * 
         *                              CreateAccount Tests
         *                              
         * 
         *********************************************************************************/


        [TestMethod]
        public void CreateAccountShouldReturnViewForExistingAccount()
        {
            var controller = createBankController();                    //arrange

            var result = controller.CreateAccount() as ViewResult;           //act

            Assert.IsNotNull(result, "Expected View");                  //assert
        }


        [TestMethod]
        public void CreateAccountShouldReturnViewForValidAccount()
        {
            var controller = createBankController();                    //arrange

            var result = controller.CreateAccount() as ViewResult;           //act

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Account));                //assert
        }


        /*********************************************************************************
         * 
         * 
         *                              CreateTransaction Tests
         *                              
         * 
         *********************************************************************************/

        [TestMethod]
        public void CreateTransactionShouldReturnViewForExistingTransaction()
        {
            var controller = createBankController();                    //arrange

            var result = controller.CreateTransaction() as ViewResult;           //act

            Assert.IsNotNull(result, "Expected View");                  //assert
        }


        [TestMethod]
        public void CreateTransactionShouldReturnViewForValidTransaction()
        {
            var controller = createBankController();                    //arrange

            var result = controller.CreateTransaction() as ViewResult;           //act

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Transaction));                //assert
        }



        /*********************************************************************************
         * 
         * 
         *                              Delete Tests
         *                              
         * 
         *********************************************************************************/
        [TestMethod]
        public void DeleteShouldReturnNotFoundViewForInvalidTransaction()
        {
            var controller = createBankController();                    //arrange

            var result = controller.Delete(999) as ViewResult;           //act

            Assert.AreEqual("NotFound", result.ViewName);                  //assert
        }

        [TestMethod]
        public void DeleteShouldReturnViewForExistingTransaction()
        {
            var controller = createBankController();                    //arrange

            var result = controller.Delete(1) as ViewResult;           //act

            Assert.IsNotNull(result, "Expected View");                  //assert
        }


        [TestMethod]
        public void DeleteShouldReturnViewForValidTransaction()
        {
            var controller = createBankController();                    //arrange

            var result = controller.Delete(1) as ViewResult;           //act

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Transaction));                //assert
        }

        [TestMethod]
        public void DeleteShouldRedirectWhenUpdateSuccessful()
        {
            var controller = createBankController();                    //arrange

            var result = controller.Delete(1, "true") as ViewResult;           //act
            Assert.AreEqual("Deleted", result.ViewName);                //assert
        }


        /*********************************************************************************
         * 
         * 
         *                              DeleteAccount
         *                              
         * 
         *********************************************************************************/
        [TestMethod]
        public void DeleteAccountShouldReturnNotFoundViewForInvalidTransaction()
        {
            var controller = createBankController();                    //arrange

            var result = controller.DeleteAccount(999) as ViewResult;           //act

            Assert.AreEqual("NotFound", result.ViewName);                  //assert
        }

        [TestMethod]
        public void DeleteAccountShouldReturnViewForExistingAccount()
        {
            var controller = createBankController();                    //arrange

            var result = controller.DeleteAccount(2) as ViewResult;           //act

            Assert.IsNotNull(result, "Expected View");                  //assert
        }


        [TestMethod]
        public void DeleteAccountShouldReturnViewForValidAccount()
        {
            var controller = createBankController();                    //arrange

            var result = controller.DeleteAccount(1) as ViewResult;           //act

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Account));                //assert
        }

        [TestMethod]
        public void DeleteAccountShouldRedirectWhenUpdateSuccessful()
        {
            var controller = createBankController();                    //arrange

            var result = controller.DeleteAccount(1, "true") as ViewResult;           //act
            Assert.AreEqual("Deleted", result.ViewName);                //assert
        }
    }
}
