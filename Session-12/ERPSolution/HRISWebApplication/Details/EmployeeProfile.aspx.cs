using HRISWebApplication.Codes;
using HRISWebApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRISWebApplication.Details
{
    public partial class EmployeeProfile : System.Web.UI.Page
    {
        public static string CompanyId { get; set; } = "-1";
        public static string OfficeLocationId { get; set; } = "-1";
        public static string CompanyDepartmentId { get; set; } = "-1";
        public static string CompanySectionId { get; set; } = "-1";
        public static string CompanyDesignationId { get; set; } = "-1";
        public static string EmployeeName { get; set; } = "";
        public static string EmployeeSchool { get; set; } = "";
        public static string EmployeeUniversity { get; set; } = "";
        public static string EmployeeFatherName { get; set; } = "";
        public static string EmployeeMotherName { get; set; } = "";
        public static string EmployeeAddress { get; set; } = "";
        private readonly CompanyEmployeeProfileDataAccess _companyEmployeeProfileDataAccess;
        private readonly CompanyDesignationDataAccess _companyDesignationDataAccess;
        private readonly CompanySectionDataAccess _companySectionDataAccess;
        private readonly CompanyDepartmentDataAccess _companyDepartmentDataAccess;
        private readonly CompanyDivisionDataAccess _companyDivisonDataAccess;
        private readonly CompanyDataAccess _companyDataAccess;

        public EmployeeProfile()
        {
            _companyEmployeeProfileDataAccess = new CompanyEmployeeProfileDataAccess();
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
                LoadCompanyDesignationId();
                ShowCompanyEmployeeProfile();
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

        private void LoadCompanyDesignationId()
        {
            DataTable dt = _companyDesignationDataAccess.GetAllCompanyDesignationInformation();
            ddlCompanyDesignationCode.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                ddlCompanyDesignationCode.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["SectionCode"].ToString() == CompanySectionId)
                    {
                        ListItem lst = new ListItem();
                        lst.Text = dr["DesignationName"].ToString();
                        lst.Value = dr["DesignationCode"].ToString();
                        ddlCompanyDesignationCode.Items.Add(lst);
                    }
                }
            }
            else
            {
                ddlCompanyDesignationCode.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                CompanySectionId = "";
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
            LoadCompanyDesignationId();
        }

        protected void ddlCompanyDesignationCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyDesignationId = ddlCompanyDesignationCode.SelectedValue;
        }

        protected void btnSaveBasicInfo_Click(object sender, EventArgs e)
        {
            EmployeeName = txtEmployeeName.Text;

            HttpContext.Current.Response.Write($"<script>alert('Employee Name Saved')</script>");
        }

        protected void btnSaveEducationInfo_Click(object sender, EventArgs e)
        {
            EmployeeSchool = txtEmployeeSchool.Text;
            EmployeeUniversity = txtEmployeeUniversity.Text;
        }

        protected void btnSavePersonalInfo_Click(object sender, EventArgs e)
        {
            EmployeeFatherName = txtEmployeeFatherName.Text;
            EmployeeMotherName = txtEmployeeMotherName.Text;
            EmployeeAddress = txtEmployeeAddress.Text;
        }

        protected void btnSavePermanently_Click(object sender, EventArgs e)
        {
            Session[StaticData.UserId] = Guid.NewGuid().ToString();

            IDictionary<string, string> companyEmployeeProfile = new Dictionary<string, string>()
            {
                { "companyId", CompanyId.ToString() },
                { "locationId",  OfficeLocationId.ToString() },
                { "departmentCode",  CompanyDepartmentId.ToString() },
                { "sectionCode", CompanySectionId.ToString() },
                { "designationCode", CompanyDepartmentId.ToString() },
                { "employeeProfileId", Session[StaticData.UserId].ToString() },
                { "employeeName", EmployeeName },
                { "employeeSchool", EmployeeSchool },
                { "employeeUniversity", EmployeeUniversity },
                { "employeeFatherName", EmployeeFatherName },
                { "employeeMotherName", EmployeeMotherName },
                { "employeeAddress", EmployeeAddress }
            };

            _companyEmployeeProfileDataAccess.Save(companyEmployeeProfile);
            Session[StaticData.UserId] = "";
            ShowCompanyEmployeeProfile();
        }

        private void ShowCompanyEmployeeProfile()
        {
            DataTable dt = _companyEmployeeProfileDataAccess.GetAllCompanyEmployeeProfile();
            GridCompanyEmployeeProfile.DataSource = dt;
            GridCompanyEmployeeProfile.DataBind();
        }
        protected void GridCompanyEmployeeProfile_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridCompanyEmployeeProfile_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridCompanyEmployeeProfile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearAllFormControl()
        {

        }
    }
}