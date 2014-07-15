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
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Agregar grupos minoritarios
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Seleccione los distintos indicadores que cumplan con una mejor descripción de la solicitud y del quejoso."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial">Solicitud Número</td>
                <td class="Espacio"></td>
                <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td class="Nombre">Calificación</td>
                <td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="CalificacionLabel" runat="server" Text=""></asp:Label></td>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td class="Nombre">Estatus</td>
                <td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="EstatusaLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de recepción</td>
                <td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Funcionario</td>
                <td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FuncionarioLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de asignación</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
			<tr>
                <td class="Nombre">Forma de contacto</td>
                <td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="ContactoLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de inicio gestión</td>
                <td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaGestionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
			<tr>
                <td class="Nombre">Tipo de solicitud</td>
                <td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="TipoSolicitudLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Última modificación</td>
                <td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaModificacionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Observaciones (Recepción)</td>
                <td class="Espacio"></td>
				<td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Lugar de los hechos</td>
                <td class="Espacio"></td>
                <td class="Etiqueta" colspan="5"><asp:Label ID="LugarHechosLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Dirección de los hechos</td>
                <td class="Espacio"></td>
                <td class="Etiqueta" colspan="5"><asp:Label ID="DireccionHechosLabel" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
		<br />

		<!-- Grupos Minoritarios  -->
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
		</table>

		<!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General" width="125px" onclick="btnGuardar_Click"/> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click"/>
                </td>
            </tr>
        </table>

	</div>

	<asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0"  />

</asp:Content>

