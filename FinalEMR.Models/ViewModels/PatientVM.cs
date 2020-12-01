using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEMR.Models.ViewModels
{
    public class PatientVM
    {
        public Patient Patient { get; set; }
        public IEnumerable<SelectListItem> PrescriptionList { get; set; }
        public IEnumerable<SelectListItem> DoctorList { get; set; }
        public IEnumerable<SelectListItem> NurseList { get; set; }
        public IEnumerable<SelectListItem> AllergyList { get; set; }
        
    }
}
   