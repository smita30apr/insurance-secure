using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceSecure.Models.Insurance
{
    public class Health : Insurance
    {
        [Required]
        [Display(Name = "Number of Adults")]
        public int Adults { get; set; }

        [Required]
        [Display(Name = "Number of children")]
        public int Children { get; set; }

        [Required]
        [Display(Name = "DOB of eldest person")]
        public DateTime EldestDOB { get; set; }

        [Required]
        [Display(Name = "Insurance Coverage")]
        public InsuranceCoverage Coverage { get; set; }
    }
}