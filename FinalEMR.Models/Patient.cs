using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalEMR.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        [Required]
        public string LastName { get; set; }
        public string Comments { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        [Range(10, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Weight { get; set; }


        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Street Address ")]
        public string Street { get; set; }


        [Display(Name = "Social Security")]
        public int SocialSecurity { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public int AllergyId { get; set; }

        [ForeignKey("AllergyId")]
        public Allergy Allergy { get; set; }

        [Required]
        public int PrescriptionId { get; set; }

        [ForeignKey("PrescriptionId")]
        public Prescription Prescription { get; set; }
    }
}


