 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class InventoryStockViewModel : IAuditFieldViewModel
    {
        public int InventoryStockId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Available { get; set; }

        public int Returned { get; set; }

        public int Missing { get; set; }

        public int Defected { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

