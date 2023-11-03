using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models.DomainModels
{
    public class PhoneClinic
    {
        public int ID { get; set; }
        public int? PhoneNumber {get; set;}
        [ForeignKey(nameof(Clinic))]
        public int? ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
    }

}
