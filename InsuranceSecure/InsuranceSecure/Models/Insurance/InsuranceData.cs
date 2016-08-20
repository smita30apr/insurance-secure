using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsuranceSecure.Models.Insurance
{
    public class InsuranceData
    {
        public string Type { get; set; }

        public string Image { get; set; }

        public string TotalPayout { get; set; }

        public string CoverTill { get; set; }

        public string Heading { get; set; }

        public string Description { get; set; }

        public string Premium { get; set; }

        public string Brochure { get; set; }

        public string ImageUrl { get; set; }

    }
}
