 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CategoryViewModel : IAuditFieldViewModel
    {
        public string CategoryDescription { get; set; }
        public int CategoryId { get; set; }
        
        public int ImageId { get; set; }
        public string CategoryImageUpload { get; set; }

        public int DisplayOrder { get; set; }
        public string CategoryName { get; set; }

        public bool IsShowOnHomePage { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }


        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

        //public int ParentCategoryId { get; set; }
        //public string ParentCategoryName { get; set; }

    }
}

