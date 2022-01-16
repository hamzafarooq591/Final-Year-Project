namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashUserBindingModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? BranchId { get; set; }

        public int? NashUserId { get; set; }

        public int NashUserTypeId { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

    }

    public class NashUserFavouriteBindingModel
    {
        public int? NashUserFavouriteId { get; set; }

        public int BrandId { get; set; }

        public int nashUserId { get; set; }
    }

    public class NashUserSessionBindingModel
    {
        public int? NashUserSessionId { get; set; }

        public int NashUserId { get; set; }

        public bool IsExpired { get; set; }

        public int SessionDuration { get; set; }

        public string SessionKey { get; set; }

        public DateTime? SessionStart { get; set; }

        public DateTime? SessionEnd { get; set; }
    }

    public class AuthendicateBindingModel
    {
        
        public string Username { get; set; }

        public string Password { get; set; }
    }
}

