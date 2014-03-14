<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeCalificarSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeCalificarSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
        .style2
        {
            width: 136px;
            font-size: 11px;
        }
        .style3
        {
            width: 151px;
            
        }
        .TamanoLetraNormal
        {
            font-size:11px;
            
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				 Calificar Solicitud
			</td>
		</tr>
</table>
  <br />
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
       <tr class="trFilaItem">
       <td class="Solicitud">Solicitud Número</td>
       <td style="width:5px;"></td>
	   <td class="tdCeldaItem"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
       </tr>
   </table>
  <br />
 <div style="text-align:left;">
    <asp:Label ID="Label1" CssClass="TamanoLetraNormal" runat="server">Especifica la calificación de la solicitud</asp:Label>
 </div>
  <br />
    <table  width="100%" border="0" cellspacing="0" style="text-align:left">
        <tr>
          <td class="style2">Calificación</td>
          <td><asp:DropDownList ID="ddlCalificacion" width="214px" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
          <td class="style2">Cierre de orientación</td>
          <td><asp:DropDownList ID="ddlCierre" width="214px" runat="server"></asp:DropDownList></td>
        </tr>
       <tr>
         <td class="style2">Canalizado a</td>
         <td><asp:DropDownList ID="ddlCanalizado" width="214px" runat="server"></asp:DropDownList></td>
       </tr>
       <tr>
        <td class="style2">Fundamento</td>
        <td>
            <asp:TextBox ID="TextBoxFundamento" runat="server" CssClass="Textbox_General" TextMode="MultiLine" Height="100px" width="360px" ></asp:TextBox></td>
     </tr>
    </table>
        <br />  <br />
    <table width="100%" border="0">
          <tr>
          <td style="text-align:left;" class="style3"><asp:Button ID="Button1" runat="server" 
                  Text="Guardar" CssClass="Button_General" width="125px" onclick="GuardarCalificacionSol_Click"/></td>
          <td style="text-align:left;"><input class="Button_General" id="RegresarButton" onclick="document.location.href='opeDetalleSolicitud.aspx?s=<%= _SolicitudId %>';" style="width: 125px;" type="button" value="Regresar" /></td>
          </tr>
    </table>
    <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
</asp:Content>
