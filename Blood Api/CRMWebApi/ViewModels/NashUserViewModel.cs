namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashUserViewModel : IAuditFieldViewModel
    {
        public string Address { get; set; }

        public string Bio { get; set; }

        public string City { get; set; }

        public string ContactImageUrl { get; set; }

        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public bool IsFeatured { get; set; }

        public string LastModified { get; set; }

        public string LastName { get; set; }

        public string latitute { get; set; }

        public string longitute { get; set; }

        public int NashUserId { get; set; }

        public int NashUserTypeId { get; set; }

        public string NashUserType { get; set; }

        public string password { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string WebsiteUrl { get; set; }

        public string Zipcode { get; set; }
    }

    public class NashUserFavouriteViewModel : IAuditFieldViewModel
    {
        public int NashUserFavouriteId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int nashUserId { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }

    public class NashUserSessionViewModel : IAuditFieldViewModel
    {
        public int NashUserSessionId { get; set; }

        public int NashUserId { get; set; }

        public bool IsExpired { get; set; }

        public int SessionDuration { get; set; }

        public string SessionKey { get; set; }

        public DateTime? SessionStart { get; set; }

        public DateTime? SessionEnd { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

