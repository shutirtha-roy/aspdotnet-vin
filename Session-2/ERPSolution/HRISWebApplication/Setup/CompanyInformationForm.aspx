<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInformationForm.aspx.cs" Inherits="HRISWebApplication.Setup.CompanyInformationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>

<body>
    <h1 class="bg-primary text-center">COMPANY SETUP</h1>

    <form id="form1" runat="server" class="text-center">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Company ID" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyID" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Company Name" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompanyName" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Address 1" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Address 2" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Address 3" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress3" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Contact Person Address" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContactPersonAddress" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Contact Person Email" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContactPersonEmail" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Phone Number" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Fax" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Email" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="URL" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtURL" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="TIN" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTin" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Reg No" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRegNo" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="Vat No" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVatNo" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Insurance" Width="450px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtInsurance" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>


        </table>

        <asp:Button class="bg-primary h4" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

    </form>
</body>
</html>
