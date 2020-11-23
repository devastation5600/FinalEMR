using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalEMR.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Prescription Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }
    }
}
