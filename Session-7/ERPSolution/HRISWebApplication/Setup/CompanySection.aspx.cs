﻿using HRISWebApplication.DataAccess;
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
        public static string CompanyId { get; set; }
        public static string OfficeLocationId { get; set; }
        public static string CompanySectionId { get; set; }
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
                LoadCompanySectionId();
                //ShowCompanySectionInformation();
            }
        }

        private void LoadCompanySectionId()
        {
            DataTable dt = _companyDepartmentDataAccess.GetAllCompanyDepartmentInformation();
            ddlCompanyDepartmentCode.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                ddlCompanyOfficeLocation.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["DepartmentName"].ToString();
                    lst.Value = dr["DepartmentCode"].ToString();
                    ddlCompanyDepartmentCode.Items.Add(lst);
                }
            }
            else
            {
                ddlCompanyDepartmentCode.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                CompanySectionId = "";
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
                    ListItem lst = new ListItem();
                    lst.Text = dr["OfficeLocationName"].ToString();
                    lst.Value = dr["OfficeLocationCode"].ToString();
                    ddlCompanyOfficeLocation.Items.Add(lst);
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
        }

        private void SaveCompanySectionInformation()
        {
            IDictionary<string, string> companySection = new Dictionary<string, string>()
            {
                { "companyId", CompanyId.ToString() },
                { "locationId",  OfficeLocationId.ToString() },
                { "departmentCode",  CompanySectionId.ToString() },
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
                { "departmentCode",  CompanySectionId.ToString() },
                { "sectionCode", txtSectionCode.Text },
                { "sectionName", txtSectionName.Text },
                { "headOfSection", txtHeadOfSection.Text },
                { "substituteHeadOfSection", txtSubstituteHeadOfSection.Text },
            };

            _companySectionDataAccess.Update(companySection);
        }

        

        protected void btnClearForm_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCompanyDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyId = ddlCompanyDivision.SelectedValue;
        }

        protected void ddlOfficeLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            OfficeLocationId = ddlCompanyOfficeLocation.SelectedValue;
        }

        protected void ddlCompanyDepartmentCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanySectionId = ddlCompanyDepartmentCode.SelectedValue;
        }

        protected void GridCompanyDivision_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridCompanyDivision_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}