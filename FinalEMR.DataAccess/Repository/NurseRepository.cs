using FinalEMR.DataAccess.Data;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalEMR.DataAccess.Repository
{
    public class NurseRepository : Repository<Nurse>, INurseRepository
    {
        private readonly ApplicationDbContext _db;

        public NurseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Nurse nurse)
        {
            _db.Update(nurse);
        }
    }
}
