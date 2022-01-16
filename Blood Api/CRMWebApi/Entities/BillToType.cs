namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class BillToType : AuditField
    {
        public string Title { get; set; }

        public string Description { get; set; }
            
    }
}