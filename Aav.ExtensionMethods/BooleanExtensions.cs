using System.Diagnostics.Contracts;

namespace Aav.ExtensionMethods
{
    /// <summary>
    /// Boolean Extension Methods
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Converts from a string.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <param name="valueToConvert">The value to convert.</param>
        /// <returns>
        /// Returns true or false based on interpretation of the value if the 
        /// value to convert is convertible to Boolean.
        /// </returns>
        public static bool ConvertFromString(this bool value, string valueToConvert)
        {
            Contract.Requires(valueToConvert != null);

            if (valueToConvert.Trim() == "0")
                return false;

            if (valueToConvert.Trim() == "1")
                return true;

            if (valueToConvert.Trim().ToLower() == "yes")
                return true;

            if (valueToConvert.Trim().ToLower() == "no")
                return false;

            bool result;

            if (bool.TryParse(valueToConvert, out result))
                return result;

            throw new ExtensionException(string.Format("\"{0}\" could not be converted to a Boolean value.",
                                                       valueToConvert));
        }
    }
}