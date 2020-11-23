using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalEMR.Models
{
    public class Allergy
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Allergy Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }
    }
}
