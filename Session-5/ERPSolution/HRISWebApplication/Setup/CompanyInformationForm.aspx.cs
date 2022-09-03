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
            if(btnSave.Text.Equals("Save"))
            {
                SaveCompanyInformation();
                ShowCompanyInformation();
                ClearAllFormControl();
            }
            else if (btnSave.Text.Equals("Update"))
            {
                UpdateCompanyInformation();
                btnSave.Text = "Save";
                ShowCompanyInformation();
                ClearAllFormControl();
            }

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
        private void UpdateCompanyInformation()
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

            companyDataAccess.Update(companyDetails);
        }

        protected void GridCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void GridCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName.Equals("Select"))
            {
                //string test = GridCompany.Rows[index].Cells[2].Text.Equals("&nbsp;") ? "" : GridCompany.Rows[index].Cells[2].Text;

                txtCompanyID.Text = GridCompany.Rows[index].Cells[2].Text;
                txtCompanyName.Text = GridCompany.Rows[index].Cells[3].Text;
                txtAddress1.Text = GridCompany.Rows[index].Cells[4].Text;
                txtAddress2.Text = GridCompany.Rows[index].Cells[5].Text;
                txtAddress3.Text = GridCompany.Rows[index].Cells[6].Text;
                txtContactPersonAddress.Text = GridCompany.Rows[index].Cells[7].Text;
                txtContactPersonEmail.Text = GridCompany.Rows[index].Cells[8].Text;
                txtPhoneNumber.Text = GridCompany.Rows[index].Cells[9].Text;
                txtFax.Text = GridCompany.Rows[index].Cells[10].Text;
                txtEmail.Text = GridCompany.Rows[index].Cells[11].Text;
                txtURL.Text = GridCompany.Rows[index].Cells[12].Text;
                txtTin.Text = GridCompany.Rows[index].Cells[13].Text;
                txtRegNo.Text = GridCompany.Rows[index].Cells[14].Text;
                txtVatNo.Text = GridCompany.Rows[index].Cells[15].Text;
                txtInsurance.Text = GridCompany.Rows[index].Cells[16].Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName.Equals("Delete"))
            {
                string cid = GridCompany.Rows[index].Cells[2].Text;
                companyDataAccess.DeleteRow(cid);
                ShowCompanyInformation();
            }
        }
    }
}