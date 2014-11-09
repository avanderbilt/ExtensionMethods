using System;
using FluentAssertions;
using NUnit.Framework;

namespace Aav.ExtensionMethods.Tests
{
    public class DateTimeExtensionTests
    {
        [TestFixture]
        public class ToLiterateString
        {
            [Test]
            public void CorrectFormat()
            {
                var value = new DateTime(1969, 7, 17, 8, 41, 0, 0);

                (string.Format("Arthur Vanderbilt was born {0}", value.ToLiterateString())).Should()
                                                                                           .Be(
                                                                                               "Arthur Vanderbilt was born on Thursday, July 17, 1969 at 8:41:00 AM.");
            }
        }

        [TestFixture]
        public class ToSortableString
        {
            [Test]
            public void CorrectFormat()
            {
                var value = new DateTime(1969, 7, 17, 8, 41, 0, 0);

                const string amSuffix = ": Arthur Vanderbilt's Birthday";
                (string.Format("{0}{1}", value.ToSortableString(), amSuffix)).Should()
                                                                             .Be(string.Format(
                                                                                 "1969-07-17 08:41:00{0}", amSuffix));

                const string pmSuffix = ": Twelve Hours Later";
                (string.Format("{0}{1}", value.AddHours(12).ToSortableString(), pmSuffix)).Should()
                                                                                          .Be(
                                                                                              string.Format(
                                                                                                  "1969-07-17 20:41:00{0}",
                                                                                                  pmSuffix));
            }
        }
    }
}