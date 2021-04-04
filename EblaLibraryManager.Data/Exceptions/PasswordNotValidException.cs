using System;

namespace EblaLibraryManager.Data.Exceptions
{
    public class PasswordNotValidException : Exception
    {
        public PasswordNotValidException()
        {
        }

        public PasswordNotValidException(string message) : base(message)
        {
        }

        public PasswordNotValidException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
