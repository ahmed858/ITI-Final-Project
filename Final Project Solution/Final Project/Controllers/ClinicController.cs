using Final_Project.Models.DomainModels;
using Final_Project.Repositary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

namespace Final_Project.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ClinicController : Controller
    {

        IRepository<Clinic> repostory;
        private readonly UserManager<IdentityUser> userManager;

        //private IProduct Product;
        public ClinicController(IRepository<Clinic> _repostory)
        {
            repostory = _repostory;
        }

        public IActionResult Index()
        {
            
            return View(repostory.GetAll());
        }


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Clinic NewClinic)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    //if(userId == null)
                    //{

                    repostory.Add(NewClinic);
                    repostory.Save();
                    //return LocalRedirect("/Home/Index");
                    TempData["NewDeptID"] = NewClinic.Name;
                    //ViewBag.CreatedClinic= NewClinic;
                    return View();

                    //}


                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Clinic is invalid " + ex.Message);
                }
            }


            return View(NewClinic);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(repostory.GetByID(id));
        }


        [HttpPost]
        //[AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Clinic ClinicNew)
        {

            Clinic ClinicEdited = repostory.GetByID(id);
            if (ModelState.IsValid)
            {

                //var userID = ProductEdited.UserID;
                if (ClinicEdited != null)
                {
                    ClinicEdited.Name = ClinicNew.Name;
                    ClinicEdited.Email = ClinicNew.Email;
                    ClinicEdited.Address = ClinicNew.Address;
                }
                //repostory.Update(ProductEdited);
                repostory.Save();
                TempData["NewDeptID"] = ClinicNew.Name;
                return View();
             }
       
            return View(repostory.GetByID(id));
       }

        public IActionResult Delete(int id)
        {
            repostory.Delete(id);
            repostory.Save();
            return View();

        }


        public IActionResult Details(int id)
        {
            if (repostory.GetByID(id) == null)
            {
                return NotFound();
            }
            return View(repostory.GetByID(id));
        }


    }
}






    

