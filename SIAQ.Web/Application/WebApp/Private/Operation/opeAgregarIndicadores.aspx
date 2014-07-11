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
				     Agregar grupos minoritarios
			    </td>
		    </tr>
     </table>
     <br />
     <div style="text-align:left;">
        <label style="font-size: 13px;">Seleccione los distintos indicadores que cumplan con una mejor descripción de la solicitud y del quejoso</label>
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
                <td style="text-align:left;" class="style1">
					<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General" width="125px" onclick="btnGuardar_Click"/>&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click"/>
				</td>
              </tr>
            </table>
        </td>
      </tr>
    </table>

	<asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0"  />

</asp:Content>

