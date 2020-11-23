using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEMR.DataAccess.Repository.IRepository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        void Update(Doctor doctor);
    }
}
