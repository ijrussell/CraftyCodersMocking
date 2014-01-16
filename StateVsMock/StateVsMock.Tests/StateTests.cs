using NUnit.Framework;

namespace StateVsMock.Tests
{
    [TestFixture]
    public class StateTests
    {
        [TestCase(0, 0, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(1, -1, -1)]
        [TestCase(-1, 1, -1)]
        [TestCase(-1, -1, 1)]
        [TestCase(4, 3, 12)]
        [TestCase(13, 24, 312)]
        public void should_return_correct_results(int a, int b, int result)
        {
            var sut = new BasicMathematics();
            
            Assert.That(sut.Multiply(a, b), Is.EqualTo(result));
        }
    }
}