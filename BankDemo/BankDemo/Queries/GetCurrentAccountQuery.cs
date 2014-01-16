using BankDemo.Dtos;
using BankDemo.Infrastructure;

namespace BankDemo.Queries
{
    public class GetCurrentAccountQuery : IQuery<CurrentAccount>
    {
        public string SortCode { get; private set; }
        public int AccountNumber { get; private set; }

        public GetCurrentAccountQuery(string sortCode, int accountNumber)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
        }
    }
}
