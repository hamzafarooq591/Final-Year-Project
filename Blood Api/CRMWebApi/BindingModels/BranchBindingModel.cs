namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class BranchBindingModel
    {
        public string BranchDescription { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public int CompanyId { get; set; }
    }
}

