namespace NashWebApi.Exceptions.NashHandledException
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class NashHandledExceptionBase : NashException
    {
        public NashHandledExceptionBase(string message, NashHandledExceptionErrorCodes errorCode) : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public NashHandledExceptionErrorCodes ErrorCode { get; set; }
    }
}

