<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarIndicadores.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarIndicadores" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">   
        .CeldaTabla 
        {
            border-bottom: 1px solid #cccccc;
	        background-color: #ececff;
	        border-spacing: 5px;
	        font-size: 11px;
	        font-weight: bold;
	        padding: 5px;
	        text-align:left;
        }
        .style1
        {
            width: 186px;
        }
        .style2
        {
            width: 351px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
          <tr>
			    <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				     Agregar Indicadores
			    </td>
		    </tr>
     </table>
     <br />
     <div style="text-align:left;">
        <label style="font-size: 11px;">Seleccione los distintos indicadores que cumplan con una mejor descripción de la solicitud y del quejoso</label>
     </div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
           <tr>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="CeldaTabla">Condición de la víctima</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>
            <table width="100%" border="0" style="text-align:left;">
                  <tr>
                    <td style="font-size: 12px; width:50%;"><asp:CheckBox Text="Menor de edad" runat="server" ID="CBMenorEdad" /></td>
                    <td style="font-size: 12px;"><asp:CheckBox Text="Migrante internacional" runat="server" ID="CBMigranteInternaccional" /></td>
                  </tr>
                  <tr>
                    <td style="font-size: 12px; width:50%;"><asp:CheckBox Text="Adulto mayor" runat="server" ID="CBAdultoMayor" /></td>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td style="font-size: 12px; width:50%;"><asp:CheckBox Text="Migrante nacional" runat="server" ID="CBMigranteNacional" /></td>
                    <td>&nbsp;</td>
                  </tr>
           </table>

            </td>
         </tr>
         <tr>
            <td>&nbsp;</td>
         </tr>
      <tr>
        <td class="CeldaTabla">Actividad de la víctima</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>
            <table width="100%" border="0" style="text-align:left;">
              <tr>
                <td style="font-size: 12px; width:50%;"><asp:CheckBox Text="Jornalero" runat="server" ID="CBJornalero" /></td>
                <td style="font-size: 12px;"><asp:CheckBox Text="Construcción" runat="server" ID="CBConstruccion" /></td>
              </tr>
              <tr>
                <td style="font-size: 12px; width:50%;"><asp:CheckBox Text="Sexo servidora"  runat="server" ID="CBSexoServidora" /></td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td style="font-size: 12px; width:50%;"><asp:CheckBox Text="Empleada doméstica"  runat="server" ID="CBEmpleadaDomestica" /></td>
                <td>&nbsp;</td>
              </tr>
            </table>
                </td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td>
                <table width="100%" border="0">
              <tr>
                <td style="text-align:left;" class="style1"><asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="Button_General" width="125px"/>&nbsp;&nbsp;&nbsp;
                <input class="Button_General" id="RegresarButton" onclick="document.location.href='opeDetalleSolicitud.aspx?s=<%= _SolicitudId %>';" style="width: 125px;" type="button" value="Regresar" /></td>
              </tr>
            </table>
        </td>
      </tr>
    </table>
</asp:Content>

