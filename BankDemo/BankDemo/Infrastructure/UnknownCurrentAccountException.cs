using System;
using System.Runtime.Serialization;

namespace BankDemo.Infrastructure
{
    [Serializable]
    public class UnknownCurrentAccountException : Exception
    {
        public UnknownCurrentAccountException()
        {
        }

        public UnknownCurrentAccountException(string message) : base(message)
        {
        }

        public UnknownCurrentAccountException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UnknownCurrentAccountException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
