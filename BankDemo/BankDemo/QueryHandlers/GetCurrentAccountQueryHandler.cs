using BankDemo.Dtos;
using BankDemo.Infrastructure;
using BankDemo.Queries;
using BankDemo.ServiceIntefaces;

namespace BankDemo.QueryHandlers
{
    public class GetCurrentAccountQueryHandler : IQueryHandler<GetCurrentAccountQuery, CurrentAccount>
    {
        private readonly IDataService _dataService;

        public GetCurrentAccountQueryHandler(IDataService dataService)
        {
            Ensure.NotNull(dataService, "dataService");
            
            _dataService = dataService;
        }

        public CurrentAccount Handle(GetCurrentAccountQuery message)
        {
            var currentAccount = _dataService.GetCurrentAccount(message.SortCode, message.AccountNumber);

            if (currentAccount == null)
                throw new UnknownCurrentAccountException();

            return currentAccount;
        }
    }
}
