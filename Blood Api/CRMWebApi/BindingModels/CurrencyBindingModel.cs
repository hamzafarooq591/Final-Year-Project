namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CurrencyBindingModel
    {
        public int? CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencyTitle { get; set; }

        public string CurrencySymbol { get; set; }

    }
}

