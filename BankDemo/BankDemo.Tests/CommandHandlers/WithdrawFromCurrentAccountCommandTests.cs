using System;
using BankDemo.CommandHandlers;
using BankDemo.Commands;
using BankDemo.Dtos;
using BankDemo.Infrastructure;
using BankDemo.ServiceIntefaces;
using BankDemo.Tests.Comparers;
using NSubstitute;
using NUnit.Framework;

namespace BankDemo.Tests.CommandHandlers
{
    [TestFixture]
    public class WithdrawFromCurrentAccountCommandTests
    {
        [Test]
        public void should_successfully_withdraw_money()
        {
            var cmd = new WithdrawFromCurrentAccountCommand("00-00-00", 12345678, 100.0m);

            TimeProvider.Current = new FakeTimeProvider(new DateTime(2013, 12, 12));

            //var currentAccount = new CurrentAccount("00-00-00", 12345678, "", "");
            var currentAccount = Substitute.For<CurrentAccount>();
            var dataService = Substitute.For<IDataService>();
            var logService = Substitute.For<ILogService>();

            dataService.GetCurrentAccount(cmd.SortCode, cmd.AccountNumber).Returns(currentAccount);

            var sut = new WithdrawFromCurrentAccountCommandHandler(dataService, logService);

            sut.Handle(cmd);

            var expected = new AccountTransactionResemblance(new AccountTransaction(TimeProvider.Current.UtcNow, TransactionType.Withdrawl, cmd.SortCode,
                                                  cmd.AccountNumber, cmd.Amount));
            dataService.Received().Withdraw(expected);
        }
    }
}