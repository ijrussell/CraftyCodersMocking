using BankDemo.QueryHandlers;
using BankDemo.ServiceIntefaces;
using NSubstitute;

namespace BankDemo.Tests.SutBuilders
{
    public class GetCurrentAccountQueryHandlerBuilder
    {
        private IDataService _dataService;
        
        public GetCurrentAccountQueryHandlerBuilder()
        {
            _dataService = Substitute.For<IDataService>();
        }

        public GetCurrentAccountQueryHandlerBuilder WithDataService(IDataService dataService)
        {
            _dataService = dataService;
            return this;
        }

        public GetCurrentAccountQueryHandler Build()
        {
            return new GetCurrentAccountQueryHandler(_dataService);
        }
    }
}