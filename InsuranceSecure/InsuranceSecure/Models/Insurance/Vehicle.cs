using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceSecure.Models.Insurance
{
    public enum VehiclePolicyType
    {
        New,
        Renewal
    }

    public class Vehicle : Insurance
    {
        [Required]
        [Display(Name = "Make")]
        public String Make { get; set; }

        [Required]
        [Display(Name = "Registraion No.")]
        public String RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Registraion Year")]
        public String RegistrationYear { get; set; }

        [Required]
        [Display(Name = "Policy Type")]
        public VehiclePolicyType PolicyType { get; set; }
    }
}