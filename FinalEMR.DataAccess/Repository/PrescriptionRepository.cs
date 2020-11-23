using FinalEMR.DataAccess.Data;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalEMR.DataAccess.Repository
{
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        private readonly ApplicationDbContext _db;

        public PrescriptionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Prescription prescription)
        {
            var objFromDb = _db.Prescriptions.FirstOrDefault(s => s.Id == prescription.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = prescription.Name;
            }
        }
    }
}
