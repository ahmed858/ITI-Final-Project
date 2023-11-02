using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models.DomainModels
{
    public class PatientExamination

    {
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set;}

        public Patient Patient {  get; set;}
        public string ExaminationDescribtion { get; set;}
        
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }



    }
}
