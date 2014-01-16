namespace BankDemo.Dtos
{
    public class CurrentAccount
    {
        public string SortCode { get; private set; }
        public int AccountNumber { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public CurrentAccount(string sortCode, int accountNumber, string firstName, string lastName)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
