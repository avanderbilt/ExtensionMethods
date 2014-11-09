using System;
using FluentAssertions;
using NUnit.Framework;

namespace Aav.ExtensionMethods.Tests
{
    public class GuidExtensionTests
    {
        [TestFixture]
        public class ToSingleQuotedString
        {
            [Test]
            public void CorrectFormat()
            {
                var value = Guid.Empty;

                value.ToSingleQuotedString().Should().Be(string.Format("'{0}'", value));
            }
        }
    }
}