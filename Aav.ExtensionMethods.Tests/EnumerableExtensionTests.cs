using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Aav.ExtensionMethods.Tests
{
    public class EnumerableExtensionTests
    {
        [TestFixture]
        public class ForEach
        {
            [Test]
            public void ActionExecutes()
            {
                var targets = new List<string>
                    {
                        "Arthur",
                        "Vanderbilt"
                    };

                var results = new List<string>();

                Action<string> reverse = s => results.Add(s.Reverse());

                targets.ForEach<string>(reverse);

                foreach (var target in targets)
                    results.FirstOrDefault(t => t == target.Reverse()).Should().NotBe(default(string));
            }
        }
    }
}