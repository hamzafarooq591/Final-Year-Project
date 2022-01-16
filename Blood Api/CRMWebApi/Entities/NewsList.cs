namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsList : AuditField
    {
        public string NewsListTitle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsPublished { get; set; }

    }
}