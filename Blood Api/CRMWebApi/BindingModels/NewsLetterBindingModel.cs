namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsLetterBindingModel
    {
        public int? NewsLetterId { get; set; }

        public string NewsLetterSubject { get; set; }

        public string NewsLetterBody { get; set; }
    }
}

