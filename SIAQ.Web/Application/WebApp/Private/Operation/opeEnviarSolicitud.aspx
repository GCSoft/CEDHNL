<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeEnviarSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeEnviarSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
        .style1
        {
            width: 175px;
        }
        
        .style2
        {
            width:100px;
            color:#979393;
	        font-family:Verdana;
	        font-size:13px;
	        font-weight:bold;
	        height: 27px;
	        text-align:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
     <table border="0" cellpadding="0" cellspacing="0" width="100%">
         <tr>
	         <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
	            Enviar Solicitud
	         </td>
	     </tr>
     </table>
     <br />
     <div style="text-align:left;">
        <asp:Label ID="Label1" runat="server">Por favor confirme el envío de la solicitud, una vez enviada ya no se podra modificar su contenido</asp:Label>
     </div>
     <br />
     <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr class="trFilaItem">
         <td class="style2">Solicitud Número</td>
         <td style="width:5px;"></td>
	     <td class="tdCeldaItem"><asp:Label ID="lbNumeroSolictud" runat="server" ></asp:Label></td>
      </tr>
    </table>
      <br />
    <table width="100%" border="0" style="text-align:left">
      <tr>
        <td>Calificacion</td>
        <td><asp:TextBox ID="txtNombre" Enabled="false" runat="server" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
          <td>Estatus</td>
        <td><asp:TextBox ID="txtvh"  runat="server" Enabled="false" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
        <td>&nbsp;</td>
        <td>Fecha de recepción</td>
        <td><asp:TextBox ID="TextBox4" runat="server" Enabled="false" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
      </tr>
      <tr>
          <td>Funcionario</td>
        <td><asp:TextBox ID="txtNofvmbre" runat="server" Enabled="false" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
        <td>&nbsp;</td>
        <td>Fecha de asignación</td>
        <td><asp:TextBox ID="TextBox1" runat="server" Enabled="false" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
      </tr>
      <tr>
          <td>Forma de Contacto</td>
        <td><asp:TextBox ID="txt7" runat="server" Enabled="false" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
        <td>&nbsp;</td>
        <td>Fecha de inicio de gestión</td>
        <td><asp:TextBox ID="TextBox2" runat="server" Enabled="false" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
      </tr>
      <tr>
          <td>Tipo Solicitud</td>
        <td><asp:TextBox ID="txtNogmbre" runat="server" Enabled="false" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
        <td>&nbsp;</td>
        <td>Última modificación</td>
        <td><asp:TextBox ID="TextBox3" runat="server" Enabled="false" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
      </tr>
      <tr>
         <td>Observaciónes (Recepción)</td>
        <td colspan="4"><asp:TextBox ID="txtgrNombre" Enabled="false" runat="server" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
      </tr>
      <tr>
        <td>Lugar de los hechos</td>
        <td><asp:TextBox ID="txtNodfvmbre" Enabled="false" runat="server" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
          <td>Direccion de los hechos</td>
        <td colspan="4"><asp:TextBox ID="txtNcc" Enabled="false" runat="server" CssClass="Textbox_General" width="180px" ></asp:TextBox></td>
      </tr>
    </table>
      <br />
    <table width="100%" border="0">
      <tr>
      <td style="text-align:left;" class="style1"><asp:Button ID="Button1" runat="server" Text="Enviar Solicitud" CssClass="Button_General" width="160px"/></td>
      <td style="text-align:left;"><asp:Button ID="Button2" runat="server" Text="Regresar" CssClass="Button_General" width="125px"/></td>
      </tr>
    </table>
</asp:Content>
