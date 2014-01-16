using System;
using BankDemo.Dtos;

namespace BankDemo.Tests.Comparers
{
    public class AccountTransactionResemblance : AccountTransaction
    {
        public AccountTransactionResemblance(AccountTransaction transaction)
            : base(transaction.TransactionDate, transaction.TransactionType, transaction.SortCode, transaction.AccountNumber, transaction.Amount)
        {
            
        }

        public override bool Equals(object obj)
        {
            var other = obj as AccountTransaction;

            if (other != null)
            {
                return object.Equals(this.TransactionDate, other.TransactionDate)
                       && object.Equals(this.TransactionType, other.TransactionType)
                       && object.Equals(this.SortCode, other.SortCode)
                       && object.Equals(this.AccountNumber, other.AccountNumber)
                       && object.Equals(this.Amount, other.Amount);
            }
            
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}