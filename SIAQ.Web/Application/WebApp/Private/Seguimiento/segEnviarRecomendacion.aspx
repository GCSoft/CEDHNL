<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segEnviarRecomendacion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segEnviarRecomendacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    <asp:Label ID="lblEncabezado" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Confirme la información antes de enviar el expediente de atención a víctimas."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial"><asp:Label ID="lblNumero" runat="server" ></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="RecomendacionNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Expediente Número</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="ExpedienteNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus Seguimiento</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="TipoLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de recepción</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de inicio en quejas</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaQuejasLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Funcionario</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FuncionarioLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de inicio en visitadurías</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaVisitaduriasLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Nombre Autoridad</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="NombreAutoridadLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de asignación</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Puesto</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="PuestoAutoridadLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Última modificación</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaModificacionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Niveles de Autoridad</td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="NivelesAutoridadLabel" runat="server"></asp:Label></td>
			</tr>
			<tr style="height:10px;"><td colspan="7"></td></tr>
			<!-- Fin de carátula -->
        </table>

        <!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="Button_General" width="125px" onclick="btnEnviar_Click" OnClientClick="return confirm('¿Seguro que desea enviar el expediente de atención de víctimas para su aprobación?');" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

    </div>

	<div id="CheckList">
		<asp:Panel ID="pnlEnviarAutoridad" runat="server" CssClass="IconoPanel">
			<asp:Image ID="imgEnviarAutoridad" runat="server" ImageUrl="~/Include/Image/Icon/NotificacionIcon_Success.png" /><br />
            Enviar a Autoridad 
        </asp:Panel>
		<asp:Panel ID="pnSeguimiento" runat="server" CssClass="IconoPanel">
			<asp:Image ID="imgSeguimiento" runat="server" ImageUrl="~/Include/Image/Icon/SeguimientoIcon_Success.png" /><br />
            Seguimiento
        </asp:Panel>
		<asp:Panel ID="pnlImpugnar" runat="server" CssClass="IconoPanel">
			<asp:Image ID="imgImpugnar" runat="server" ImageUrl="~/Include/Image/Icon/ComparecenciaIcon_Success.png" /><br />
            Impugnar
        </asp:Panel>
    </div>

    <asp:HiddenField ID="hddRecomendacionId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

</asp:Content>
