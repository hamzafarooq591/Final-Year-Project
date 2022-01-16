namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class InventoryStock : AuditField
    {
        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }
        
        public int Available { get; set; }/////on purchase goes up on sale gets down//

        public int Returned { get; set; }

        public int Missing { get; set; }

        public int Defected { get; set; }

    }
}