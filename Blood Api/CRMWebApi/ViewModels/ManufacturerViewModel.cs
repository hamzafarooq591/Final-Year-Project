namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ManufacturerViewModel : IAuditFieldViewModel
    {
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Description { get; set; }
        public string LastModified { get; set; }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public int ImageId { get; set; }
        public string ManufacturerImageUpload { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
    }
}

