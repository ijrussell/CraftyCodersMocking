using System;
using System.Runtime.Serialization;

namespace BankDemo.Infrastructure
{
    [Serializable]
    public class AmountMustBeGreaterThanZeroException : Exception
    {
        public AmountMustBeGreaterThanZeroException()
        {
        }

        public AmountMustBeGreaterThanZeroException(string message) : base(message)
        {
        }

        public AmountMustBeGreaterThanZeroException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AmountMustBeGreaterThanZeroException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
