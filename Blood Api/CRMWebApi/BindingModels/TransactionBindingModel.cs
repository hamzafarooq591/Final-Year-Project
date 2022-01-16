namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class TransactionBindingModel
    {
        public string TransactionDescription { get; set; }
        public int? TransactionId { get; set; }
        public float Amount { get; set; }
        public int AccountId { get; set; }

        public bool TransactionType { get; set; }

        public int? RelatedEntityId { get; set; }
    }
}

