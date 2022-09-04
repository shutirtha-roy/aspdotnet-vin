<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInformationForm.aspx.cs" Inherits="HRISWebApplication.Setup.CompanyInformationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">
    <link href="../Content/css/style.css" rel="stylesheet" />
</head>

<body>
    <div class="text-center bg-primary">
        <h1 class="form-title">COMPANY SETUP</h1>
    </div>
 

    <form class="mt-5 mt-5" runat="server">

        <div class="mx-auto text-center mb-5" style="width: 620px;">
            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label1" runat="server" Text="Company ID"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtCompanyID" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label2" runat="server" Text="Company Name"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label3" runat="server" Text="Address 1"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label4" runat="server" Text="Address 2"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label5" runat="server" Text="Address 3"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtAddress3" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label6" runat="server" Text="Contact Person Address"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtContactPersonAddress" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label7" runat="server" Text="Contact Person Email"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtContactPersonEmail" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label8" runat="server" Text="Phone Number"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label9" runat="server" Text="Fax"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtFax" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label10" runat="server" Text="Email"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label11" runat="server" Text="URL"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtURL" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label12" runat="server" Text="TIN"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtTin" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label13" runat="server" Text="Reg No"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtRegNo" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label14" runat="server" Text="Vat No"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtVatNo" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label15" runat="server" Text="Insurance"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtInsurance" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <asp:Button CssClass="btn btn-primary btn-lg mb-5" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            &nbsp;
            <asp:Button CssClass="btn btn-info btn-lg mb-5" ID="btnClearForm" runat="server" Text="ClearForm" OnClick="btnClearForm_Click" />
        </div>

        

        <asp:GridView ID="GridCompany" class="table text-center table-font company-information mt-5 table-striped table-bordered" runat="server" OnRowDeleting="GridCompany_RowDeleting" OnRowCommand="GridCompany_RowCommand">
            <Columns>
                <asp:CommandField ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True" />
                <asp:CommandField ControlStyle-CssClass="btn btn-info" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <p>&nbsp;</p>
        <p>&nbsp;</p>

    </form>

    
</body>


<script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.min.js" integrity="sha384-+sLIOodYLS7CIrQpBjl+C7nPvqq+FbNUBDunl/OZv93DB7Ln/533i8e/mZXLi/P+" crossorigin="anonymous"></script>

</html>

