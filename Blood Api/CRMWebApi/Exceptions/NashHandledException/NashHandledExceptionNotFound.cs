namespace NashWebApi.Exceptions.NashHandledException
{
    using System;

    [Serializable]
    public class NashHandledExceptionNotFound : NashHandledExceptionBase
    {
        private new const NashHandledExceptionErrorCodes ErrorCode = NashHandledExceptionErrorCodes.NotFound;

        public NashHandledExceptionNotFound(string message) : base(message, NashHandledExceptionErrorCodes.NotFound)
        {
        }
    }
}

