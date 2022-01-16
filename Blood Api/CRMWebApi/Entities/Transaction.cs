namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Transaction : AuditField
    {
        public string TransactionDescription { get; set; }
        public float Amount { get; set; }

        // TransactionType == true is Credit and TransactionType == false is Debit
        public bool TransactionType { get; set; } 

        [ForeignKey("AccountId")]
        public NashWebApi.Entities.Account Account { get; set; }
        public int AccountId { get; set; }

        public int? RelatedEntityId { get; set; }
    }
}

