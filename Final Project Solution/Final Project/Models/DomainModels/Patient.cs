﻿using Microsoft.AspNetCore.Identity;

namespace Final_Project.Models.DomainModels
{
    public class Patient: ApplicationUser
    {
     
        //public string Id { get; set; }
        //public string? Name { get; set; }
        //public int? Phone { get; set; }
        //public string? Email { get; set; }

        // Address
        //public string? Country { get; set; }
        //public string? City { get; set; }
        //public string? Region { get; set; }
        //public string? Gender { get; set; }
        //public int? Age { get; set; }
        //public ICollection<PatientExamination>? PatientHistroy { get; set; }
        public ICollection<Clinic_patient>? Clinic_Patients { get; set; }
        public ICollection<Clinic_Area>? Clinic_Areas { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<Doctor_patient>? Doctor_Patients { get; set; }

    }
}
