using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Aav.ExtensionMethods.Tests
{
    public class StringExtensionTests
    {
        [TestFixture]
        public class SplitCamelCase
        {
            private readonly Dictionary<string, string> _values;

            public SplitCamelCase()
            {
                _values = new Dictionary<string, string>
                    {
                        {"ThisIsMyString", "This Is My String"},
                        {"this is my string", "this is my string"},
                        {"THIsISMyString", "TH Is IS My String"}
                    };
            }

            [Test]
            public void CorrectFormat([ValueSource("_values")] KeyValuePair<string, string> value)
            {
                value.Key.SplitCamelCase().Should().Be(value.Value);
            }
        }

        [TestFixture]
        public class Truncate
        {
            public class TruncationData
            {
                public string OriginalValue { get; set; }
                public int Length { get; set; }
                public string ExpectedValue { get; set; }
            }

            private readonly List<TruncationData> _values;
            private readonly Dictionary<string, int> _emptyValues;

            public Truncate()
            {
                _values = new List<TruncationData>
                    {
                        new TruncationData {OriginalValue = "0123456789", Length = 4, ExpectedValue = "0..."},
                        new TruncationData
                            {
                                OriginalValue = "\t\t\t0123456789\r\r\n\n    \t\t",
                                Length = 4,
                                ExpectedValue = "0..."
                            },
                        new TruncationData {OriginalValue = "0", Length = 4, ExpectedValue = "0"},
                        new TruncationData {OriginalValue = "0", Length = 1, ExpectedValue = "0"},
                        new TruncationData {OriginalValue = "0123", Length = 3, ExpectedValue = "012"},
                        new TruncationData {OriginalValue = "0123", Length = 4, ExpectedValue = "0123"}
                    };

                _emptyValues = new Dictionary<string, int> {{"0", 0}, {" \t\n\r", 4}};
            }

            [Test]
            public void CorrectFormat([ValueSource("_values")] TruncationData value)
            {
                value.OriginalValue.Truncate(value.Length).Should().Be(value.ExpectedValue);
            }

            [Test]
            public void HandlesEmptyValues([ValueSource("_emptyValues")] KeyValuePair<string, int> value)
            {
                value.Key.Truncate(value.Value).Should().BeNull();
            }
        }

        [TestFixture]
        public class ToType
        {
            private readonly Dictionary<string, Type> _values;
            private readonly List<string> _invalidValues;

            public ToType()
            {
                _values = new Dictionary<string, Type>
                    {
                        {"System.Int32", typeof (int)},
                        {"System.String", typeof (string)}
                    };

                _invalidValues = new List<string> {"Not a type.", Guid.Empty.ToString()};
            }

            [Test]
            public void CorrectFormat([ValueSource("_values")] KeyValuePair<string, Type> value)
            {
                value.Key.ToType().Should().Be(value.Value);
            }

            [Test]
            public void HandlesInvalidValues([ValueSource("_invalidValues")] string value)
            {
                value.ToType().Should().BeNull();
            }
        }

        [TestFixture]
        public class Reverse
        {
            private readonly Dictionary<string, string> _values;

            public Reverse()
            {
                _values = new Dictionary<string, string>
                    {
                        {"Arthur Vanderbilt", "tlibrednaV ruhtrA"},
                        {"Les Mise\u0301rables", "selbare\u0301siM seL"}
                    };
            }

            [Test]
            public void CorrectFormat([ValueSource("_values")] KeyValuePair<string, string> value)
            {
                value.Key.Reverse().Should().Be(value.Value);
            }
        }
    }
}