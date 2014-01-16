using System;
using System.Collections.Generic;
using System.Linq;
using BankDemo.Dtos;
using BankDemo.ServiceIntefaces;

namespace BankDemo.Services
{
    public class DataService : IDataService
    {
        private List<CurrentAccount> _accounts;
        private List<AccountTransaction> _transactions;

        public DataService()
        {
            Setup();
        }

        public CurrentAccount GetCurrentAccount(string sortCode, int accountNumber)
        {
            return _accounts.FirstOrDefault(x => x.SortCode == sortCode && x.AccountNumber == accountNumber);
        }

        public List<AccountTransaction> GetCurrentAccountTransactions(string sortCode, int accountNumber)
        {
            return _transactions.Where(x => x.SortCode == sortCode && x.AccountNumber == accountNumber).ToList();
        }

        public decimal GetCurrentAccountBalance(string sortCode, int accountNumber)
        {
            return _transactions.Where(x => x.SortCode == sortCode && x.AccountNumber == accountNumber).Sum(s => s.Amount);
        }

        public void Deposit(string sortCode, int accountNumber, decimal amount)
        {
            _transactions.Add(new AccountTransaction(DateTime.Now, TransactionType.Deposit, sortCode, accountNumber, amount));
        }

        public void Withdraw(AccountTransaction transaction)
        {
            _transactions.Add(new AccountTransaction(transaction.TransactionDate, transaction.TransactionType, transaction.SortCode, transaction.AccountNumber, -transaction.Amount));
        }

        private void Setup()
        {
            var account1 = new CurrentAccount("00-00-00", 12345678, "Ian", "Russell");
            var account2 = new CurrentAccount("00-00-00", 23456789, "John", "McLoughlin­");
            var account3 = new CurrentAccount("11-11-11", 23456789, "Geff", "Lombardi");

            _accounts = new List<CurrentAccount>() { account1, account2, account3 };

            _transactions = new List<AccountTransaction>
            {
                new AccountTransaction(DateTime.Now.AddYears(-1), TransactionType.OpenAccount, account1.SortCode, account1.AccountNumber, 0.0m),
                new AccountTransaction(DateTime.Now.AddYears(-1), TransactionType.OpenAccount, account2.SortCode, account2.AccountNumber, 0.0m),
                new AccountTransaction(DateTime.Now.AddYears(-1), TransactionType.OpenAccount, account3.SortCode, account3.AccountNumber, 1000.0m),
                new AccountTransaction(DateTime.Now.AddDays(-100), TransactionType.Deposit, account1.SortCode, account1.AccountNumber, 1000.0m),
                new AccountTransaction(DateTime.Now.AddDays(-100), TransactionType.Deposit, account2.SortCode, account2.AccountNumber, 1500.0m),
                new AccountTransaction(DateTime.Now.AddDays(-100), TransactionType.Deposit, account3.SortCode, account3.AccountNumber, 1000.0m),
                new AccountTransaction(DateTime.Now.AddDays(-50), TransactionType.Withdrawl, account1.SortCode, account1.AccountNumber, -1000.0m),
                new AccountTransaction(DateTime.Now.AddDays(-40), TransactionType.Withdrawl, account2.SortCode, account2.AccountNumber, -500.0m),
                new AccountTransaction(DateTime.Now.AddDays(-30), TransactionType.Withdrawl, account3.SortCode, account3.AccountNumber, -1000.0m),
                new AccountTransaction(DateTime.Now.AddDays(-20), TransactionType.Deposit, account3.SortCode, account3.AccountNumber, 8000.0m),
                new AccountTransaction(DateTime.Now.AddDays(-10), TransactionType.Deposit, account3.SortCode, account3.AccountNumber, 1000.0m)
            };
        }
    }
}
