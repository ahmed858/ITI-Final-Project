using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models.DomainModels
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? BookDatePatint { get; set; }
        public string? AppointPrice { get; set; }
        public string? AppointState { get; set; }
        [ForeignKey(nameof(Patient))]
        public string? PatientId { get; set; }
        public Patient? Patient  { get; set; }
       
        [ForeignKey(nameof(Doctor))]
        public string? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        [ForeignKey(nameof(Clinic))]
        public int? ClinicId { get; set; }
        public Clinic? Clinic { get; set; }

    }
}
