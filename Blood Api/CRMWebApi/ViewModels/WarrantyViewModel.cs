 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WarrantyViewModel : IAuditFieldViewModel
    {
        public int WarrantyId { get; set; }

        public int OrderId { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string SerialMAC { get; set; }

        public string ReplacementSerialMAC { get; set; }

        public int WarrantyModeId { get; set; }
        public string WarrantyModePeriod { get; set; }

        public DateTime WarrantyStartDate { get; set; }

        public DateTime WarrantyEndDate { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

