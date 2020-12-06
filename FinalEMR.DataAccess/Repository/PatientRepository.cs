using FinalEMR.DataAccess.Data;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalEMR.DataAccess.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Patient patient)
        {
            var objFromDb = _db.Patients.FirstOrDefault(s => s.Id == patient.Id);
            if (objFromDb != null)
            {
                if (patient.ImageUrl != null)
                {
                    objFromDb.ImageUrl = patient.ImageUrl;
                }
                objFromDb.FirstName = patient.FirstName;
                objFromDb.LastName = patient.LastName;
                objFromDb.DateOfBirth = patient.DateOfBirth;
                objFromDb.Comments = patient.Comments;/* + System.DateTime.Now;*/
                objFromDb.Height = patient.Height;
                objFromDb.Weight = patient.Weight;
                objFromDb.PhoneNumber = patient.PhoneNumber;
                objFromDb.EmailAddress = patient.EmailAddress;
                objFromDb.Street = patient.Street;
                objFromDb.SocialSecurity = patient.SocialSecurity;
                objFromDb.AllergyId = patient.AllergyId;
                objFromDb.PrescriptionId = patient.PrescriptionId;
                objFromDb.DoctorId = patient.DoctorId;
                objFromDb.NurseId = patient.NurseId;
            }
        }
    }
}