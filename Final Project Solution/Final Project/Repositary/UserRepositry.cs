using Final_Project.Models.DataContext;
using Microsoft.AspNetCore.Identity;

namespace Final_Project.Repositary
{
    public class UserRepositry:Repository<IdentityUser>
    {
        private readonly DataContext db;

        public UserRepositry(DataContext _db):base(_db)
        {
            db = _db;
        }

        public string UploadFile(IFormFile image)
        {

            string uploadsFolder = Path.Combine("wwwroot", "Images");
            string ImageName = image.FileName; //Guid.NewGuid().ToString() + "_" +
            string filePath = Path.Combine(uploadsFolder, ImageName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            return ImageName;

        }
    }
}
