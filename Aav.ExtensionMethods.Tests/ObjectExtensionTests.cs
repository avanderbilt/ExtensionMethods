using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

namespace Aav.ExtensionMethods.Tests
{
    public class ObjectExtensionTests
    {
        [TestFixture]
        public class NullableToString
        {
            private readonly List<object> _notNullOrEmpty;
            private readonly List<object> _nullOrEmpty;

            public NullableToString()
            {
                _notNullOrEmpty = new List<object> {"   \n\n\tThe String\n", "A value that isn't empty or null."};
                _nullOrEmpty = new List<object> {DBNull.Value, string.Empty, " \n\t \r", null};
            }

            [Test]
            public void FormatsCorrectly([ValueSource("_notNullOrEmpty")] object value)
            {
                value.NullableToString().Should().Be(value.ToString().Trim());
            }

            [Test]
            public void HandlesNullAndEmpty([ValueSource("_nullOrEmpty")] object value)
            {
                value.NullableToString().Should().BeNull();
            }
        }

        [TestFixture]
        public class NullableToInteger
        {
            private readonly List<object> _validValues;
            private readonly List<object> _invalidValues;
            private readonly List<object> _nullOrEmpty;

            public NullableToInteger()
            {
                _validValues = new List<object>
                    {
                        (-1).ToString(CultureInfo.InvariantCulture),
                        0.ToString(CultureInfo.InvariantCulture),
                        1.ToString(CultureInfo.InvariantCulture),
                        2.ToString(CultureInfo.InvariantCulture),
                        string.Format("\t\t{0}\n  \r", 3.ToString(CultureInfo.InvariantCulture)),
                        int.MaxValue,
                        int.MaxValue.ToString(CultureInfo.InvariantCulture)
                    };
                _invalidValues = new List<object> {Guid.Empty, Guid.Empty.ToString(), int.MaxValue + 1L};
                _nullOrEmpty = new List<object> {DBNull.Value, string.Empty, " \n\t \r", null};
            }

            [Test]
            public void FormatsCorrectly([ValueSource("_validValues")] object value)
            {
                value.NullableToInteger().Should().Be(int.Parse(value.ToString().Trim()));
            }

            [Test]
            public void HandlesInvalidValues([ValueSource("_invalidValues")] object value)
            {
                value.NullableToInteger().Should().NotHaveValue();
            }

            [Test]
            public void HandlesNullAndEmpty([ValueSource("_nullOrEmpty")] object value)
            {
                value.NullableToInteger().Should().NotHaveValue();
            }
        }

        [TestFixture]
        public class NullableToLong
        {
            private readonly List<object> _validValues;
            private readonly List<object> _invalidValues;
            private readonly List<object> _nullOrEmpty;

            public NullableToLong()
            {
                _validValues = new List<object>
                    {
                        (-1).ToString(CultureInfo.InvariantCulture),
                        0.ToString(CultureInfo.InvariantCulture),
                        1.ToString(CultureInfo.InvariantCulture),
                        2.ToString(CultureInfo.InvariantCulture),
                        string.Format("\t\t{0}\n  \r", 3.ToString(CultureInfo.InvariantCulture)),
                        long.MaxValue,
                        long.MaxValue.ToString(CultureInfo.InvariantCulture)
                    };
                _invalidValues = new List<object> {Guid.Empty, Guid.Empty.ToString(), long.MaxValue + 1D};
                _nullOrEmpty = new List<object> {DBNull.Value, string.Empty, " \n\t \r", null};
            }

            [Test]
            public void FormatsCorrectly([ValueSource("_validValues")] object value)
            {
                value.NullableToLong().Should().Be(long.Parse(value.ToString().Trim()));
            }

            [Test]
            public void HandlesInvalidValues([ValueSource("_invalidValues")] object value)
            {
                value.NullableToLong().Should().NotHaveValue();
            }

            [Test]
            public void HandlesNullAndEmpty([ValueSource("_nullOrEmpty")] object value)
            {
                value.NullableToLong().Should().NotHaveValue();
            }
        }

        [TestFixture]
        public class NullableToDouble
        {
            private readonly List<object> _validValues;
            private readonly List<object> _invalidValues;
            private readonly List<object> _nullOrEmpty;

            public NullableToDouble()
            {
                _validValues = new List<object>
                    {
                        (-1.5).ToString(CultureInfo.InvariantCulture),
                        0.5D,
                        1F,
                        2.ToString(CultureInfo.InvariantCulture),
                        string.Format("\t\t{0}\n  \r", 3.ToString(CultureInfo.InvariantCulture))
                    };
                _invalidValues = new List<object> {Guid.Empty, Guid.Empty.ToString()};
                _nullOrEmpty = new List<object> {DBNull.Value, string.Empty, " \n\t \r", null};
            }

            [Test]
            public void FormatsCorrectly([ValueSource("_validValues")] object value)
            {
                value.NullableToDouble().Should().Be(double.Parse(value.ToString().Trim()));
            }

            [Test]
            public void HandlesInvalidValues([ValueSource("_invalidValues")] object value)
            {
                value.NullableToDouble().Should().NotHaveValue();
            }

            [Test]
            public void HandlesNullAndEmpty([ValueSource("_nullOrEmpty")] object value)
            {
                value.NullableToDouble().Should().NotHaveValue();
            }
        }
    }
}