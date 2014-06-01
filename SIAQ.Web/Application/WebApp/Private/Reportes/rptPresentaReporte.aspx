<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptPresentaReporte.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Reportes.rptPresentaReporte" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.Button_General{
  	font-family: Arial;
	font-size: 11px;
	color: #FFFFFF;
	cursor:pointer;
	background-color: #4B4878;
	border-top-width: 1px;
	border-right-width: 1px;
	border-bottom-width: 1px;
	border-left-width: 1px;
	border-top-style: solid;
	border-top-color: #808080;
	border-right-color: #808080;
	border-bottom-color: #808080;
	border-left-color: #808080;
	margin-top: 4px;
	font-weight: bold;
	margin-bottom: 4px;
	padding-top: 2px;
	padding-right: 0px;
	padding-bottom: 2px;
	padding-left: 0px;
	height:20px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td style="width:20%;"></td>
            <td>
                <asp:Image ID="Image1" runat="server" 
                    ImageUrl="~/Include/Image/Vectores/Banner.png" />
            </td>
            <td style="width:20%;"></td>
        </tr>
        <tr>
            <td style="width:20%;"></td>
            <td>
                                <asp:Button ID="cmdCerrar" 
                                    runat="server" Text="Cerrar" CssClass="Button_General" width="125px" 
                                    onclick="cmdCerrar_Click" />
                <br />
            </td>
            <td style="width:20%;"></td>
        </tr>
        <tr>
            <td style="width:20%;"></td>
            <td>
                <div>
    
                    <CR:CrystalReportViewer ID="crViewer" runat="server" 
                        AutoDataBind="true" />
                </div>
            </td>
            <td style="width:20%;"></td>
        </tr>
    
    </table>
    </form>
</body>
</html>
