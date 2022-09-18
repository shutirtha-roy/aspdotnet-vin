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
    public partial class CompanySection : System.Web.UI.Page
    {
        public static string CompanyId { get; set; } = "-1";
        public static string OfficeLocationId { get; set; } = "-1";
        public static string CompanyDepartmentId { get; set; } = "-1";
        private readonly CompanySectionDataAccess _companySectionDataAccess;
        private readonly CompanyDepartmentDataAccess _companyDepartmentDataAccess;
        private readonly CompanyDivisionDataAccess _companyDivisonDataAccess;
        private readonly CompanyDataAccess _companyDataAccess;

        public CompanySection()
        {
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
                ShowCompanySectionInformation();
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
                    if(dr["CompanyId"].ToString() == CompanyId)
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
                    if (dr["CompanyId"].ToString() == CompanyId)
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

        

        

        private void ShowCompanySectionInformation()
        {
            DataTable dt = _companySectionDataAccess.GetAllCompanySectionInformation();
            GridCompanySection.DataSource = dt;
            GridCompanySection.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Save"))
            {
                txtSectionCode.Enabled = true;
                SaveCompanySectionInformation();
            }
            else if (btnSave.Text.Equals("Update"))
            {
                UpdateCompanySectionInformation();
                txtSectionCode.Enabled = true;
                btnSave.Text = "Save";
            }

            ShowCompanySectionInformation();
            ClearAllFormControl();
        }

        private void SaveCompanySectionInformation()
        {
            IDictionary<string, string> companySection = new Dictionary<string, string>()
            {
                { "companyId", CompanyId.ToString() },
                { "locationId",  OfficeLocationId.ToString() },
                { "departmentCode",  CompanyDepartmentId.ToString() },
                { "sectionCode", txtSectionCode.Text },
                { "sectionName", txtSectionName.Text },
                { "headOfSection", txtHeadOfSection.Text },
                { "substituteHeadOfSection", txtSubstituteHeadOfSection.Text },
            };

            _companySectionDataAccess.Save(companySection);
        }

        private void UpdateCompanySectionInformation()
        {
            IDictionary<string, string> companySection = new Dictionary<string, string>()
            {
                { "companyId", CompanyId.ToString() },
                { "locationId",  OfficeLocationId.ToString() },
                { "departmentCode",  CompanyDepartmentId.ToString() },
                { "sectionCode", txtSectionCode.Text },
                { "sectionName", txtSectionName.Text },
                { "headOfSection", txtHeadOfSection.Text },
                { "substituteHeadOfSection", txtSubstituteHeadOfSection.Text },
            };

            _companySectionDataAccess.Update(companySection);
        }

        

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            txtSectionCode.Enabled = true;
            ClearAllFormControl();
            btnSave.Text = "Save";
        }

        private void ClearAllFormControl()
        {
            LoadCompanyId();
            LoadOfficeLocationId();
            LoadCompanyDepartmentId();
            txtSectionCode.Text = string.Empty;
            txtSectionName.Text = string.Empty;
            txtHeadOfSection.Text = string.Empty;
            txtSubstituteHeadOfSection.Text = string.Empty;
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

        }

        protected void GridCompanyDivision_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName.Equals("Delete"))
            {
                string did = GridCompanySection.Rows[index].Cells[5].Text;
                _companySectionDataAccess.DeleteRow<string>(did);
                ShowCompanySectionInformation();
            }
            else if (e.CommandName.Equals("Select"))
            {
                ddlCompanyDivision.SelectedValue = GridCompanySection.Rows[index].Cells[2].Text.Equals("&nbsp;") ? "" : GridCompanySection.Rows[index].Cells[2].Text;
                CompanyId = ddlCompanyDivision.SelectedValue;

                LoadOfficeLocationId();
                ddlCompanyOfficeLocation.SelectedValue = GridCompanySection.Rows[index].Cells[3].Text.Equals("&nbsp;") ? "" : GridCompanySection.Rows[index].Cells[3].Text;
                OfficeLocationId = ddlCompanyOfficeLocation.SelectedValue;

                LoadCompanyDepartmentId();
                ddlCompanyDepartmentCode.SelectedValue = GridCompanySection.Rows[index].Cells[4].Text.Equals("&nbsp;") ? "" : GridCompanySection.Rows[index].Cells[4].Text;
                CompanyDepartmentId = ddlCompanyDepartmentCode.SelectedValue;

                txtSectionCode.Text = GridCompanySection.Rows[index].Cells[5].Text.Equals("&nbsp;") ? "" : GridCompanySection.Rows[index].Cells[5].Text;
                txtSectionName.Text = GridCompanySection.Rows[index].Cells[6].Text.Equals("&nbsp;") ? "" : GridCompanySection.Rows[index].Cells[6].Text;
                txtHeadOfSection.Text = GridCompanySection.Rows[index].Cells[7].Text.Equals("&nbsp;") ? "" : GridCompanySection.Rows[index].Cells[7].Text;
                txtSubstituteHeadOfSection.Text = GridCompanySection.Rows[index].Cells[8].Text.Equals("&nbsp;") ? "" : GridCompanySection.Rows[index].Cells[8].Text;
                txtSectionCode.Enabled = false;
                btnSave.Text = "Update";
            }
        }

        protected void GridCompanyDivision_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }
    }
}