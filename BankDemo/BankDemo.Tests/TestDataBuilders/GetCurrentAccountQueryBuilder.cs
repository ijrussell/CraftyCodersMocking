using BankDemo.Queries;

namespace BankDemo.Tests.TestDataBuilders
{
    public class GetCurrentAccountQueryBuilder
    {
        private string _sortCode;
        private int _accountNumber;

        public GetCurrentAccountQueryBuilder()
        {
            _sortCode = "00-00-00";
            _accountNumber = 12345678;
        }

        public GetCurrentAccountQueryBuilder WithSortCode(string sortCode)
        {
            _sortCode = sortCode;
            return this;
        }

        public GetCurrentAccountQueryBuilder WithAccountNumber(int accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public GetCurrentAccountQuery Build()
        {
            return new GetCurrentAccountQuery(_sortCode, _accountNumber);
        }
    }
}