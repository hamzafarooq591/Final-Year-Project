namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ImportPaymentBindingModel
    {
        public int? ImportPaymentId { get; set; }

        public int CompanyId { get; set; }

        public int? CurrencyId { get; set; }

        public int? BankAccountId { get; set; }

        public int PaymentTypeId { get; set; }

        public int PayToTypeId { get; set; }

        public int? MoneyChangerId { get; set; }

        public string ChequeNo { get; set; }

        public int PayToId { get; set; }

        public float ExchangeRate { get; set; }
        public float TransferAmount { get; set; }
        public string TransferDate { get; set; }
        public float BankCharges { get; set; }
        /// <Common Feilds>
        public string ConfirmationDate { get; set; }//vendor/fforwarder/clearingAgent
        public string ConfirmationProof { get; set; }//vendor/fforwarder/clearingAgent
        public string Comments { get; set; }//vendor/fforwarder/clearingAgent
        public float Amount { get; set; }//fforwarder/clearingAgent
        public float OtherAmount { get; set; }//fforwarder/clearingAgent
        public string OtherAmountDescription { get; set; }//fforwarder/clearingAgent
    }
}

