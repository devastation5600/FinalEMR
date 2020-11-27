using FinalEMR.DataAccess.Data;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalEMR.DataAccess.Repository
{
    public class RecordHeaderRepository : Repository<RecordHeader>, IRecordHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public RecordHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(RecordHeader obj)
        {
            _db.Update(obj);
        }
    }
}