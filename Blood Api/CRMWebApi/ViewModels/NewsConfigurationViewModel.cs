 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsConfigurationViewModel : IAuditFieldViewModel
    {
        public int NewsConfigurationId { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int NewsToDisplay { get; set; }

        public int NewsArchivePageSize { get; set; }

        public bool UnregisteredComments { get; set; }

        public bool RSSFeedsLink { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

