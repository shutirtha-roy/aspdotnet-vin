using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRISWebApplication.Codes
{
    public static class StaticData
    {
        public static string SessionId { get; set; } = "@SESSION_ID_ROY";
        public static string UserId { get; set; } = "uid";
        public static string CompanyId { get; set; } = "cid";
        public static string OfficeLocationId { get; set; } = "oid";
        public static string CompanyDepartmentId { get; set; } = "cdid";
        public static string CompanySectionId { get; set; } = "csid";
        public static string CompanyDesignationId { get; set; } = "cdsid";
    }
}