using FinalEMR.DataAccess.Data;
using FinalEMR.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEMR.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Prescription = new PrescriptionRepository(_db);
            SP_Call = new SP_Call(_db);
            Allergy = new AllergyRepository(_db);
            Patient = new PatientRepository(_db);
            Doctor = new DoctorRepository(_db);
            Nurse = new NurseRepository(_db);
            PatientDetails = new PatientDetailsRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        public IPrescriptionRepository Prescription { get; private set; }
        public IAllergyRepository Allergy { get; private set; }
        public IPatientRepository Patient { get; private set; }
        public INurseRepository Nurse { get; private set; }
        public IDoctorRepository Doctor { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IPatientDetailsRepository PatientDetails { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
