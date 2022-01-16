namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class NewsLetter : AuditField
    {

        public string NewsLetterSubject { get; set; }

        public string NewsLetterBody { get; set; }

    }
}