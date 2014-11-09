using FluentAssertions;
using NUnit.Framework;

namespace Aav.ExtensionMethods.Tests
{
    public class IntegerExtensionTests
    {
        [TestFixture]
        public class To
        {
            [Test]
            public void YieldsCompleteSeries()
            {
                var target = 7.To(17);
                var numbers = new[] {7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17};

                target.Should().Contain(numbers);
            }
        }
    }
}