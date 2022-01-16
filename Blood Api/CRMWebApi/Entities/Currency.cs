namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class Currency : AuditField
    {
        public string CurrencyName { get; set; }

        public string CurrencyTitle { get; set; }

        public string CurrencySymbol { get; set; }
    }
}