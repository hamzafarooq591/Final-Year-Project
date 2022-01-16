namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Warehouse : AuditField
    {

        public string WarehouseName { get; set; }

        public string Description { get; set; }
        
    }
}