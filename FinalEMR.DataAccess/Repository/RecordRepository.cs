using FinalEMR.DataAccess.Data;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalEMR.DataAccess.Repository
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        private readonly ApplicationDbContext _db;

        public RecordRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Record obj)
        {
            _db.Update(obj);
        }
    }
}