using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankAccountManagement.Models;
using BankAccountManagement.Classes;

namespace BankAccountManagement.Controllers
{
    public class BankController : Controller
    {
        public ITransactionRepo transactionRepo;

        public BankController() : this(new TransactionRepo())
        { }

        public BankController(ITransactionRepo repo)
        {
            transactionRepo = repo;
        }

        //
        // GET: /Bank/
        public ActionResult Index()
        {
            var transactions = transactionRepo.ListTransactions().ToList();
            return View("Index", transactions);
        }

        [HttpPost]
        public ActionResult Index(String accountNumber)
        {
            var transactions = transactionRepo.ListTransactions(accountNumber).ToList();
            return View("Index", transactions);
        }

        public ActionResult IndexAccount()
        {
            var accounts = transactionRepo.ListAccounts().ToList();
            return View("IndexAccount", accounts);
        }

        public ActionResult Details(int id)
        {
            Transaction transaction = transactionRepo.getTransaction(id);
            if (transaction == null)
                return View("NotFound");
            else
                return View("Details", transaction);
        }

        public ActionResult DetailsAccount(int id)
        {
            Account account = transactionRepo.getAccount(id);
            if (account == null)
                return View("NotFound");
            else
                return View("DetailsAccount", account);
        }

        public ActionResult CreateAccount()
        {
            Account account = new Account();
            account.Balance = 0;
            
            return View(account);
        }

        [HttpPost]
        public ActionResult CreateAccount(Account account)
        {
            try
            {
                UpdateModel(account);
                transactionRepo.addAccount(account);
                account.Balance = 0;
                transactionRepo.Save();
                return RedirectToAction("DetailsAccount", new { id = account.AccountNumber });
            }
            catch
            {
                foreach (var issue in account.GetRuleViolations())
                {
                    ModelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
                }
                return View(account);
            }
        }

        public ActionResult CreateTransaction()
        {
            Transaction transaction = new Transaction()
            {
                Date = DateTime.Now
            };
            return View(transaction);
        }

        [HttpPost]
        public ActionResult CreateTransaction(Transaction transaction)
        {
            try
            {
                UpdateModel(transaction);
                transactionRepo.addTransaction(transaction);
                transactionRepo.Save();
                return RedirectToAction("Details", new { id = transaction.TransactionID });
            }
            catch
            {
                foreach (var issue in transaction.GetRuleViolations())
                {
                    ModelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
                }
                return View(transaction);
            }
        }

        public ActionResult EditAccount(int id)
        {
            Account account = transactionRepo.getAccount(id);

            return View(account);
        }

        [HttpPost]
        public ActionResult EditAccount(int id, FormCollection formValues)
        {
            Account account = transactionRepo.getAccount(id);
            try
            {
                UpdateModel(account);

                transactionRepo.Save();
                return RedirectToAction("DetailsAccount", new { id = account.AccountNumber });
            }
            catch
            {
                foreach (var issue in account.GetRuleViolations())
                {
                    ModelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
                }
                return View(account);
            }
        }

        public ActionResult DeleteAccount(int id)
        {
            Account account = transactionRepo.getAccount(id);

            if (account == null)
                return View("NotFound");
            else
                return View(account);
        }

        [HttpPost]
        public ActionResult DeleteAccount(int id, string confirmButton)
        {
            Account account = transactionRepo.getAccount(id);

            if (account == null)
                return View("NotFound");

            transactionRepo.deleteAccount(account);
            transactionRepo.Save();

            return View("Deleted");
        }

        public ActionResult Delete(int id)
        {
            Transaction transaction = transactionRepo.getTransaction(id);

            if (transaction == null)
                return View("NotFound");
            else
                return View(transaction);
        }

        [HttpPost]
        public ActionResult Delete(int id, string confirmButton)
        {
            Transaction transaction = transactionRepo.getTransaction(id);

            if (transaction == null)
                return View("NotFound");

            transactionRepo.deleteTransaction(transaction);
            transactionRepo.Save();

            return View("Deleted");
        }
	}
}