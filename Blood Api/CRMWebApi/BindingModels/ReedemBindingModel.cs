namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ReedemBindingModel
    {
        public int? ReedemId { get; set; }

        public int nashUserId { get; set; }

        public int ReedemOfferId { get; set; }

        public Double ReedemLocationLat { get; set; }

        public Double ReedemLocationLon { get; set; }
    }
}

