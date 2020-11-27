using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalEMR.Models
{
    public class PatientDetails
    {
        public int Id { get; set; }

        public int RecordId { get; set; }
        [ForeignKey("RecordId")]
        public RecordHeader RecordHeader { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }


    }
}
