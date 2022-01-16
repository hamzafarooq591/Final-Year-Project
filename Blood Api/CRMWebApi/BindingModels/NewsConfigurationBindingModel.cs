namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsConfigurationBindingModel
    {
        public int? NewsConfigurationId { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int NewsToDisplay { get; set; }

        public int NewsArchivePageSize { get; set; }

        public bool UnregisteredComments { get; set; }

        public bool RSSFeedsLink { get; set; }

    }
}

