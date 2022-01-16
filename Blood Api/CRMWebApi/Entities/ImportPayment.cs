namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class ImportPayment : AuditField
    {
        [ForeignKey("CompanyId")]
        public NashWebApi.Entities.NashCompany Company { get; set; }
        public int? CompanyId { get; set; }

        [ForeignKey("CurrencyId")]
        public NashWebApi.Entities.Currency Currency { get; set; }
        public int? CurrencyId { get; set; }

        [ForeignKey("BankAccountId")]
        public NashWebApi.Entities.BankAccount BankAccount { get; set; }
        public int? BankAccountId { get; set; }

        [ForeignKey("PaymentTypeId")]//Cash/Cheque/PayOrder
        public NashWebApi.Entities.PaymentType PaymentType { get; set; }
        public int PaymentTypeId { get; set; }

        [ForeignKey("PayToTypeId")]
        public NashWebApi.Entities.PayToType PayToType { get; set; }
        public int PayToTypeId { get; set; }

        [ForeignKey("MoneyChangerId")]
        public NashWebApi.Entities.MoneyChanger MoneyChanger { get; set; }
        public int? MoneyChangerId { get; set; }

        public string ChequeNo { get; set; }

        public int PayToId { get; set; }

        public float ExchangeRate { get; set; }
        public float TransferAmount { get; set; }
        public DateTime? TransferDate { get; set; }
        public float BankCharges { get; set; }
        
        /// <Common Feilds>
        /// 
        public DateTime ConfirmationDate { get; set; }//vendor/fforwarder/clearingAgent
        public string ConfirmationProof { get; set; }//vendor/fforwarder/clearingAgent
        public string Comments { get; set; }//vendor/fforwarder/clearingAgent
        public float Amount { get; set; }//fforwarder/clearingAgent
        public float OtherAmount { get; set; }//fforwarder/clearingAgent
        public string OtherAmountDescription { get; set; }//fforwarder/clearingAgent
    }
}

