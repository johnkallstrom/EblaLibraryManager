using System;

namespace EblaLibraryManager.Data.Exceptions
{
    public class EmailNotValidException : Exception
    {
        public EmailNotValidException()
        {
        }

        public EmailNotValidException(string message) : base(message)
        {
        }

        public EmailNotValidException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
