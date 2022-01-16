namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class FacilityViewModel : IAuditFieldViewModel
    {
        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string Description { get; set; }

        public int? FacilityId { get; set; }

        public string IconName { get; set; }

        public string LastModified { get; set; }

        public string Title { get; set; }
    }
}

