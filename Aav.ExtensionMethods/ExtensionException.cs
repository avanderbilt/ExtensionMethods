using System;
using System.Runtime.Serialization;

namespace Aav.ExtensionMethods
{
    /// <summary>
    /// An exception class for the extension method library.
    /// </summary>
    [Serializable]
    public class ExtensionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionException"/> class.
        /// </summary>
        public ExtensionException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExtensionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ExtensionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected ExtensionException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}