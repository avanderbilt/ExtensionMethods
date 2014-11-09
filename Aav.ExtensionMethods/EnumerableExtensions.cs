using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Aav.ExtensionMethods
{
    /// <summary>
    /// Enumerable Extension Methods
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Iterates through the Enumerable, executing the supplied delegate
        /// on each element.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <param name="action">
        /// The delegate to execute on each element of the Enumerable.
        /// </param>
        public static void ForEach<T>(this IEnumerable<T> value, Action<T> action)
        {
            Contract.Requires(value != null);
            Contract.Requires(action != null);

            foreach (var element in value)
                action(element);
        }
    }
}