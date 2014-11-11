using FluentAssertions;
using NUnit.Framework;

namespace Aav.ExtensionMethods.Tests
{
    public class EnumerationExtensionTests
    {
        [TestFixture]
        public class GetDescription
        {
            private enum AnEnumeration
            {
                [System.ComponentModel.Description("A value with a description.")] FirstValue,
                SecondValue
            }

            [Test]
            public void DescriptionExists()
            {
                AnEnumeration.FirstValue.GetDescription().Should().Be("A value with a description.");
            }

            [Test]
            public void DescriptionDoesNotExist()
            {
                AnEnumeration.SecondValue.GetDescription().Should().Be(AnEnumeration.SecondValue.ToString());
            }
        }
    }
}