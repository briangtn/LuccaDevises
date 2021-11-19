using System;
namespace LuccaDevises.Exceptions
{
    public class InvalidConfigException : LuccaDevisesException
    {
        public InvalidConfigException()
        {
        }

        public InvalidConfigException(string message)
            : base(message)
        {
        }

        public InvalidConfigException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
