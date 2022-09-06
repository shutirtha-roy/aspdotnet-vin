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
        private readonly CompanyDivisionDataAccess _companyDivisonDataAccess;
        private readonly CompanyDataAccess _companyDataAccess;
        public CompanyDivisionForm()
        {
            _companyDivisonDataAccess = new CompanyDivisionDataAccess();
            _companyDataAccess = new CompanyDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadCompanyId();
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
            DataTable dt = _companyDivisonDataAccess.GetAllCompanyDivisionInformation();
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

        private void LoadCompanyId()
        {
            DataTable dt = _companyDataAccess.GetAllCompanyInformation();
            ddlCompanyDivision.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                ddlCompanyDivision.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["CompanyName"].ToString();
                    lst.Value = dr["CompanyId"].ToString();
                    ddlCompanyDivision.Items.Add(lst);
                }
            }
        }

        protected void ddlCompanyDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string otherCompanyId = ddlCompanyDivision.SelectedValue;
        }
    }
}