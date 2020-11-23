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
            _db.Update(_db);
        }
    }
}
