using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModel
{
    public class UserRegisterVM
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Doctor_State { get; set; }
        public string? SpecialistDoctor { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Enter complex password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Matched with Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
    }
}
