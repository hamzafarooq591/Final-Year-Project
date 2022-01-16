namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class AccountBindingModel
    {
        public string AccountDescription { get; set; }
        public int? AccountId { get; set; }
        public int? ParentAccountId { get; set; }
        public string AccountName { get; set; }
        public int BranchId { get; set; }
    }
}

