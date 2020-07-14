using System;
using Microsoft.AspNetCore.Identity;

namespace DAS_Capture_The_Flag.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public int Rating { get; set; }
        [PersonalData]
        public string ProfileImageUrl { get; set; }
        [PersonalData]
        public DateTime MemberSince { get; set; }
    }
}
