namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NashCompany : AuditField
    {
        public string Description { get; set; }
        public string Name { get; set; }

        [ForeignKey("ImageId")]
        public ImageUpload CompanyImage { get; set; }
        public int ImageId { get; set; }
    }
}

