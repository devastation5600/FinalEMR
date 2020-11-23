using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEMR.DataAccess.Repository.IRepository
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        void Update(Prescription prescription);
    }
}
