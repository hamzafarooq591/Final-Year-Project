namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class InvoiceSummary : AuditField
    {
        public int TotalBilled { get; set; }

        public int TotalPaid { get; set; }

        public int TotalPending { get; set; }

    }
}