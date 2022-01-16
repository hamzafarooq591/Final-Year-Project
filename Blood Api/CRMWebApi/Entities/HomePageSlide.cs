namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HomePageSlide : AuditField
    {
        public string Comments { get; set; }

        public string PictureURL { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("SlideImageId")]
        public ImageUpload SlideImage { get; set; }
        public int SlideImageId { get; set; }
    }
}

