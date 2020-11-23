using FinalEMR.DataAccess.Data;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalEMR.DataAccess.Repository
{
    public class AllergyRepository : Repository<Allergy>, IAllergyRepository
    {
        private readonly ApplicationDbContext _db;

        public AllergyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Allergy allergy)
        {
            var objFromDb = _db.Allergies.FirstOrDefault(s => s.Id == allergy.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = allergy.Name;
            }
        }
    }
}