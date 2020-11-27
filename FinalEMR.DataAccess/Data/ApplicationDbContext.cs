using System;
using System.Collections.Generic;
using System.Text;
using FinalEMR.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalEMR.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RecordHeader> RecordHeaders { get; set; }
        public DbSet<PatientDetails> PatientDetails { get; set; }
    }
}
