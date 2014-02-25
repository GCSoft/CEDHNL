<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAregarIndicadores.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAregarIndicadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
<style type="text/css">
    
.CeldaTabla 
{
    border-bottom: 1px solid #cccccc;
	background-color: #ececff;
	border-spacing: 5px;
	font-weight: bold;
	padding: 5px;
	text-align:left;
}
  </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				 Agregar Indicadores
			</td>
		</tr>
 </table>
   <br />
 <div style="text-align:left;">
 <asp:Label ID="Label1" runat="server">Seleccione los distintos indicadores que cumplan con una mejor descripción de la solicitud y del quejoso</asp:Label>
 </div>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
    <td class="CeldaTabla">Condición de la víctima</td>
  </tr>
  <tr>
    <td>
    <table width="100%" border="0">
  <tr>
    <td> <asp:CheckBox Text="Menor de edad" runat="server" ID="CBMenorEdad" /></td>
    <td>Migrante internacional</td>
  </tr>
  <tr>
    <td><asp:CheckBox Text="Adulto mayor" runat="server" ID="CBAdultoMayor" /></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><asp:CheckBox Text="Migrante nacional" runat="server" ID="CBMigranteNacional" /></td>
    <td>&nbsp;</td>
  </tr>
</table>

    </td>
  </tr>
  <tr>
    <td class="CeldaTabla"><asp:CheckBox Text="Actividad de la víctima" runat="server" ID="CBActividadVictima" /></td>
  </tr>
  <tr>
    <td>
        <table width="100%" border="0">
  <tr>
    <td><asp:CheckBox Text="Jornalero" runat="server" ID="CBJornalero" /></td>
    <td><asp:CheckBox Text="Construcción" runat="server" ID="CBConstruccion" /></td>
  </tr>
  <tr>
    <td><asp:CheckBox Text="Sexo servidora"  runat="server" ID="CBSexoServidora" /></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><asp:CheckBox Text="Empleada doméstica"  runat="server" ID="CBEmpleadaDomestica" /></td>
    <td>&nbsp;</td>
  </tr>
</table>
    </td>
  </tr>
  <tr>
    <td>
    <table width="100%" border="0">
  <tr>
  <td style="text-align:left;" class="style1"><asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="Button_General" width="160px"/></td>
  <td style="text-align:left;"><asp:Button ID="Button2" runat="server" Text="Regresar" CssClass="Button_General" width="125px"/></td>
  </tr>
</table>
    </td>
  </tr>
</table>
</asp:Content>
