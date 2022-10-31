using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyReport.Web.Setup
{
    public partial class CompanyDataInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument Report = new ReportDocument();
            Report.Load(Server.MapPath("~/CompanyReport.rpt"));
            Report.SetDatabaseLogon("aspnetb7", "123456", "DESKTOP-OLO1A1A\\SQLEXPRESS", "DB_HRIS");
            CrystalReportViewer1.ReportSource = Report;
            CrystalReportViewer1.RefreshReport();
            Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\Report\CompanyReport.pdf");
            Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, @"D:\Report\CompanyReport.doc");
        }
    }
}