using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRISWebApplication.Setup
{
    public partial class CompanyInformationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveCompanyInformation();
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

            throw new NotImplementedException();
        }
    }
}