namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer : AuditField
    {
        public string Description { get; set; }

        public string ManufacturerName { get; set; }

        [ForeignKey("ImageId")]
        public ImageUpload ManufacturerImage { get; set; }
        public int ImageId { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        public bool IsActive { get; set; }

    }
}

