namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class BankBindingModel
    {
        public int? BankId { get; set; }

        public string BankName { get; set; }

        public string BankAddress { get; set; }

        public string BankPhoneNo { get; set; }
    }
}

