using InsuranceSecure.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceSecure.Helpers
{
    public static class UrlHelpers
    {
        public static String GetCoverageString(this UrlHelper helper, InsuranceCoverage option)
        {
            switch (option)
            {
                case InsuranceCoverage.Lac3To4:
                    return "3 Lac - 4 Lac";
                case InsuranceCoverage.Lac4To5:
                    return "4 Lac - 5 Lac";
                case InsuranceCoverage.Lac5To10:
                    return "5 Lac - 10 Lac";
                case InsuranceCoverage.LacMoreThan10:
                    return "More than 10 Lac";
                default:
                    return "";
            }
        }
    }
}