namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Category : AuditField
    {

        public string CategoryDescription { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey("ImageId")]
        public ImageUpload CategoryImage { get; set; }
        public int ImageId { get; set; }

        public bool IsShowOnHomePage { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }


        //Manufacturer
        [ForeignKey("ManufacturerId")]
        public NashWebApi.Entities.Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }

    }
}

