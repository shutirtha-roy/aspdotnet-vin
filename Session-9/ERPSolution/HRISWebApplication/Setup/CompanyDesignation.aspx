<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CompanyDesignation.aspx.cs" Inherits="HRISWebApplication.Setup.CompanyDesignation" %>

<asp:Content ID="CompanyDesignationForm" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <h1 class="form-title">DESIGNATION SETUP</h1>
    </div>


    <form class="mt-5 mt-5" runat="server">
        <div class="mx-auto text-center mb-5" style="width: 620px;">
            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 ml-4 col-form-label col-form-label-lg text-large" ID="Label1" runat="server" Text="Select Company"></asp:Label>
                <asp:DropDownList CssClass="" ID="ddlCompanyDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyDivision_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 ml-4 col-form-label col-form-label-lg text-large" ID="Label8" runat="server" Text="Office Location"></asp:Label>
                <asp:DropDownList CssClass="" ID="ddlCompanyOfficeLocation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyOfficeLocation_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 ml-4 col-form-label col-form-label-lg text-large" ID="Label2" runat="server" Text="Department Code"></asp:Label>
                <asp:DropDownList CssClass="" ID="ddlCompanyDepartmentCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyDepartmentCode_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 ml-4 col-form-label col-form-label-lg text-large" ID="Label7" runat="server" Text="Section Code"></asp:Label>
                <asp:DropDownList CssClass="" ID="ddlCompanySectionCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanySectionCode_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label3" runat="server" Text="Designation Code"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtDesignationCode" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label4" runat="server" Text="Designation Name"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtDesignationName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                </div>
            </div>

            <asp:Button CssClass="btn btn-success btn-lg mb-5" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            &nbsp;
            <asp:Button CssClass="btn btn-secondary btn-lg mb-5" ID="btnClearForm" runat="server" Text="ClearForm" OnClick="btnClearForm_Click" />
        </div>

        <asp:GridView ID="GridCompanyDesignation" class="table text-center table-font company-information mt-5 table-striped table-bordered" runat="server" OnRowCommand="GridCompanyDepartment_RowCommand" OnRowDeleting="GridCompanyDesignation_RowDeleting" OnSelectedIndexChanged="GridCompanyDesignation_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True" />
                <asp:CommandField ControlStyle-CssClass="btn btn-info" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <p>&nbsp;</p>
        <p>&nbsp;</p>
    </form>
</asp:Content>