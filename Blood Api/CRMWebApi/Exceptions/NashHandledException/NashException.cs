namespace NashWebApi.Exceptions.NashHandledException
{
    using System;
    using System.Runtime.Serialization;

    public class NashException : Exception
    {
        public NashException()
        {
        }

        public NashException(string message) : base(message)
        {
        }

        public NashException(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context)
        {
        }

        public NashException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

