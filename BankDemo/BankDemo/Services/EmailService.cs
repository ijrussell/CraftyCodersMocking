using BankDemo.ServiceIntefaces;

namespace BankDemo.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string message)
        {
            //Send email
        }
    }
}
