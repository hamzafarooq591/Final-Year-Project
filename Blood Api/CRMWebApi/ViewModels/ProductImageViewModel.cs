 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ProductImageViewModel : IAuditFieldViewModel
    {
        public int ProductImageId { get; set; }

        public int ImageId { get; set; }


        public int ProductId { get; set; }


        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

