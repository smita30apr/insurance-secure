using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsuranceSecure.Models.Insurance
{
    public class InsuranceData
    {
        public string Type { get; set; }

        public string Heading { get; set; }

        public string Description { get; set; }

        public InsuranceData(string type, string heading, string desc)
        {
            Type = type;
            Heading = heading;
            Description = desc;
        }    

    }
}
