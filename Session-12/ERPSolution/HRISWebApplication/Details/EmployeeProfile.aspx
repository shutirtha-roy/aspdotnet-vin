<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeProfile.aspx.cs" Inherits="HRISWebApplication.Details.EmployeeProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="CompanyTabForm" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    
                    <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server">
                                    <ajaxToolkit:TabContainer ID="TabContainer1" CssClass="MyTabStyle" Width="100%" Height="600px" runat="server" ActiveTabIndex="4">
                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Basic Information">
                                            <ContentTemplate>

                                                <div class="mx-auto text-center mb-5 mt-5 pt-5" style="width: 620px;">
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
                                                        <asp:Label CssClass="col-sm-4 ml-4 col-form-label col-form-label-lg text-large" ID="Label4" runat="server" Text="Designation Code"></asp:Label>
                                                        <asp:DropDownList CssClass="" ID="ddlCompanyDesignationCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyDesignationCode_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="form-group row">
                                                        <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label3" runat="server" Text="Employee Name"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <asp:Button CssClass="btn btn-success btn-lg mb-5" ID="btnSave" runat="server" Text="SaveBasicInfo" OnClick="btnSaveBasicInfo_Click" />
                                                    &nbsp;
                                                    <asp:Button CssClass="btn btn-success btn-lg mb-5" ID="Button2" runat="server" Text="SavePermanently" OnClick="btnSavePermanently_Click" />
                                                </div>



                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Education Qualification">
                                            <ContentTemplate>
                                                <div class="mx-auto text-center mb-5 mt-5 pt-5" style="width: 620px;">
                                                    <div class="form-group row">
                                                        <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label6" runat="server" Text="Employee School"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox ID="txtEmployeeSchool" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label5" runat="server" Text="Employee University"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox ID="txtEmployeeUniversity" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <asp:Button CssClass="btn btn-success btn-lg mb-5" ID="Button1" runat="server" Text="SaveEducationInfo" OnClick="btnSaveEducationInfo_Click" />
                                                    &nbsp;
                                                    <asp:Button CssClass="btn btn-success btn-lg mb-5" ID="Button4" runat="server" Text="SavePermanently" OnClick="btnSavePermanently_Click" />
                                                </div>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Personal Information">
                                            <ContentTemplate>
                                                <div class="mx-auto text-center mb-5 mt-5 pt-5" style="width: 620px;">
                                                    <div class="form-group row">
                                                        <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label9" runat="server" Text="Employee Father Name"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox ID="txtEmployeeFatherName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label10" runat="server" Text="Employee Mother Name"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox ID="txtEmployeeMotherName" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <asp:Label CssClass="col-sm-4 col-form-label col-form-label-lg text-large" ID="Label11" runat="server" Text="Employee Address"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox ID="txtEmployeeAddress" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <asp:Button CssClass="btn btn-success btn-lg mb-5" ID="Button3" runat="server" Text="SavePersonalInfo" OnClick="btnSavePersonalInfo_Click" />
                                                    &nbsp;
                                                    <asp:Button CssClass="btn btn-success btn-lg mb-5" ID="Button5" runat="server" Text="SavePermanently" OnClick="btnSavePermanently_Click" />
                                                </div>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>
                                        
                                    </ajaxToolkit:TabContainer>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>

        <asp:GridView ID="GridCompanyEmployeeProfile" class="table text-center table-font company-information mt-5 table-striped table-bordered" runat="server" OnRowCommand="GridCompanyEmployeeProfile_RowCommand" OnRowDeleting="GridCompanyEmployeeProfile_RowDeleting" OnSelectedIndexChanged="GridCompanyEmployeeProfile_SelectedIndexChanged">
            <Columns>
                
            </Columns>
        </asp:GridView>

        <p>&nbsp;</p>
        <p>&nbsp;</p>
    </form>


    
</asp:Content>