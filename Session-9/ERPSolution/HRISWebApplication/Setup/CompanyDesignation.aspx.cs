using HRISWebApplication.DataAccess;
using System;
using System.Collections.Generic;
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
        public static string CompanyDesignationId { get; set; } = "-1";
        private readonly CompanyDesignationDataAccess _companyDesignationDataAccess;
        private readonly CompanySectionDataAccess _companySectionDataAccess;
        private readonly CompanyDepartmentDataAccess _companyDepartmentDataAccess;
        private readonly CompanyDivisionDataAccess _companyDivisonDataAccess;
        private readonly CompanyDataAccess _companyDataAccess;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlCompanyDivision_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCompanyOfficeLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCompanyDepartmentCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCompanySectionCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {

        }

        protected void GridCompanyDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridCompanyDesignation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridCompanyDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}