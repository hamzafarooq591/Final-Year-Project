namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Bank : AuditField
    {

        public string BankName { get; set; }

        public string BankAddress { get; set; }

        public string BankPhoneNo { get; set; }

    }
}