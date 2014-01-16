using System;
using System.Collections.Generic;
using BankDemo.Dtos;
using BankDemo.Infrastructure;
using BankDemo.Queries;
using BankDemo.ServiceIntefaces;

namespace BankDemo.QueryHandlers
{
    public class GetCurrentAccountTransactionsCommandHandler : IQueryHandler<GetCurrentAccountTransactionsQuery, List<AccountTransaction>>
    {
        private readonly IDataService _dataService;

        public GetCurrentAccountTransactionsCommandHandler(IDataService dataService)
        {
            Ensure.NotNull(dataService, "dataService");
            
            _dataService = dataService;
        }

        public List<AccountTransaction> Handle(GetCurrentAccountTransactionsQuery message)
        {
            return _dataService.GetCurrentAccountTransactions(message.SortCode, message.AccountNumber);
        }
    }
}
