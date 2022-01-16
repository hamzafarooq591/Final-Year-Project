namespace NashWebApi.Exceptions
{
    using System;
    using System.Runtime.CompilerServices;

    public class DataActionResponse
    {
        public object Data { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccessful { get; set; }
    }
}

