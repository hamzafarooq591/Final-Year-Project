namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ManufacturerBindingModel
    {
        public string Description { get; set; }
        public int? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public int DisplayOrder { get; set; }
        public string ManufacturerImageUpload { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }

    }
}

