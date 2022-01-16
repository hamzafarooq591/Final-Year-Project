namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsLetterSubscriberBindingModel
    {
        public int? NewsLetterSubscriberId { get; set; }

        public int NashUserId { get; set; }
        public string NashUserEmailAddress { get; set; }

        public bool IsActive { get; set; }
    }
}

