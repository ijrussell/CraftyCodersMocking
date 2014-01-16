using System;
using BankDemo.Infrastructure;

namespace BankDemo.Tests
{
    public class FakeTimeProvider : TimeProvider
    {
        private readonly DateTime _now;

        public FakeTimeProvider(DateTime now)
        {
            _now = now;
        }

        public override DateTime UtcNow
        {
            get { return _now; }
        }
    }
}