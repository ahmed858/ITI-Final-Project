﻿using Final_Project.Models.DataContext;
using Final_Project.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final_Project.ViewModel;

namespace Final_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly DataContext db;

        public AccountController(SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> roleManager,
            DataContext _db,UserManager<ApplicationUser> userManager)
        {
           
            this.signInManager = _signInManager;
            this.roleManager = roleManager;
            db = _db;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.AllRoles = GetAllRoles();
            return View();
        }
        [HttpGet]

        public IActionResult Registration()
       {
            ViewBag.AllRoles = GetAllRoles();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registration(UserRegisterVM NewUser)
        {
            ViewBag.AllRoles = GetAllRoles(); //view bag to retrun all Role 
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = NewUser.UserName,
                    Email = NewUser.Email,
                    PhoneNumber=NewUser.PhoneNumber,
                    Age=NewUser.Age,
                    Gender = NewUser.Gender,
                    Country = NewUser.Country,
                    City=NewUser.City,
                    Region= NewUser.Region,
                    Doctor_State = NewUser.Doctor_State,
                };
                // Create the new User record
                IdentityResult result = await userManager.CreateAsync(user, NewUser.Password);
                if (result.Succeeded)
                {
                    // Get the last User ID
                     string lastDoctorId = userManager.Users.OrderByDescending(d => d.Id).FirstOrDefault().Id;
                    // Create a new phone User 
                    PhoneUser phone = new PhoneUser()
                    {
                        UserId = lastDoctorId,
                        PhoneNumber = NewUser.PhoneNumber
                    };
                    db.PhoneUsers.Add(phone);
                    if (NewUser.RoleName == "Doctor")
                    {
                        SpecialDoctor specialDoctor = new SpecialDoctor
                        {
                            DoctorId = lastDoctorId,
                            SpecialName = NewUser.SpecialistDoctor
                        };
                        db.SpecialDoctors.Add(specialDoctor);

                    }
                    // Save the changes to the database
                    db.SaveChanges();

                    // Sign in the new  user
                    await signInManager.SignInAsync(user, false);

                    // Add the new  user to the role
                    await userManager.AddToRoleAsync(user, NewUser.RoleName);

                    // Redirect to the login page
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description); //return exeception if not success
                    }
                    return View(NewUser);
                }
            }
            else
            {
                return View(NewUser);
            }
        }
        private List<SelectListItem> GetAllRoles() //method return All Roles 
        {
            var AllRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();

            return AllRoles;
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl = "/Home/Index")
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM userLogin, string? ReturnUrl ="/Home/Index")
        {
            if (ModelState.IsValid)
            {
                ApplicationUser User = await userManager.FindByEmailAsync(userLogin.UserEmail); //Chech if user Exist or not
                if (User != null)
                {
                    //Create cookies
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(User, userLogin.Password, userLogin.IsPersisite, false); //create cookie
                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                        ModelState.AddModelError("Password", "UserName or Password Not Correct");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password Not Correct");
                }
            }
            return View(userLogin);
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync(); //Killed Cookie and logout
            return RedirectToAction("Login");

        }

    }
}
