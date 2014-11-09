using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

namespace Aav.ExtensionMethods.Tests
{
    public class BooleanExtensionTests
    {
        [TestFixture]
        public class ConvertFromString
        {
            private readonly Dictionary<string, bool> _validValues;

            private readonly List<string> _invalidValues;

            public ConvertFromString()
            {
                _validValues = new Dictionary<string, bool>
                    {
                        {0.ToString(CultureInfo.InvariantCulture), false},
                        {1.ToString(CultureInfo.InvariantCulture), true},
                        {"Yes", true},
                        {"No", false},
                        {"True", true},
                        {"False", false}
                    };

                _invalidValues = new List<string>
                    {
                        "Invalid",
                        (-1).ToString(CultureInfo.InvariantCulture),
                        2.ToString(CultureInfo.InvariantCulture)
                    };
            }

            [Test]
            public void ValidString([ValueSource("_validValues")] KeyValuePair<string, bool> value)
            {
                default(bool).ConvertFromString(value.Key).Should().Be(value.Value);
                default(bool).ConvertFromString(value.Key.ToLower()).Should().Be(value.Value);
                default(bool).ConvertFromString(value.Key.ToUpper()).Should().Be(value.Value);
            }

            [Test]
            public void InvalidString([ValueSource("_invalidValues")] string value)
            {
                Action convert = () => default(bool).ConvertFromString(value);

                convert.ShouldThrow<ExtensionException>()
                       .WithMessage(string.Format("\"{0}\" could not be converted to a Boolean value.", value));
            }
        }
    }
}