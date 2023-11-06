using Final_Project.Models.DataContext;
using Final_Project.Models.DomainModels;
using Final_Project.Repositary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    public class DoctorController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly UserRepositry userRepositry;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly DataContext db;

        public DoctorController(SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> roleManager,
            DataContext _db, UserManager<ApplicationUser> userManager, UserRepositry _userRepositry)
        {

            this.signInManager = _signInManager;
            this.roleManager = roleManager;
            db = _db;
            this.userManager = userManager;
            userRepositry = _userRepositry;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detailes(string id)
        {
            var doctor = userRepositry.GetByIDstring(id);
            ViewBag.specialDoctor=db.SpecialDoctors.FirstOrDefault(d=>d.DoctorId==doctor.Id).SpecialName;
            return View(doctor);
        }
    }
}
