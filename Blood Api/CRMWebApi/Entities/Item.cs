namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Item : AuditField
    {

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string Rate { get; set; }

        public decimal QuantityWeightKG { get; set; }

        public decimal MilingRate { get; set; }

        public decimal PackagingRate { get; set; }

    }
}