 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ItemViewModel : IAuditFieldViewModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string Rate { get; set; }

        public decimal QuantityWeightKG { get; set; }

        public decimal MilingRate { get; set; }

        public decimal PackagingRate { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

