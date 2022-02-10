using System;

namespace Services.CustomExceptions
{
    [Serializable]
    public class BadArgumentException : Exception
    {
        public BadArgumentException(string message) : base(message)
        { }
    }
}