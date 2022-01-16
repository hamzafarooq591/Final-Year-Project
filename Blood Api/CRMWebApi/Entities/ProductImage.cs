namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductImage : AuditField
    {
        [ForeignKey("ProductId")]
        public NashWebApi.Entities.Product Product { get; set; }
        public int ProductId { get; set; }


        [ForeignKey("ImageId")]
        public ImageUpload ProductImageUpload { get; set; }
        public int ImageId { get; set; }

    }
}

