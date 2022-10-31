using CrystalDecisions.CrystalReports.Engine;
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
            CrystalReportViewer1.ReportSource = Report;
            CrystalReportViewer1.RefreshReport();
            Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\Report\EmployeeReport.pdf");
            Report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, @"D:\Report\EmployeeReport.doc");
        }
    }
}