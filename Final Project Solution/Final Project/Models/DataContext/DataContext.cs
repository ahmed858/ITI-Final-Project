using Final_Project.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models.DataContext
{
    public class DataContext : IdentityDbContext
    {
        public DataContext() : base()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor_patient> Doctor_Patients { get; set; }
        public DbSet<PhoneUser> PhoneUsers { get; set; }
        public DbSet<SpecialDoctor> SpecialDoctors { get; set; }
        public DbSet<PhoneClinic> PhoneClinics { get; set; }
        public DbSet<Clinic_Area> clinic_Areas { get; set; }
        public DbSet<Clinic_patient> Clinic_Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Clinic_patient>()
             .HasKey(m => new { m.CinicId, m.PatientId });
            modelBuilder.Entity<Doctor_patient>()
            .HasKey(m => new { m.DoctorId, m.PatientId });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Doctor", NormalizedName = "DOCTOR" },
                new IdentityRole { Id = "3", Name = "Patient", NormalizedName = "PATIENT" }
               );
        }
    }
}
