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
    public partial class CompanyDepartment : System.Web.UI.Page
    {
        public static string CompanyId { get; set; }
        public static string OfficeLocationId { get; set; }
        private readonly CompanyDepartmentDataAccess _companyDepartmentDataAccess;
        private readonly CompanyDivisionDataAccess _companyDivisonDataAccess;
        private readonly CompanyDataAccess _companyDataAccess;

        public CompanyDepartment()
        {
            _companyDepartmentDataAccess = new CompanyDepartmentDataAccess();
            _companyDivisonDataAccess = new CompanyDivisionDataAccess();
            _companyDataAccess = new CompanyDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCompanyId();
                LoadOfficeLocationId();
                ShowCompanyDepartmentInformation();
            }
        }

        private void LoadOfficeLocationId()
        {
            DataTable dt = _companyDivisonDataAccess.GetAllCompanyDivisionInformation();
            ddlCompanyOfficeLocation.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                ddlCompanyOfficeLocation.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CompanyId"].ToString() == CompanyId)
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr["OfficeLocationName"].ToString();
                        lst.Value = dr["OfficeLocationCode"].ToString();
                        ddlCompanyOfficeLocation.Items.Add(lst);
                    }
                }
            }
            else
            {
                ddlCompanyOfficeLocation.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                CompanyId = "";
            }
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
            LoadOfficeLocationId();
        }

        protected void ddlCompanyOfficeLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            OfficeLocationId = ddlCompanyOfficeLocation.SelectedValue;
        }

        private void ShowCompanyDepartmentInformation()
        {
            DataTable dt = _companyDepartmentDataAccess.GetAllCompanyDepartmentInformation();
            GridCompanyDepartment.DataSource = dt;
            GridCompanyDepartment.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Save"))
            {
                txtDepartmentCode.Enabled = true;
                SaveCompanyDepartmentInformation();
            }
            else if (btnSave.Text.Equals("Update"))
            {
                UpdateCompanyDivisionInformation();
                txtDepartmentCode.Enabled = true;
                btnSave.Text = "Save";
            }

            ShowCompanyDepartmentInformation();
            ClearAllFormControl();
        }

        private void SaveCompanyDepartmentInformation()
        {
            IDictionary<string, string> companyDepartment = new Dictionary<string, string>()
            {
                { "companyId", ddlCompanyDivision.SelectedValue },
                { "locationId",  ddlCompanyOfficeLocation.SelectedValue },
                { "departmentCode", txtDepartmentCode.Text },
                { "departmentName", txtDepartmentName.Text },
                { "departmentLocation", txtDepartmentLocation.Text },
                { "headOfDepartment", txtHeadOfDepartment.Text },
                { "substituteHeadOfDepartment", txtSubstituteHeadOfDepartment.Text },
            };

            _companyDepartmentDataAccess.Save(companyDepartment);
        }

        private void UpdateCompanyDivisionInformation()
        {
            IDictionary<string, string> companyDepartment = new Dictionary<string, string>()
            {
                { "companyId", ddlCompanyDivision.SelectedValue },
                { "locationId",  ddlCompanyOfficeLocation.SelectedValue },
                { "departmentCode", txtDepartmentCode.Text },
                { "departmentName", txtDepartmentName.Text },
                { "departmentLocation", txtDepartmentLocation.Text },
                { "headOfDepartment", txtHeadOfDepartment.Text },
                { "substituteHeadOfDepartment", txtSubstituteHeadOfDepartment.Text },
            };

            _companyDepartmentDataAccess.Update(companyDepartment);
        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            txtDepartmentCode.Enabled = true;
            ClearAllFormControl();
            btnSave.Text = "Save";
        }

        private void ClearAllFormControl()
        {
            LoadCompanyId();
            LoadOfficeLocationId();
            txtDepartmentCode.Text = string.Empty;
            txtDepartmentName.Text = string.Empty;
            txtDepartmentLocation.Text = string.Empty;
            txtHeadOfDepartment.Text = string.Empty;
            txtSubstituteHeadOfDepartment.Text = string.Empty;
        }

        protected void GridCompanyDivision_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName.Equals("Delete"))
            {
                string did = GridCompanyDepartment.Rows[index].Cells[4].Text;
                _companyDepartmentDataAccess.DeleteRow<string>(did);
                ShowCompanyDepartmentInformation();
            }
            else if (e.CommandName.Equals("Select"))
            {
                ddlCompanyDivision.SelectedValue = GridCompanyDepartment.Rows[index].Cells[2].Text.Equals("&nbsp;") ? "" : GridCompanyDepartment.Rows[index].Cells[2].Text;
                CompanyId = ddlCompanyDivision.SelectedValue;

                LoadOfficeLocationId();
                ddlCompanyOfficeLocation.SelectedValue = GridCompanyDepartment.Rows[index].Cells[3].Text.Equals("&nbsp;") ? "" : GridCompanyDepartment.Rows[index].Cells[3].Text;
                OfficeLocationId = ddlCompanyOfficeLocation.SelectedValue;

                txtDepartmentCode.Text = GridCompanyDepartment.Rows[index].Cells[4].Text.Equals("&nbsp;") ? "" : GridCompanyDepartment.Rows[index].Cells[4].Text;
                txtDepartmentName.Text = GridCompanyDepartment.Rows[index].Cells[5].Text.Equals("&nbsp;") ? "" : GridCompanyDepartment.Rows[index].Cells[5].Text;
                txtDepartmentLocation.Text = GridCompanyDepartment.Rows[index].Cells[6].Text.Equals("&nbsp;") ? "" : GridCompanyDepartment.Rows[index].Cells[6].Text;
                txtHeadOfDepartment.Text = GridCompanyDepartment.Rows[index].Cells[7].Text.Equals("&nbsp;") ? "" : GridCompanyDepartment.Rows[index].Cells[7].Text;
                txtSubstituteHeadOfDepartment.Text = GridCompanyDepartment.Rows[index].Cells[8].Text.Equals("&nbsp;") ? "" : GridCompanyDepartment.Rows[index].Cells[8].Text;
                txtDepartmentCode.Enabled = false;
                btnSave.Text = "Update";
            }
        }

        protected void GridCompanyDivision_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}