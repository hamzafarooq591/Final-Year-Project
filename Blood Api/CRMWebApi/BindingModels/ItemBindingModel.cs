namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ItemBindingModel
    {
       
        public int? ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string Rate { get; set; }

        public decimal QuantityWeightKG { get; set; }

        public decimal MilingRate { get; set; }

        public decimal PackagingRate { get; set; }
    }
}

