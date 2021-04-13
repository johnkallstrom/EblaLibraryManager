using System;

namespace EblaLibraryManager.Data.Exceptions
{
    public class BookNotAvailableException : Exception
    {
        public BookNotAvailableException()
        {
        }

        public BookNotAvailableException(string message) : base(message)
        {
        }

        public BookNotAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
