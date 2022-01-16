namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ImageUploadViewModel : IAuditFieldViewModel
    {
        public string ImageUploadDescription { get; set; }

        public int ImageUploadId { get; set; }

        public string Description { get; set; }

        public string fileUrl { get; set; }

        public string Title { get; set; }

        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string LastModified { get; set; }

        public int ParentImageUploadId { get; set; }

        public string ParentImageUploadName { get; set; }
    }
}

