using HRISWebApplication.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRISWebApplication.Setup
{
    public partial class CompanyInformationForm : System.Web.UI.Page
    {
        private readonly CompanyDataAccess companyDataAccess;
        public CompanyInformationForm()
        {
            companyDataAccess = new CompanyDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCompanyInformation();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveCompanyInformation();
            ShowCompanyInformation();
            ClearAllFormControl();
        }

        private void ShowCompanyInformation()
        {
            DataTable dt = companyDataAccess.GetAllCompanyInformation();
            GridCompany.DataSource = dt;
            GridCompany.DataBind();
        }

        private void ClearAllFormControl()
        {
            txtCompanyID.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtContactPersonAddress.Text = string.Empty;
            txtContactPersonEmail.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtURL.Text = string.Empty;
            txtTin.Text = string.Empty;
            txtRegNo.Text = string.Empty;
            txtVatNo.Text = string.Empty;
            txtInsurance.Text = string.Empty;
        }
        private void SaveCompanyInformation()
        {
            IDictionary<string, string> companyDetails = new Dictionary<string, string>()
            {
                { "companyId", txtCompanyID.Text },
                { "companyName", txtCompanyName.Text },
                { "address1", txtAddress1.Text },
                { "address2", txtAddress2.Text },
                { "address3", txtAddress3.Text },
                { "contactPersonAddress", txtContactPersonAddress.Text },
                { "contactPersonEmail", txtContactPersonEmail.Text },
                { "contactPersonPhoneNo", txtPhoneNumber.Text },
                { "fax", txtFax.Text },
                { "email", txtEmail.Text },
                { "url", txtURL.Text },
                { "tin", txtTin.Text },
                { "regNo", txtRegNo.Text },
                { "vatNo", txtVatNo.Text },
                { "insurance", txtInsurance.Text }
            };

            
            companyDataAccess.Save(companyDetails);
        }

        protected void GridCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            string cid = GridCompany.Rows[index].Cells[1].Text;
            companyDataAccess.DeleteRow(cid);
            ShowCompanyInformation();
        }

        protected void GridCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}