using System;
using BankDemo.Commands;
using BankDemo.Dtos;
using BankDemo.Infrastructure;
using BankDemo.ServiceIntefaces;

namespace BankDemo.CommandHandlers
{
    public class WithdrawFromCurrentAccountCommandHandler : ICommandHandler<WithdrawFromCurrentAccountCommand>
    {
        private readonly IDataService _dataService;
        private readonly ILogService _logService;

        public WithdrawFromCurrentAccountCommandHandler(IDataService dataService, ILogService logService)
        {
            Ensure.NotNull(dataService, "dataService");
            Ensure.NotNull(logService, "logService");
            
            _dataService = dataService;
            _logService = logService;
        }

        public void Handle(WithdrawFromCurrentAccountCommand message)
        {
            var currentAccount = _dataService.GetCurrentAccount(message.SortCode, message.AccountNumber);

            if (currentAccount == null)
            {
                _logService.Error(BuildLogMessage(message));
                throw new UnknownCurrentAccountException();
            }
                
            if (message.Amount <= 0.0m)
            {
                _logService.Info(BuildLogMessage(message));
                throw new AmountMustBeGreaterThanZeroException();
            }

            var transaction = new AccountTransaction(TimeProvider.Current.UtcNow, TransactionType.Withdrawl, message.SortCode,
                                                     message.AccountNumber, message.Amount);
            
            _dataService.Withdraw(transaction);
        }

        private static string BuildLogMessage(WithdrawFromCurrentAccountCommand message)
        {
            return string.Format("[{0}] SortCode: {1}, AccountNumber: {2}, Deposit: {3:C}", TimeProvider.Current.UtcNow, message.SortCode, message.AccountNumber, message.Amount);
        }
    }
}
