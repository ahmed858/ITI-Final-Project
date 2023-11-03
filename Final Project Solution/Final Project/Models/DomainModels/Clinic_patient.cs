using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models.DomainModels
{
    public class Clinic_patient
    {
        public string Clinic_Message { get; set; }
        public DateTime Date_Messge { get; set; }
        [ForeignKey(nameof(Clinic))]
        public int CinicId { get; set; }
        public Clinic Clinic { get; set; }
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

    }

}
