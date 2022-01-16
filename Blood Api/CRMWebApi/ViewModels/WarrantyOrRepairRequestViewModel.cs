 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WarrantyOrRepairRequestViewModel : IAuditFieldViewModel
    {
        public int WarrantyOrRepairRequestId { get; set; }

        public DateTime RequestDate { get; set; }

        public string MacAddress { get; set; }

        public string ProblemType { get; set; }

        public string Comments { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public int WarrantyStatusId { get; set; }
        public string StatusTitle { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

