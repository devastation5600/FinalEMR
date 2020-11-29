using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEMR.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPrescriptionRepository Prescription { get; }
        IAllergyRepository Allergy { get; }
        IPatientRepository Patient { get; }
        INurseRepository Nurse { get; }
        IDoctorRepository Doctor { get; }
        IRecordRepository Record { get; }
        IRecordHeaderRepository RecordHeader { get; }
        IPatientDetailsRepository PatientDetails { get; }
        IApplicationUserRepository ApplicationUser { get; }


        ISP_Call SP_Call { get; }
        void Save();

    }
}
