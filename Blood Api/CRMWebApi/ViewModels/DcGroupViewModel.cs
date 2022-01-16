 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class DcGroupViewModel : IAuditFieldViewModel
    {

        public int DcGroupId { get; set; }

        public string DcGroupDescription { get; set; }

        public string DcGroupTitle { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

