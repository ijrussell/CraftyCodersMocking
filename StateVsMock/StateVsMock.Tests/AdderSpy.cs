using System.Collections.Generic;

namespace StateVsMock.Tests
{
    public class AdderSpy : Adder
    {
        private readonly List<string> _addCalls = new List<string>();

        public override int Add(int a, int b)
        {
            _addCalls.Add(a + "+" + b);
            return base.Add(a, b);
        }

        public List<string> AddCalls
        {
            get
            {
                return _addCalls;
            }
        }
    }
}