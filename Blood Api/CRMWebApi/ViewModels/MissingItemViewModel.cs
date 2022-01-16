 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class MissingItemViewModel : IAuditFieldViewModel
    {
        public int MissingItemId { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string ItemDate { get; set; }

        public int ItemQuantity { get; set; }

        public string Comments { get; set; }


        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
        
    }
}

