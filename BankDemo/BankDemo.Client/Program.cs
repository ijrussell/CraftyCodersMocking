using System;
using System.Collections.Generic;
using BankDemo.Dtos;
using BankDemo.Queries;
using BankDemo.QueryHandlers;
using BankDemo.Services;

namespace BankDemo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortCode = "11-11-11";
            var accountNumber = 23456789;

            var query = new GetCurrentAccountQuery(sortCode, accountNumber);

            var currentAccount = getCurrentAccount(query);

            Console.WriteLine("{0} {1}", currentAccount.FirstName, currentAccount.LastName);

            var transactionQuery = new GetCurrentAccountTransactionsQuery(sortCode, accountNumber);

            var transactions = getCurrentAccountTransactions(transactionQuery);

            foreach (var item in transactions)
                Console.WriteLine("[{0}] {1} -> {2:C}", item.TransactionType, item.TransactionDate, item.Amount);

            Console.ReadLine();
        }

        private static CurrentAccount getCurrentAccount(GetCurrentAccountQuery query)
        {
            var handler = new GetCurrentAccountQueryHandler(new DataService());

            return handler.Handle(query);
        }

        private static IEnumerable<AccountTransaction> getCurrentAccountTransactions(GetCurrentAccountTransactionsQuery query)
        {
            var handler = new GetCurrentAccountTransactionsCommandHandler(new DataService());

            return handler.Handle(query);
        }
    }
}
