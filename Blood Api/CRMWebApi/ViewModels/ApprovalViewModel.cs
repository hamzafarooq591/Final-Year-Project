 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ApprovalViewModel : IAuditFieldViewModel
    {

        public int ApprovalId { get; set; }

        public string ApprovalDescription { get; set; }

        public string ApprovalTitle { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

