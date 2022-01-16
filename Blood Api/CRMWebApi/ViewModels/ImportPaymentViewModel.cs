 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ImportPaymentViewModel : IAuditFieldViewModel
    {
        public int ImportPaymentId { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyTitle { get; set; }
        public int BankAccountId { get; set; }
        public string BankAccountTitle { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeTitle { get; set; }
        public int PayToTypeId { get; set; }
        public string PayToTypeTitle { get; set; }
        public int MoneyChangerId { get; set; }
        public string MoneyChangerTitle { get; set; }
        public string ChequeNo { get; set; }

        public int PayToId { get; set; }
        public string PayToName { get; set; }

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
        
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

