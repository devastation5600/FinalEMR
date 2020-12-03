﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalEMR.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Doctor Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "Street Address ")]
        public string StreetAddress { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Postal Code ")]
        public string PostalCode { get; set; }
    }
}
