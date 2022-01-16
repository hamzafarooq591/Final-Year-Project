namespace NashWebApi.Exceptions.NashHandledException
{
    using System;
    using System.ComponentModel;

    public enum NashHandledExceptionErrorCodes
    {
        [Description("Can not upload new file. File Storage Exceeded")]
        FileStorageExceeded = 0x195,
        NotFound = 0x194
    }
}

