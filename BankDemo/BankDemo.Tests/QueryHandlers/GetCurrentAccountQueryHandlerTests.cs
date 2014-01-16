using BankDemo.Dtos;
using BankDemo.Infrastructure;
using BankDemo.Queries;
using BankDemo.QueryHandlers;
using BankDemo.ServiceIntefaces;
using BankDemo.Tests.Comparers;
using BankDemo.Tests.SutBuilders;
using BankDemo.Tests.TestDataBuilders;
using NSubstitute;
using NUnit.Framework;

namespace BankDemo.Tests.QueryHandlers
{
    [TestFixture]
    public class GetCurrentAccountQueryHandlerTests
    {
        [Test]
        public void should_return_current_account_if_account_exists()
        {
            // Arrange
            var currentAccount = new CurrentAccountBuilder()
                .Build();

            var query = new GetCurrentAccountQuery(currentAccount.SortCode, currentAccount.AccountNumber);

            var dataService = Substitute.For<IDataService>();

            dataService.GetCurrentAccount(currentAccount.SortCode, currentAccount.AccountNumber)
                .Returns(currentAccount);

            var sut = new GetCurrentAccountQueryHandlerBuilder()
                .WithDataService(dataService)
                .Build();

            // Act
            var actual = sut.Handle(query);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(new CurrentAccountComparer().Equals(actual, currentAccount));
        }

        [Test]
        public void should_return_exception_if_current_account_does_not_exist()
        {
            // Arrange
            var query = new GetCurrentAccountQueryBuilder().Build();

            var dataService = Substitute.For<IDataService>();

            dataService.GetCurrentAccount(query.SortCode, query.AccountNumber).Returns((CurrentAccount)null);

            var sut = new GetCurrentAccountQueryHandlerBuilder()
                .WithDataService(dataService)
                .Build();

            // Act
            // Assert
            Assert.Throws<UnknownCurrentAccountException>(() => sut.Handle(query));
        }
    }
}