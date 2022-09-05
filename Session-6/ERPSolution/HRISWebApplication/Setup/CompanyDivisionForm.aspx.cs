using HRISWebApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRISWebApplication.Setup
{
    public partial class CompanyDivisionForm : System.Web.UI.Page
    {
        private readonly CompanyDivisionDataAccess _companyDataAccess;
        public CompanyDivisionForm()
        {
            _companyDataAccess = new CompanyDivisionDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCompanyDivisionInformation();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            txtLocationCode.Enabled = true;
            ClearAllFormControl();
        }

        protected void GridCompanyDivision_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        private void ShowCompanyDivisionInformation()
        {
            DataTable dt = _companyDataAccess.GetAllCompanyDivisionInformation();
            GridCompanyDivision.DataSource = dt;
            GridCompanyDivision.DataBind();
        }

        private void ClearAllFormControl()
        {
            txtLocationCode.Text = string.Empty;
            txtLocationName.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
        }
    }
}