using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models.DomainModels
{
    public class Clinic_Area
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        [ForeignKey(nameof(Clinic))]
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

    }

}
