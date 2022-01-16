namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class HomePageSlideViewModel : IAuditFieldViewModel
    {
        public int HomePageSlideId { get; set; }

        public string Comments { get; set; }

        public string PictureURL { get; set; }

        public int SliderImageId { get; set; }
        //public string SlideImage { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Description { get; set; }
        public string LastModified { get; set; }
    }
}

