namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class ImageUpload : AuditField
    {
        public string Description { get; set; }

        public string fileUrl { get; set; }

        public string Title { get; set; }
    }
}

