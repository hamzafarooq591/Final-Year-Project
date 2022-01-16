namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;
    
    public class Customer : AuditField
    {

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhoneNo { get; set; }

        public string CustomerCompanyName { get; set; }

        public bool isTransporter { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public int AccountId { get; set; }

    }
}