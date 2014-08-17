using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankAccountManagement.Models;
using BankAccountManagement.Classes;

namespace BankAccountManagement.Tests.Dependencies
{
    public class TransactionRepoDependency : ITransactionRepo
    {
        private List<Account> accountList;
        private List<Transaction> transactionList;

        public TransactionRepoDependency(List<Account> accounts, List<Transaction> transactions)
        {
            accountList = accounts;
            transactionList = transactions;
        }

        public IQueryable<Account> ListAccounts()
        {
            return (from account in accountList
                   where account.IsShadowDeleted == false
                   select account).AsQueryable();
        }

        public IQueryable<Transaction> ListTransactions(String accountNumber)
        {
            return (from transaction in transactionList
                   where transaction.AccountNumber.Equals(accountNumber)
                   select transaction).AsQueryable();
        }

        public IQueryable<Transaction> ListTransactions()
        {
            return (from transaction in transactionList
                   select transaction).AsQueryable();
        }

        public Account getAccount(int accountNumber)
        {
            return accountList.SingleOrDefault(d => d.AccountNumber.Equals(accountNumber));
        }

        public Transaction getTransaction(int transactionID)
        {
            return transactionList.SingleOrDefault(d => d.TransactionID == transactionID);
        }

        public void addAccount(Account account)
        {
            accountList.Add(account);
        }

        public void addTransaction(Transaction transaction)
        {
            Account account = getAccount(transaction.AccountNumber);
            account.Balance += transaction.Amount;
            transactionList.Add(transaction);
            if (account.Balance < 0 && transaction.Amount < 0)                                      //create overdraft fee
            {
                Transaction overdraft = new Transaction();
                overdraft.IsOverdraftFee = true;
                overdraft.AccountNumber = account.AccountNumber;
                overdraft.Amount = (decimal)account.OverdraftAmount;
                overdraft.Date = DateTime.Now;
                account.Balance += overdraft.Amount;
                transactionList.Add(overdraft);
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
            Account tempAccount = accountList[myTransaction.AccountNumber];
            if (myTransaction.Amount > 0)
            {
                tempAccount.Balance -= myTransaction.Amount;
                transactionList.Remove(myTransaction);
            }
            else
            {
                decimal runningBalance = tempAccount.Balance;
                var tempTransactionList = (from transaction in transactionList
                                       where transaction.Date > myTransaction.Date
                                       orderby transaction.Date
                                       select transaction).ToList();

                foreach (Transaction item in tempTransactionList)                   //recover balance from time when transaction is to be deleted
                {
                    runningBalance -= item.Amount;
                }
                runningBalance -= myTransaction.Amount;
                transactionList.Remove(myTransaction);



                foreach (Transaction item in tempTransactionList)                   //remove overdraft fees due to deleted transaction
                {
                    if (item.IsOverdraftFee && runningBalance >= 0)
                    {
                        transactionList.Remove(item);
                    }
                    else
                    {
                        runningBalance += item.Amount;
                    }
                }
                tempAccount.Balance = runningBalance;
            }
        }

        public void Save()
        {
            foreach (Account account in accountList)
            {
                if (!account.IsValid)
                    throw new ApplicationException("Rule violations");
            }
            foreach (Transaction transaction in transactionList)
            {
                if (!transaction.IsValid)
                    throw new ApplicationException("Rule violations");
            }
        }
    }
}