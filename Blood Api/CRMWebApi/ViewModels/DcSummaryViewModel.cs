 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class DcSummaryViewModel : IAuditFieldViewModel
    {
        public int DcSummaryId { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int DcGroupId { get; set; }
        public string DcGroupTitle { get; set; }

        public string DcSummaryDate { get; set; }

        public int Transfered { get; set; }

        public int Received { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

