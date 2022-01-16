 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class DesignationViewModel : IAuditFieldViewModel
    {
        public string DesignationDescription { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

