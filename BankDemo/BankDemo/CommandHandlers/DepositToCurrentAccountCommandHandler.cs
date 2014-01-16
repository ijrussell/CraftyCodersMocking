using System;
using BankDemo.Commands;
using BankDemo.Infrastructure;
using BankDemo.ServiceIntefaces;

namespace BankDemo.CommandHandlers
{
    public class DepositToCurrentAccountCommandHandler : ICommandHandler<DepositToCurrentAccountCommand>
    {
        private readonly IDataService _dataService;
        private readonly ILogService _logService;

        public DepositToCurrentAccountCommandHandler(IDataService dataService, ILogService logService)
        {
            Ensure.NotNull(dataService, "dataService");
            Ensure.NotNull(logService, "logService");

            _dataService = dataService;
            _logService = logService;
        }

        public void Handle(DepositToCurrentAccountCommand message)
        {
            if (message.Amount <= 0.0m)
            {
                _logService.Info(BuildLogMessage(message));
                throw new AmountMustBeGreaterThanZeroException();
            }
            
            _dataService.Deposit(message.SortCode, message.AccountNumber, message.Amount);
        }

        private static string BuildLogMessage(DepositToCurrentAccountCommand message)
        {
            return string.Format("[{0}] SortCode: {1}, AccountNumber: {2}, Deposit: {3:C}", TimeProvider.Current.UtcNow, message.SortCode, message.AccountNumber, message.Amount);
        }
    }
}
