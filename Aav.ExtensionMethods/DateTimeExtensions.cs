using System;
using System.Diagnostics.Contracts;

namespace Aav.ExtensionMethods
{
    /// <summary>
    /// DateTime Extension Methods
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// To a "literate" string, intended for ending sentences.
        /// </summary>
        /// <param name="value">The target of the extension.</param>        
        /// <returns>
        /// The value of the DateTime as "on {long date string} at {long time
        /// string}.
        /// </returns>
        public static string ToLiterateString(this DateTime value)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return string.Format("on {0} at {1}.", value.ToLongDateString(), value.ToLongTimeString());
        }

        /// <summary>
        /// To a sortable string.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>
        /// The value of the DateTime as a sortable date and time string in
        /// the format "yyyy-MM-dd HH:mm:ss".
        /// </returns>
        public static string ToSortableString(this DateTime value)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}