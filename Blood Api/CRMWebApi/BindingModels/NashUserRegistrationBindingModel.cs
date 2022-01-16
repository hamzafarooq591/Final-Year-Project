namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashUserRegistrationBindingModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NashUserTypeId { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

    }
}

