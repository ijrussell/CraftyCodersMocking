using System;

namespace BankDemo.Dtos
{
    public class AccountTransaction
    {
        public DateTime TransactionDate { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public string SortCode { get; private set; }
        public int AccountNumber { get; private set; }
        public decimal Amount { get; private set; }

        public AccountTransaction(DateTime transactionDate, TransactionType transactionType, string sortCode, int accountNumber, decimal amount)
        {
            TransactionDate = transactionDate;
            TransactionType = transactionType;
            SortCode = sortCode;
            AccountNumber = accountNumber;
            Amount = amount;
        }
    }
}
