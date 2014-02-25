<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarDocumentos.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarDocumentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
        .style2
        {
            height: 30px;
        }
        .style3
        {
            height: 46px;
        }
        .style4
        {
            height: 26px;
        }
        .style5
        {
            height: 35px;
            width: 126px;
            color:#979393;
	        font-family:Verdana;
	        font-size:13px;
	       font-weight:bold;
	        height: 27px;
	        text-align:left;
        }
        .style6
        {
            height: 26px;
            width: 126px;
        }
        .style7
        {
            width: 126px;
        }
        .style8
        {
            height: 46px;
            width: 131px;
        }
        .style9
        {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
     <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');"></td>
				 Agregar Documentos
	</tr>
 </table>
    <br />
<table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align:left;">
<tr>
  <td colspan="2" class="style2">Agregue aquellos documentos que sirvan para complementar la información de la solicitud</td>
  <td rowspan="5">&nbsp;</td>
</tr>
<tr>
  <td class="style5">Solicitud número</td>
  <td class="style9"></td>
</tr>
<tr>
  <td class="style6">Archivo</td>
  <td class="style4"><asp:FileUpload ID="FLArchivo" runat="server" Width="210px" /></td>
</tr>
<tr>
  <td class="style6">Nombre</td>
  <td class="style4"><asp:TextBox ID="TextBoxNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
</tr>
<tr>
  <td class="style7">Descripción</td>
  <td><asp:TextBox ID="TextBoxMaterno" runat="server" CssClass="Textbox_General" TextMode="MultiLine" Height="100px" width="360px" ></asp:TextBox></td>
</tr>
<tr>
  <td colspan="2">
  <table width="100%" border="0">
  <tr>
  <td style="text-align:left;" class="style8"><asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="Button_General" width="125px"/></td>
  <td style="text-align:left;" class="style3"><asp:Button ID="Button2" runat="server" Text="Regresar" CssClass="Button_General" width="125px"/></td>
  </tr>
</table>
  </td>
</tr>
</table>
</asp:Content>
