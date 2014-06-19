<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="vicConfirmarCierreAtencion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Victimas.vicConfirmarCierreAtencion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Confirmar cierre de expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Confirme si el expediente va a ser cerrado."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial">Atención número</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="AtencionNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Expediente número</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="ExpedienteNumeroLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre"></td>
				<td class="Espacio"></td>
				<td class="Etiqueta"></td>
			</tr>
			<tr>
				<td class="Nombre">Solicitud número</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="SolicitudNumeroLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre"></td>
				<td class="Espacio"></td>
				<td class="Etiqueta"></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre"></td>
				<td class="Espacio"></td>
				<td class="Etiqueta"></td>
			</tr>
			<tr>
                <td class="Nombre">Doctor</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="DoctorLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de Atención</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaAtencionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Observaciones</td>
                <td class="Espacio"></td>
                <td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>

        <!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnCerrar" runat="server" Text="Cerrar Expediente" CssClass="Button_General" width="125px" onclick="btnCerrar_Click" OnClientClick="return confirm('¿Seguro que desea cerrar definitivamente el expediente de atención a víctimas?');" /> &nbsp;&nbsp;
					<asp:Button ID="btnDenegar" runat="server" Text="Denegar Cierre" CssClass="Button_General" width="125px" onclick="btnDenegar_Click" OnClientClick="return confirm('Está opción regresará expediente al doctor asignado, ¿Seguro que desea continuar?');" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

    </div>

    <asp:HiddenField ID="hddAtencionId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

</asp:Content>
