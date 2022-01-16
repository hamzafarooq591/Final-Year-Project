namespace NashWebApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NashUser : AuditField
    {
        public string Address { get; set; }

        public string Bio { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public int? CityId { get; set; }

        public string ContactImageUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public int? BranchId { get; set; }


        [ForeignKey("GenderId")]
        public GenderType Gender { get; set; }

        public int? GenderId { get; set; }

        public bool IsFeatured { get; set; }

        public string LastName { get; set; }

        public string latitute { get; set; }

        public string longitude { get; set; }

        [ForeignKey("NashUserTypeId")]
        public NashUserType NashUserType { get; set; }

        public int NashUserTypeId { get; set; }

        public string password { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string WebsiteUrl { get; set; }

        public string Zipcode { get; set; }

        //branchid as foreignkey
    }
}

