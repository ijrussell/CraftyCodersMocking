using BankDemo.Infrastructure;

namespace BankDemo.Commands
{
    public class WithdrawFromCurrentAccountCommand : ICommand
    {
        public string SortCode { get; private set; }
        public int AccountNumber { get; private set; }
        public decimal Amount { get; private set; }

        public WithdrawFromCurrentAccountCommand(string sortCode, int accountNumber, decimal amount)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
            Amount = amount;
        }
    }
}
