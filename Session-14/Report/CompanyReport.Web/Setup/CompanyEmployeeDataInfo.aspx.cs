using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyReport.Web.Setup
{
    public partial class CompanyEmployeeDataInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument Report = new ReportDocument();
            Report.Load(Server.MapPath("~/EmployeeReport.rpt"));
            Report.SetDatabaseLogon("aspnetb7", "123456", "DESKTOP-OLO1A1A\\SQLEXPRESS", "DB_HRIS");
            CrystalReportViewer1.ReportSource = Report;
            //CrystalReportViewer1.RefreshReport();
            Report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Employee Information");
            //Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\Report\EmployeeReport.pdf");
            //Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, @"D:\Report\EmployeeReport.doc");
        }
    }
}