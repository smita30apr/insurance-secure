﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsuranceSecure.Models.Insurance
{
    public class Life : Insurance
    {
        [Required]
        [Display(Name = "Smoke?")]
        public Boolean SmokingStatus { get; set; }

        [Required]
        [Display(Name = "Insurance Coverage")]
        public InsuranceCoverage Coverage { get; set; }
    }
}
