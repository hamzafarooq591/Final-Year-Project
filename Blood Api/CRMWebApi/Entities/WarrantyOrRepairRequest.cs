namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;
    public class WarrantyOrRepairRequest : AuditField
    {
        public DateTime RequestDate { get; set; }

        public string MacAddress { get; set; }

        public string ProblemType { get; set; }

        public string Comments { get; set; }

        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("CustomerId")]
        public NashWebApi.Entities.Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("WarrantyStatusId")]
        public NashWebApi.Entities.WarrantyRequestStatus WarrantyRequestStatus { get; set; }
        public int WarrantyStatusId { get; set; }
        
    }
}

