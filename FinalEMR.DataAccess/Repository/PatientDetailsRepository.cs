using FinalEMR.DataAccess.Data;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalEMR.DataAccess.Repository
{
    public class PatientDetailsRepository : Repository<PatientDetails>, IPatientDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(PatientDetails obj)
        {
            _db.Update(obj);
        }
    }
}