using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsuranceSecure.Models.Insurance
{
    public class Life : Insurance
    {
        [Required]
        [Display(Name = "Smoking status")]
        public Boolean SmokingStatus { get; set; }
    }
}
