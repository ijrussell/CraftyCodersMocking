using System.Collections.Generic;
using NUnit.Framework;

namespace StateVsMock.Tests
{
    [TestFixture]
    public class MockTests
    {
        [Test]
        public void should_perform_correct_calculation()
        {
            var spy = new AdderSpy();
            
            var sut = new BasicMathematics
            {
                Adder = spy
            };

            var product = sut.Multiply(4, 3);

            Assert.That(spy.AddCalls, Is.EqualTo(new List<string>(){"0+3", "3+3", "6+3", "9+3"}));
            Assert.That(product, Is.EqualTo(12));
        }
    }
}