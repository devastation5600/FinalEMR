using FinalEMR.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEMR.DataAccess.Repository.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient patient);
    }
}
