using System;
namespace LuccaDevises.Exceptions
{
    public class ConfigNotFoundException : LuccaDevisesException
    {
        public ConfigNotFoundException()
        {
        }

        public ConfigNotFoundException(string message)
            : base(message)
        {
        }

        public ConfigNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
