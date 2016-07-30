using InsuranceSecure.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceSecure.ModelMappers
{
    public static class InsuranceMapper
    {
        internal static Insurance FromType(string type)
        {
            Insurance insurance = null;
            switch (type)
            {
                case "life":
                    insurance = new Life();
                    break;
                default:
                    insurance = new Insurance();
                    break;
            }

            return insurance;
        }
    }
}