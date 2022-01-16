namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Order : AuditField
    {
        public DateTime OrderPlacementDate { get; set; }

        public int OrderQuantity { get; set; }

        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("CustomerId")]
        public NashWebApi.Entities.Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("OrderStatusId")]
        public NashWebApi.Entities.Approval Approval { get; set; }
        public int OrderStatusId { get; set; }

        [ForeignKey("NashUserId")]
        public NashWebApi.Entities.NashUser NashUser { get; set; }
        public int NashUserId { get; set; }

        [ForeignKey("InvoiceId")]
        public NashWebApi.Entities.InvoiceMaster Invoice { get; set; }
        public int InvoiceId {get;set;}

        //nashuserdi
        //invoice entity
        //companyid
        //branchid
        //approval

    }
}

