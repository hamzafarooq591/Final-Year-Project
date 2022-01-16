 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WPQuantityViewModel : IAuditFieldViewModel
    {
        public int WPQuantityId { get; set; }

        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

        //public int ParentCategoryId { get; set; }
        //public string ParentCategoryName { get; set; }

    }
}

