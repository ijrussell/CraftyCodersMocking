using BankDemo.Infrastructure;

namespace BankDemo.Commands
{
    public class DepositToCurrentAccountCommand : ICommand
    {
        public string SortCode { get; private set; }
        public int AccountNumber { get; private set; }
        public decimal Amount { get; private set; }

        public DepositToCurrentAccountCommand(string sortCode, int accountNumber, decimal amount)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
            Amount = amount;
        }
    }
}
