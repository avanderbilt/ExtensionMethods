using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Aav.ExtensionMethods
{
    /// <summary>
    /// Integer Extension Methods
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Returns a series of integers, from the target of the extension to 
        /// the specified last integer.
        /// </summary>
        /// <param name="first">
        /// The target of the extension and the first integer in the series.
        /// </param>
        /// <param name="last">The last integer in the series.</param>
        /// <returns>
        /// A series of integers, from the target of the extension to the 
        /// specified last integer.
        /// </returns>
        public static IEnumerable<int> To(this int first, int last)
        {
            Contract.Ensures(Contract.Result<IEnumerable<int>>() != null);

            for (var i = first; i <= last; i++)
                yield return i;
        }
    }
}