using System;
using System.Diagnostics.Contracts;

namespace Aav.ExtensionMethods
{
    /// <summary>
    /// Guid Extension Methods
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Converts the Guid to a single-quoted string.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>
        /// The value of the Guid as a string, surrounded by single quotes.
        /// </returns>
        public static string ToSingleQuotedString(this Guid value)
        {
            Contract.Ensures(Contract.Result<string>() != null);
            
            return string.Format("'{0}'", value.ToString().ToUpper());
        }
    }
}