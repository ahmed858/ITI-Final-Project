using Microsoft.AspNetCore.Identity;

namespace Final_Project.Models.DomainModels
{
    public class ApplicationUser:IdentityUser
    {
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public int? Age { get; set; }
        public string? Doctor_State { get; set; }
        //public int? PhoneNumber { get; set; }


    }
}
