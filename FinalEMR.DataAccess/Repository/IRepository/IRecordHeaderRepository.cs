using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEMR.DataAccess.Repository.IRepository
{
    public interface IRecordHeaderRepository : IRepository<RecordHeader>
    {
        void Update(RecordHeader obj);
    }
}
