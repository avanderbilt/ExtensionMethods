using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace Aav.ExtensionMethods
{
    /// <summary>
    /// Enumeration Extension Methods
    /// </summary>
    public static class EnumerationExtensions
    {
        /// <summary>
        /// Gets the enumeration's description metadata.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>The target's description metadata.</returns>
        public static string GetDescription(this Enum value)
        {
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<string>() != null);

            var fi = value.GetType().GetField(value.ToString());

            Contract.Assume(fi != null);

            var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);

            var result = attributes.Length > 0 ? attributes[0].Description : value.ToString();

            Contract.Assume(result != null);

            return result;
        }
    }
}