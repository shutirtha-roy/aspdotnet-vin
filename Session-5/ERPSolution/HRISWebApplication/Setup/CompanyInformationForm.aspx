<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInformationForm.aspx.cs" Inherits="HRISWebApplication.Setup.CompanyInformationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="../Content/css/style.css" rel="stylesheet" />
</head>

<body>
    <div class="bg-primary text-center">
        <h1 class="form-title">COMPANY SETUP</h1>
    </div>
    

    <form id="form1" runat="server" class="text-left form-left company-input-form">
        <table style="width: 90%;">
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label1" runat="server" Text="Company ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyID" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label2" runat="server" Text="Company Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label3" runat="server" Text="Address 1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label4" runat="server" Text="Address 2"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label5" runat="server" Text="Address 3"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress3" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label6" runat="server" Text="Contact Person Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContactPersonAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label7" runat="server" Text="Contact Person Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContactPersonEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label8" runat="server" Text="Phone Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label9" runat="server" Text="Fax"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label10" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label11" runat="server" Text="URL"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtURL" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label12" runat="server" Text="TIN"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTin" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label13" runat="server" Text="Reg No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRegNo" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label14" runat="server" Text="Vat No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVatNo" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Label CssClass="text-large" ID="Label15" runat="server" Text="Insurance"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtInsurance" runat="server" CssClass="form-control form-width"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="text-center">
                    <asp:Button CssClass="btn btn-lg bg-primary h4" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>

        <asp:GridView ID="GridCompany" class="table text-center table-font company-information" runat="server" OnRowDeleting="GridCompany_RowDeleting" OnRowCommand="GridCompany_RowCommand">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </form>

    
</body>
</html>
