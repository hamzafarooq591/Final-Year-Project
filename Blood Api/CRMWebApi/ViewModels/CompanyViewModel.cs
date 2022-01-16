namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CompanyViewModel : IAuditFieldViewModel
    {
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Description { get; set; }
        public string LastModified { get; set; }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }
        public string CompanyImageUpload { get; set; }


    }
}

