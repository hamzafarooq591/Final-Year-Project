namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsConfiguration : AuditField
    {
        public bool ShowOnHomePage { get; set; }

        public int NewsToDisplay { get; set; }

        public int NewsArchivePageSize { get; set; }

        public bool UnregisteredComments { get; set; }

        public bool RSSFeedsLink { get; set; }

    }
}