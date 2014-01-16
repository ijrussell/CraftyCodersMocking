using System;
using BankDemo.Commands;
using BankDemo.Infrastructure;
using BankDemo.ServiceIntefaces;

namespace BankDemo.CommandHandlers
{
    public class CreateCurrentAccountCommandHandler : ICommandHandler<CreateCurrentAccountCommand>
    {
        private readonly IDataService _dataService;
        private readonly IEmailService _email;

        public CreateCurrentAccountCommandHandler(IDataService dataService, IEmailService emailService)
        {
            Ensure.NotNull(dataService, "dataService");
            Ensure.NotNull(emailService, "emailService");
            
            _dataService = dataService;
            _email = emailService;
        }

        public void Handle(CreateCurrentAccountCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
