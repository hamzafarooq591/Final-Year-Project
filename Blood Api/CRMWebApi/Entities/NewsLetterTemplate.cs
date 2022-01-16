namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsLetterTemplate : AuditField
    {
        public string NewsSubject { get; set; }

        public string NewsTemplate { get; set; }

    }
}