using BankDemo.Dtos;

namespace BankDemo.Tests.TestDataBuilders
{
    public class CurrentAccountBuilder
    {
        private string _sortCode;
        private int _accountNumber;
        private string _firstName;
        private string _lastName;

        public CurrentAccountBuilder()
        {
            _sortCode = "00-00-00";
            _accountNumber = 12345678;
            _firstName = "Test";
            _lastName = "Customer";
        }

        public CurrentAccountBuilder WithSortCode(string sortCode)
        {
            _sortCode = sortCode;
            return this;
        }

        public CurrentAccountBuilder WithAccountNumber(int accountNumber)
        {
            _accountNumber = accountNumber;
            return this;
        }

        public CurrentAccount Build()
        {
            return new CurrentAccount(_sortCode, _accountNumber, _firstName, _lastName);
        }
    }
}