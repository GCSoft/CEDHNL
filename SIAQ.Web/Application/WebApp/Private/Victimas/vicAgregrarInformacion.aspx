<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="vicAgregrarInformacion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Victimas.vicAgregrarInformacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Agregar información al Expediente de Atención a Víctimas
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Agregue información al expediente de ateción a víctimas."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial">Folio</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="AtencionNumeroFolio" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Afectado</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="AfectadoLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">No. Oficio</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="AtencionNumeroOficio" runat="server" Text=""></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Área</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="AreaLabel" runat="server" Text=""></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Expediente número</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="ExpedienteNumeroLabel" runat="server" Text=""></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Solicitud número</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="SolicitudNumeroLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de Atención</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaAtencionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de Asignación</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
                <td class="Nombre">Médico</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="DoctorLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Ultima Modificación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="UltimaModificacionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
			<tr>
				<td class="Nombre">Dictámen Médico</td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="DictamenMedicoLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Lugar de Revisión</td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="LugarRevisionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr style="height:10px;"><td colspan="7"></td></tr>
			<!-- Fin de carátula -->
			<tr>
                <td class="Nombre">Folio</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:TextBox ID="txtNumeroFolio" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
            </tr>
        </table>

        <!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General" width="125px" onclick="btnGuardar_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

    </div>

    <asp:HiddenField ID="hddAtencionId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

</asp:Content>
