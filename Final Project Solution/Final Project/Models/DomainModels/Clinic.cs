namespace Final_Project.Models.DomainModels
{
    public class Clinic
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<PhoneClinic>? PhoneClinics { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Clinic_Area>? Clinic_Areas { get; set; }
        public List<Clinic_patient>? Clinic_Patients { get; set; }
        public List<ApplicationUser>? Clinic_Doctors { get; set; }
    }

}
