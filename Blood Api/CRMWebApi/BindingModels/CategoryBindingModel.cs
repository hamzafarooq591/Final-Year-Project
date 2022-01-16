namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CategoryBindingModel
    {
        public string CategoryDescription { get; set; }
        public int? CategoryId { get; set; }
        
        public string CategoryName { get; set; }


        public int ImageId { get; set; }
        public string CategoryImageUpload { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsShowOnHomePage { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }

        public int ManufacturerId { get; set; }


        // public int? ParentCategoryId { get; set; }
    }
}

