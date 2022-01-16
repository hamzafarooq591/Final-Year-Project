 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ProductWarrantyViewModel : IAuditFieldViewModel
    {
        public int ProductWarrantyId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int WarrantyModeId { get; set; }
        public string WarrantyModeTitle { get; set; }

        public string SerialMAC { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

