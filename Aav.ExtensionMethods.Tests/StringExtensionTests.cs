using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Aav.ExtensionMethods.Tests
{
    public class StringExtensionTests
    {
        [TestFixture]
        public class CleansePhoneNumber
        {
            private readonly Dictionary<string, long> _validValues;
            private readonly List<string> _nullOrEmpty;

            public CleansePhoneNumber()
            {
                _validValues = new Dictionary<string, long> {{"0)0(0-0 0.0,0", 0}, {"1)2(3-4 5.6,7", 1234567}};
                _nullOrEmpty = new List<string> {string.Empty, @"\n\t\t    \r"};
            }

            [Test]
            public void CorrectFormat([ValueSource("_validValues")] KeyValuePair<string, long> value)
            {
                value.Key.CleansePhoneNumber().Should().Be(value.Value);
            }

            [Test]
            public void HandlesNonNumeric()
            {
                "ABC)ABC(ABC-ABC ABC.ABC,ABC".CleansePhoneNumber().Should().NotHaveValue();
            }

            [Test]
            public void HandlesNullAndEmpty([ValueSource("_nullOrEmpty")] string value)
            {
                value.CleansePhoneNumber().Should().NotHaveValue();
            }
        }

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
                AssertionExtensions.Should((object) value.Key.ToType()).Be(value.Value);
            }

            [Test]
            public void HandlesInvalidValues([ValueSource("_invalidValues")] string value)
            {
                AssertionExtensions.Should((object) value.ToType()).BeNull();
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

        [TestFixture]
        public class Repeat
        {
            public class Repetition
            {
                public string Input { get; set; }
                public string Output { get; set; }
                public uint Count { get; set; }
            }

            private readonly List<Repetition> _validValues;
            private readonly Dictionary<string, uint> _nullOrEmptyValues;

            public Repeat()
            {
                _validValues = new List<Repetition>
                    {
                        new Repetition {Input = "A", Output = "AAAAA", Count = 5},
                        new Repetition {Input = "ABC", Output = "ABCABC", Count = 2},
                        new Repetition {Input = "HELLO", Output = "HELLO", Count = 1}
                    };

                _nullOrEmptyValues = new Dictionary<string, uint>
                    {
                        {"HELLO", 0},
                        {"\n\t\t\r\r ", 6},
                        {string.Empty, 4}
                    };
            }

            [Test]
            public void CorrectFormat([ValueSource("_validValues")] Repetition value)
            {
                value.Input.Repeat(value.Count).Should().Be(value.Output);
            }

            [Test]
            public void HandlesNullAndEmpty([ValueSource("_nullOrEmptyValues")] KeyValuePair<string, uint> value)
            {
                value.Key.Repeat(value.Value).Should().BeNull();
            }
        }
    }
}