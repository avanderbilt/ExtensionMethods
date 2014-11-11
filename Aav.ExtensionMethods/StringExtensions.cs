using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Aav.ExtensionMethods
{
    /// <summary>
    /// String Extension Methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// "Cleanses" a phone number of certain non-numeric characters.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>
        /// The target, cleansed of certain non-numeric characters.
        /// </returns>
        public static long? CleansePhoneNumber(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            const string pattern = @"[\)\(\-\ \.\,_]";

            var regex = new Regex(pattern);

            var cleanNumberAsString = regex.Replace(value, string.Empty);

            long cleanNumber;

            if (!long.TryParse(cleanNumberAsString, out cleanNumber))
                return null;

            return cleanNumber;
        }

        /// <summary>
        /// Converts the target of the extension from a camel-case string to 
        /// a string of separate, capitalized words.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>
        /// The target, with any camel-case words parsed out into separate,
        /// capitalized words.
        /// </returns>
        public static string SplitCamelCase(this string value)
        {
            return string.IsNullOrWhiteSpace(value)
                       ? null
                       : Regex.Replace(value, @"(?=\p{Lu}\p{Ll})|(?<=\p{Ll})(?=\p{Lu})", " ", RegexOptions.Compiled)
                              .Trim();
        }

        /// <summary>
        /// Truncates the target of the extension to the specified maximum
        /// length, adding an ellipsis if space allows.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns>
        /// The target, trimmed and truncated to the specified maximum
        /// length, with an ellipsis on the end if space allows.
        /// </returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value) || maxLength == 0)
                return null;

            var trimmedValue = value.Trim();

            const string ellipsis = "...";

            if (trimmedValue.Length <= maxLength)
                return trimmedValue;

            return maxLength <= ellipsis.Length
                       ? trimmedValue.Substring(0, maxLength)
                       : string.Format("{0}{1}", trimmedValue.Substring(0, maxLength - ellipsis.Length), ellipsis);
        }

        /// <summary>
        /// Return a type that matches the target of the extension's value.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>
        /// A type that matches the target of the extension's value.
        /// </returns>
        public static Type ToType(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : Type.GetType(value);
        }

        /// <summary>
        /// Repeats the specified value.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <param name="count">
        /// The number of times to repeat the target.
        /// </param>
        /// <returns>
        /// The target, repeated the specified number of times.
        /// </returns>
        public static string Repeat(this string value, uint count)
        {
            if (string.IsNullOrWhiteSpace(value) || count == 0)
                return null;

            var sb = new StringBuilder(value, value.Length * (int)count);

            for (var i = 1; i < count; i++)
                sb.Append(value);

            return sb.ToString();
        }

        /// <summary>
        /// Reverse the characters of the target of the extension.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>The target, reversed.</returns>
        public static string Reverse(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : ReverseGraphemeClusters(value);
        }

        private static IEnumerable<string> GraphemeClusters(this string s)
        {
            var enumerator = StringInfo.GetTextElementEnumerator(s);

            while (enumerator.MoveNext())
                yield return (string) enumerator.Current;
        }

        private static string ReverseGraphemeClusters(this string s)
        {
            Contract.Requires(s != null);

            return string.Join("", s.GraphemeClusters().Reverse().ToArray());
        }
    }
}