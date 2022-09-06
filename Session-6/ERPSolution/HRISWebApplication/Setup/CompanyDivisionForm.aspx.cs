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
        public static string CompanyId { get; set; }
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
            {
                LoadCompanyId();
                ShowCompanyDivisionInformation();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Save"))
            {
                txtLocationCode.Enabled = true;
                SaveCompanyDivisionInformation();
            }

            ShowCompanyDivisionInformation();
        }

        private void SaveCompanyDivisionInformation()
        {
            IDictionary<string, string> companyDetails = new Dictionary<string, string>()
            {
                { "companyId", CompanyId.ToString() },
                { "officeLocationCode", txtLocationCode.Text },
                { "officeLocationName", txtLocationName.Text },
                { "location", txtLocation.Text },
                { "address1", txtAddress1.Text },
                { "address2", txtAddress2.Text },
                { "address3", txtAddress3.Text }
            };

            _companyDivisonDataAccess.Save(companyDetails);
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
            LoadCompanyId();
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
            else
            {
                ddlCompanyDivision.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                CompanyId = "";
            }
        }

        protected void ddlCompanyDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyId = ddlCompanyDivision.SelectedValue;
        }
    }
}