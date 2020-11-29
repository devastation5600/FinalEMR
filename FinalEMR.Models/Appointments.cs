using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalEMR.Models
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime AppointmentDate { get; set; }

        [NotMapped]
        public DateTime AppointmentTime { get; set; }


        public string PatientName { get; set; }

        public string PatientPhoneNumber { get; set; }
        public int PatientEmail { get; set; }
    }
}
