using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEMR.Utility
{
    public static class SD
    {
        public const string Proc_Allergy_Create = "usp_CreateAllergy";
        public const string Proc_Allergy_Get = "usp_GetAllergy";
        public const string Proc_Allergy_GetAll = "usp_GetAllergies";
        public const string Proc_Allergy_Update = "usp_UpdateAllergy";
        public const string Proc_Allergy_Delete = "usp_DeleteAllergy";

        public const string Role_Nurse = "Nurse";
        public const string Role_Admin = "Admin";
        public const string Role_Doctor = "Doctor";
        public const string Role_Privi_Nurse = "Privileged Nurse";
    }
}
