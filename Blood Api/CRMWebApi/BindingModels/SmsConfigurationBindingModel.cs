namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class SmsConfigurationBindingModel
    {
        public int? SmsConfigurationId { get; set; }

        public int SmsTypeId { get; set; }
        public string SmsTypeTitle { get; set; }

        public string URL { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string DeviceName { get; set; }
    }
}

