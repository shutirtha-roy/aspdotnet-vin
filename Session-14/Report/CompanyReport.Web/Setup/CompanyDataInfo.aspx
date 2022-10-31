<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyDataInfo.aspx.cs" Inherits="CompanyReport.Web.Setup.CompanyDataInfo" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>View Report</title>
  <script lang="javaScript" type="text/javascript" src="crystalreportviewers13/js/crviewer/crv.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"/>
        </div>
    </form>
</body>
</html>
