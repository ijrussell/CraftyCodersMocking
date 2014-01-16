using System.Collections.Generic;
using BankDemo.Dtos;
using BankDemo.Infrastructure;

namespace BankDemo.Queries
{
    public class GetCurrentAccountTransactionsQuery : IQuery<List<AccountTransaction>>
    {
        public string SortCode { get; private set; }
        public int AccountNumber { get; private set; }

        public GetCurrentAccountTransactionsQuery(string sortCode, int accountNumber)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
        }
    }
}
