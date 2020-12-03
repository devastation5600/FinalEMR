using FinalEMR.DataAccess.Data;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalEMR.DataAccess.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly ApplicationDbContext _db;

        public DoctorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Doctor doctor)
        {
            var objFromDb = _db.Doctors.FirstOrDefault(s => s.Id == doctor.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = doctor.Name;
                objFromDb.EmailAddress = doctor.EmailAddress;
                objFromDb.City = doctor.City;
                objFromDb.PhoneNumber = doctor.PhoneNumber;
                objFromDb.StreetAddress = doctor.StreetAddress;
                objFromDb.PostalCode = doctor.PostalCode;
                objFromDb.State = doctor.State;
            }
        }
    }
}
