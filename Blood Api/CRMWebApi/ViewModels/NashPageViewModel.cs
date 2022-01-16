namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashPageViewModel : IAuditFieldViewModel
    {
        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string Description { get; set; }

        public string LastModified { get; set; }

        public int NashPageId { get; set; }

        public int ParentPageId { get; set; }

        public string ParentPageName { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}

