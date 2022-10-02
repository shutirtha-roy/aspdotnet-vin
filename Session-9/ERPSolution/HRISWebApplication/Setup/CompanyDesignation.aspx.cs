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
    public partial class CompanyDesignation : System.Web.UI.Page
    {
        public static string CompanyId { get; set; } = "-1";
        public static string OfficeLocationId { get; set; } = "-1";
        public static string CompanyDepartmentId { get; set; } = "-1";
        public static string CompanySectionId { get; set; } = "-1";
        private readonly CompanyDesignationDataAccess _companyDesignationDataAccess;
        private readonly CompanySectionDataAccess _companySectionDataAccess;
        private readonly CompanyDepartmentDataAccess _companyDepartmentDataAccess;
        private readonly CompanyDivisionDataAccess _companyDivisonDataAccess;
        private readonly CompanyDataAccess _companyDataAccess;

        public CompanyDesignation()
        {
            _companyDesignationDataAccess = new CompanyDesignationDataAccess();
            _companySectionDataAccess = new CompanySectionDataAccess();
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
                LoadCompanyDepartmentId();
                LoadCompanySectionId();
                ShowCompanyDesignationInformation();
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
                OfficeLocationId = "";
            }
        }

        private void LoadCompanyDepartmentId()
        {
            DataTable dt = _companyDepartmentDataAccess.GetAllCompanyDepartmentInformation();
            ddlCompanyDepartmentCode.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                ddlCompanyDepartmentCode.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["OfficeLocationId"].ToString() == OfficeLocationId)
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr["DepartmentName"].ToString();
                        lst.Value = dr["DepartmentCode"].ToString();
                        ddlCompanyDepartmentCode.Items.Add(lst);
                    }
                }
            }
            else
            {
                ddlCompanyDepartmentCode.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                CompanyDepartmentId = "";
            }
        }

        private void LoadCompanySectionId()
        {
            DataTable dt = _companySectionDataAccess.GetAllCompanySectionInformation();
            ddlCompanySectionCode.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                ddlCompanySectionCode.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["DepartmentCode"].ToString() == CompanyDepartmentId)
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr["SectionName"].ToString();
                        lst.Value = dr["SectionCode"].ToString();
                        ddlCompanySectionCode.Items.Add(lst);
                    }
                }
            }
            else
            {
                ddlCompanySectionCode.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                CompanySectionId = "";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Save"))
            {
                txtDesignationCode.Enabled = true;
                SaveCompanyDesignationInformation();
            }
            else if (btnSave.Text.Equals("Update"))
            {
                UpdateCompanyDesignationInformation();
                txtDesignationCode.Enabled = true;
                btnSave.Text = "Save";
            }

            ShowCompanyDesignationInformation();
            ClearAllFormControl();
        }

        private void ShowCompanyDesignationInformation()
        {
            DataTable dt = _companyDesignationDataAccess.GetAllCompanyDesignationInformation();
            GridCompanyDesignation.DataSource = dt;
            GridCompanyDesignation.DataBind();
        }

        private void SaveCompanyDesignationInformation()
        {
            IDictionary<string, string> companyDesignation = new Dictionary<string, string>()
            {
                { "companyId", CompanyId.ToString() },
                { "locationId",  OfficeLocationId.ToString() },
                { "departmentCode",  CompanyDepartmentId.ToString() },
                { "sectionCode", CompanySectionId.ToString() },
                { "designationCode", txtDesignationCode.Text },
                { "designationName", txtDesignationName.Text }
            };

            _companyDesignationDataAccess.Save(companyDesignation);
        }

        private void UpdateCompanyDesignationInformation()
        {
            IDictionary<string, string> companyDesignation = new Dictionary<string, string>()
            {
                { "companyId", CompanyId.ToString() },
                { "locationId",  OfficeLocationId.ToString() },
                { "departmentCode",  CompanyDepartmentId.ToString() },
                { "sectionCode", CompanySectionId.ToString() },
                { "designationCode", txtDesignationCode.Text },
                { "designationName", txtDesignationName.Text }
            };

            _companyDesignationDataAccess.Update(companyDesignation);
        }

        protected void ddlCompanyDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyId = ddlCompanyDivision.SelectedValue;
            LoadOfficeLocationId();
        }

        protected void ddlCompanyOfficeLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            OfficeLocationId = ddlCompanyOfficeLocation.SelectedValue;
            LoadCompanyDepartmentId();
        }

        protected void ddlCompanyDepartmentCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyDepartmentId = ddlCompanyDepartmentCode.SelectedValue;
            LoadCompanySectionId();
        }

        protected void ddlCompanySectionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanySectionId = ddlCompanySectionCode.SelectedValue;
        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            txtDesignationCode.Enabled = true;
            ClearAllFormControl();
            btnSave.Text = "Save";
        }

        private void ClearAllFormControl()
        {
            LoadCompanyId();
            LoadOfficeLocationId();
            LoadCompanyDepartmentId();
            LoadCompanySectionId();
            txtDesignationCode.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
        }

        protected void GridCompanyDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName.Equals("Delete"))
            {
                string cid = GridCompanyDesignation.Rows[index].Cells[6].Text;
                _companyDesignationDataAccess.DeleteRow<string>(cid);
                ShowCompanyDesignationInformation();
            }
            else if (e.CommandName.Equals("Select"))
            {
                ddlCompanyDivision.SelectedValue = GridCompanyDesignation.Rows[index].Cells[2].Text.Equals("&nbsp;") ? "" : GridCompanyDesignation.Rows[index].Cells[2].Text;
                CompanyId = ddlCompanyDivision.SelectedValue;

                LoadOfficeLocationId();
                ddlCompanyOfficeLocation.SelectedValue = GridCompanyDesignation.Rows[index].Cells[3].Text.Equals("&nbsp;") ? "" : GridCompanyDesignation.Rows[index].Cells[3].Text;
                OfficeLocationId = ddlCompanyOfficeLocation.SelectedValue;

                LoadCompanyDepartmentId();
                ddlCompanyDepartmentCode.SelectedValue = GridCompanyDesignation.Rows[index].Cells[4].Text.Equals("&nbsp;") ? "" : GridCompanyDesignation.Rows[index].Cells[4].Text;
                CompanyDepartmentId = ddlCompanyDepartmentCode.SelectedValue;

                LoadCompanySectionId();
                ddlCompanySectionCode.SelectedValue = GridCompanyDesignation.Rows[index].Cells[5].Text.Equals("&nbsp;") ? "" : GridCompanyDesignation.Rows[index].Cells[5].Text;
                CompanySectionId = ddlCompanySectionCode.SelectedValue;

                txtDesignationCode.Text = GridCompanyDesignation.Rows[index].Cells[6].Text.Equals("&nbsp;") ? "" : GridCompanyDesignation.Rows[index].Cells[6].Text;
                txtDesignationName.Text = GridCompanyDesignation.Rows[index].Cells[7].Text.Equals("&nbsp;") ? "" : GridCompanyDesignation.Rows[index].Cells[7].Text;
                txtDesignationCode.Enabled = false;
                btnSave.Text = "Update";
            }
        }

        protected void GridCompanyDesignation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridCompanyDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}