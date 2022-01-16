namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class HomePageSlideBindingModel
    {
        public int? HomePageSlideId { get; set; }

        public string Comments { get; set; }

        public string PictureURL { get; set; }

        public string SlideImage { get; set; }
        public int SlideImageId { get; set; }
    }
}

