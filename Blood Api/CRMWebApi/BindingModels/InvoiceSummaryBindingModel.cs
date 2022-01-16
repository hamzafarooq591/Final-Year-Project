namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class InvoiceSummaryBindingModel
    {
        public int? InvoiceSummaryId { get; set; }

        public int TotalBilled { get; set; }

        public int TotalPaid { get; set; }

        public int TotalPending { get; set; }

    }
}

