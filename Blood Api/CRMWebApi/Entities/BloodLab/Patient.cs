using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NashWebApi.Entities.BloodLab
{
    public class Patient : AuditField
    {
        public string FullName { get; set; }
       
        public string Address { get; set; }
        public string PhoneNumber  { get; set; }

        public string Country { get; set; }
        public string Gender { get; set; }

        public string City { get; set; }

        public string Province { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsVerified { get; set; }

        public bool IsActive { get; set; }

        public string VerificationCode { get; set; }



    }
}