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
        </table>
    </form>
</body>
</html>
