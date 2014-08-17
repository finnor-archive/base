using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountManagement.Models;

namespace BankAccountManagement.Classes
{
    public interface ITransactionRepo
    {
        IQueryable<Account> ListAccounts();

        IQueryable<Transaction> ListTransactions(String accountNumber);

        IQueryable<Transaction> ListTransactions();

        Account getAccount(int accountNumber);

        Transaction getTransaction(int transactionID);

        void addAccount(Account account);

        void addTransaction(Transaction transaction);

        void deleteAccount(Account account);

        void recoverAccount(Account account);

        void deleteTransaction(Transaction myTransaction);

        void Save();
    }
}
