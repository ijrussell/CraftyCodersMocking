using System.Collections.Generic;
using BankDemo.Dtos;

namespace BankDemo.Tests.Comparers
{
    public class CurrentAccountComparer : IEqualityComparer<CurrentAccount>
    {
        public bool Equals(CurrentAccount actual, CurrentAccount expected)
        {
            return actual.SortCode == expected.SortCode &&
                   actual.AccountNumber == expected.AccountNumber &&
                   actual.FirstName == expected.FirstName &&
                   actual.LastName == expected.LastName;
        }

        public int GetHashCode(CurrentAccount account)
        {
            return account.SortCode.GetHashCode() ^
                   account.AccountNumber.GetHashCode() ^
                   account.FirstName.GetHashCode() ^
                   account.LastName.GetHashCode();
        }
    }
}