<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptPresentaReporte.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Reportes.rptPresentaReporte" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIAQ</title>
    <link href="~/Include/Style/Control.css" rel="Stylesheet" type="text/css" />
	<link href="~/Include/Style/MasterPage.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
		<asp:Panel ID="pnlNonMenuTemplateHeader" CssClass="Header" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" style="height:104px; width:100%">
				<tr>
					<td style="width:1024px;"><img id="Img1" alt="GCSoft" runat="server" src="~/Include/Image/Web/Banner.png" /></td>
					<td style="background-image:url('../../../../Include/Image/Web/BannerFill.png'); background-repeat:repeat-x;">&nbsp;</td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="pnlNonMenuTemplateCanvas" CssClass="NonMenuCanvas" style="background-color:#8E8E8E" runat="server">
			<br />
			<div id="divCanvas" runat="server" style="margin:0px auto; position:relative; width:800px;">
				<CR:CrystalReportViewer ID="crViewer" runat="server" AutoDataBind="True" BestFitPage="True" HasCrystalLogo="False" HasRefreshButton="True" HasToggleGroupTreeButton="false" ToolPanelView="None" />
			</div>
			<br />
		</asp:Panel>
		<div class="GCSoft"><img id="imgCompany" alt="SetUp" runat="server" src="~/Include/Image/Web/SetUp.png" /></div>
    </form>
</body>
</html>
