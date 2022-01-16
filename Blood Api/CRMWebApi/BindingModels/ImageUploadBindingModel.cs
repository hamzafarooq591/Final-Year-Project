namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ImageUploadBindingModel
    {
       
        public int? ImageUploadId { get; set; }

        public string Description { get; set; }

        public string fileUrl { get; set; }

        public string Title { get; set; }
    }
}

