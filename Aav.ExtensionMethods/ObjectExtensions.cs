using System;

namespace Aav.ExtensionMethods
{
    /// <summary>
    /// Object Extension Methods
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Return DBNull, null, empty string and whitespace as null,
        /// otherwise return the target of the extension as a trimmed
        /// string.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>
        /// Null if the value of the target is equal to DBNull, null,
        /// whitespace or the empty string. Otherwise the value of the target
        /// is converted to a string, trimmed and returned.
        /// </returns>
        public static string NullableToString(this object value)
        {
            return IsNullOrEmpty(value) ? null : value.ToString().Trim();
        }

        /// <summary>
        /// Return DBNull, null, empty string and whitespace as null,
        /// otherwise return the target of the extension as a nullable
        /// integer.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>
        /// Null if the value of the target is equal to DBNull, null,
        /// whitespace, the empty string or any value that can not be
        /// converted to an integer. Otherwise the value of the target is
        /// converted to an integer and returned.
        /// </returns>
        public static int? NullableToInteger(this object value)
        {
            if (IsNullOrEmpty(value))
                return null;

            if (value.IsLongType())
            {
                var inputAsLong = Convert.ToInt64(value);

                if (inputAsLong <= int.MaxValue)
                    return Convert.ToInt32(value);

                return null;
            }

            if (value is string)
            {
                int result;

                if (int.TryParse(value.ToString(), out result))
                    return result;

                return null;
            }

            return null;
        }

        /// <summary>
        /// Return DBNull, null, empty string and whitespace as null,
        /// otherwise return the target of the extension as a nullable
        /// long.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>
        /// Null if the value of the target is equal to DBNull, null,
        /// whitespace, the empty string or any value that can not be
        /// converted to a long. Otherwise the value of the target is
        /// converted to a long and returned.
        /// </returns>
        public static long? NullableToLong(this object value)
        {
            if (IsNullOrEmpty(value))
                return null;

            if (value.IsLongType())
                return Convert.ToInt64(value);

            if (value is string)
            {
                long result;

                if (long.TryParse(value.ToString(), out result))
                    return result;

                return null;
            }

            return null;
        }

        /// <summary>
        /// Return DBNull, null, empty string and whitespace as null,
        /// otherwise return the target of the extension as a nullable
        /// long.
        /// </summary>
        /// <param name="value">The target of the extension.</param>
        /// <returns>
        /// Null if the value of the target is equal to DBNull, null,
        /// whitespace, the empty string or any value that can not be
        /// converted to a long. Otherwise the value of the target is
        /// converted to a long and returned.
        /// </returns>
        public static double? NullableToDouble(this object value)
        {
            if (IsNullOrEmpty(value))
                return null;

            if (value.IsNumericType())
                return Convert.ToDouble(value);

            if (value is string)
            {
                double result;

                if (double.TryParse(value.ToString(), out result))
                    return result;

                return null;
            }

            return null;
        }

        private static bool IsNullOrEmpty(object value)
        {
            return value == null || value == DBNull.Value || value.ToString().Trim().Length == 0;
        }

        private static bool IsNumericType(this object value)
        {
            return value.IsLongType()
                   || value is sbyte
                   || value is byte
                   || value is float
                   || value is double
                   || value is decimal;
        }

        private static bool IsIntegerType(this object value)
        {
            return value is short
                   || value is int
                   || value is ushort
                   || value is uint;
        }

        private static bool IsLongType(this object value)
        {
            return value.IsIntegerType()
                   || value is long
                   || value is ulong;
        }
    }
}