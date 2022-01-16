 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ReturnProductViewModel : IAuditFieldViewModel
    {
        public int ReturnProductId { get; set; }

        public int ReturnQuantity { get; set; }

        public string ReturnProductDate { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BranchName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

