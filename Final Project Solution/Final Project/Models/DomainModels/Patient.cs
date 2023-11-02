namespace Final_Project.Models.DomainModels
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Address
        public string Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public ICollection<PatientExamination>? PatientHistroy { get; set; }



    }
}
