namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class PaymentType : AuditField
    {
        public string Title { get; set; }

        public string Description { get; set; }
            
    }
}