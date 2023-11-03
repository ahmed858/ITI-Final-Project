using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models.DomainModels
{
    public class Doctor_patient
    {
        public string? ExaminationDescription { get; set; }
        public DateTime? Date_Examin { get; set; }
        [ForeignKey(nameof(Doctor))]
        public string? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        [ForeignKey(nameof(Patient))]
        public string? PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
