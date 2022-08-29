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
        private CompanyDataAccess companyDataAccess;
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
        }

        private void ShowCompanyInformation()
        {
            SqlDataReader reader = companyDataAccess.SaveAllCompanyInformation();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            reader.Close();
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
    }
}