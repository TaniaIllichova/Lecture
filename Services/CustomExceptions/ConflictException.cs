using System;

namespace Services.CustomExceptions
{
    [Serializable]
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        { }
    }
}