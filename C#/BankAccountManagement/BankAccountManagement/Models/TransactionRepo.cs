using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankAccountManagement.Classes;

namespace BankAccountManagement.Models
{
    public class TransactionRepo : ITransactionRepo
    {
        private TransactionsDataContext db = new TransactionsDataContext();

        public IQueryable<Account> ListAccounts()
        {
            return from account in db.Accounts
                   where account.IsShadowDeleted==false
                   select account;
        }

        public IQueryable<Transaction> ListTransactions(String accountNumber)
        {
            return from transaction in db.Transactions
                   where transaction.AccountNumber.Equals(accountNumber)
                   select transaction;
        }

        public IQueryable<Transaction> ListTransactions()
        {
            return from transaction in db.Transactions
                   select transaction;
        }

        public Account getAccount(int accountNumber)
        {
            return db.Accounts.SingleOrDefault(d => d.AccountNumber.Equals(accountNumber));
        }

        public Transaction getTransaction(int transactionID)
        {
            return db.Transactions.SingleOrDefault(d => d.TransactionID == transactionID);
        }

        public void addAccount(Account account)
        {
            db.Accounts.InsertOnSubmit(account);
        }

        public void addTransaction(Transaction transaction)
        {
            Account account = getAccount(transaction.AccountNumber);
            account.Balance += transaction.Amount;
            db.Transactions.InsertOnSubmit(transaction);
            if (account.Balance<0 && transaction.Amount<0)                                      //create overdraft fee
            {
                Transaction overdraft = new Transaction();
                overdraft.IsOverdraftFee = true;
                overdraft.AccountNumber = account.AccountNumber;
                overdraft.Amount = (decimal)account.OverdraftAmount;
                overdraft.Date = DateTime.Now;
                account.Balance += overdraft.Amount;
                db.Transactions.InsertOnSubmit(overdraft);
            }
        }

        public void deleteAccount(Account account)
        {
            account.IsShadowDeleted = true;
        }

        public void recoverAccount(Account account)
        {
            account.IsShadowDeleted = false;
        }

        public void deleteTransaction(Transaction myTransaction)
        {
            if (myTransaction.Amount > 0)
            {
                myTransaction.Account.Balance -= myTransaction.Amount;
                db.Transactions.DeleteOnSubmit(myTransaction);
            }
            else
            {
                decimal runningBalance = myTransaction.Account.Balance;
                var transactionList = (from transaction in db.Transactions
                                       where transaction.Date > myTransaction.Date
                                       orderby transaction.Date
                                       select transaction).ToList();

                foreach (Transaction item in transactionList)                   //recover balance from time when transaction is to be deleted
                {
                    runningBalance -= item.Amount;
                }
                runningBalance -= myTransaction.Amount;
                db.Transactions.DeleteOnSubmit(myTransaction);



                foreach (Transaction item in transactionList)                   //remove overdraft fees due to deleted transaction
                {
                    if (item.IsOverdraftFee && runningBalance >= 0)
                    {
                        db.Transactions.DeleteOnSubmit(item);
                    }
                    else
                    {
                        runningBalance += item.Amount;
                    }
                }
                myTransaction.Account.Balance = runningBalance;
            }
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}