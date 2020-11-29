using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEMR.DataAccess.Repository.IRepository
{
    public interface IRecordRepository : IRepository<Record>
    {
        public void Update(Record obj);
    }
}
