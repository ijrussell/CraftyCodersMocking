using System;
using BankDemo.ServiceIntefaces;

namespace BankDemo.Services
{
    public class ConsoleLogService : ILogService
    {
        public void Info(string message)
        {
            Console.WriteLine("INFO: {0}", message);
        }

        public void Warning(string message)
        {
            Console.WriteLine("WARNING: {0}", message);
        }

        public void Error(string message)
        {
            Console.WriteLine("ERROR: {0}", message);
        }
    }
}
