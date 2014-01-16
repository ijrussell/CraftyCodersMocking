using System.Collections.Generic;
using BankDemo.Dtos;

namespace BankDemo.ServiceIntefaces
{
    public interface IDataService
    {
        CurrentAccount GetCurrentAccount(string sortCode, int accountNumber);
        List<AccountTransaction> GetCurrentAccountTransactions(string sortCode, int accountNumber);
        decimal GetCurrentAccountBalance(string sortCode, int accountNumber);
        void Deposit(string sortCode, int accountNumber, decimal amount);
        void Withdraw(AccountTransaction transaction);
    }
}