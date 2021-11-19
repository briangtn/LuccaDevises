using System;
namespace LuccaDevises.Exceptions
{
    public class LuccaDevisesException : Exception
    {
        public LuccaDevisesException()
        {
        }

        public LuccaDevisesException(string message)
            : base(message)
        {
        }

        public LuccaDevisesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
