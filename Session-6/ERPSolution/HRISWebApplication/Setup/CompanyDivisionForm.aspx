<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyDivisionForm.aspx.cs" Inherits="HRISWebApplication.Setup.CompanyDivisionForm" %>

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
        <h1 class="form-title">OFFICE LOCATION SETUP</h1>
    </div>

    <form class="mt-5 mt-5"  runat="server">
        <div class="mx-auto text-center mb-5" style="width: 620px;">
            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 ml-4 col-form-label col-form-label-lg text-large" ID="Label1" runat="server" Text="Select Company"></asp:Label>
                <asp:DropDownList CssClass="" ID="ddlCompanyDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyDivision_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label2" runat="server" Text="Office Location Code"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtLocationCode" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label3" runat="server" Text="Office Location Name"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtLocationName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label4" runat="server" Text="Location"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label5" runat="server" Text="Address 1"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label6" runat="server" Text="Address 2"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label7" runat="server" Text="Address 3"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtAddress3" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <asp:Button CssClass="btn btn-primary btn-lg mb-5" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            &nbsp;
            <asp:Button CssClass="btn btn-info btn-lg mb-5" ID="btnClearForm" runat="server" Text="ClearForm" OnClick="btnClearForm_Click" />
        </div>

        <asp:GridView ID="GridCompanyDivision" class="table text-center table-font company-information mt-5 table-striped table-bordered" runat="server" OnRowCommand="GridCompanyDivision_RowCommand">
            <Columns>
                <asp:CommandField ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True" />
                <asp:CommandField ControlStyle-CssClass="btn btn-info" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
