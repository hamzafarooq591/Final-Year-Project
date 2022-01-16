 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class BranchViewModel : IAuditFieldViewModel
    {
        public string BranchDescription { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }


        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

        //public int ParentCategoryId { get; set; }
        //public string ParentCategoryName { get; set; }

    }
}

