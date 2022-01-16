 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class TrailBalanceViewModel
    {

        public int AccountId { get; set; }
        public string AccountName { get; set; }

        public float TotalCredit { get; set; }

        public float TotalDebit { get; set; }

    }
}

