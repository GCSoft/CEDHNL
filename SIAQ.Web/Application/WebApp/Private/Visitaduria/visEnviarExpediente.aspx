<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="visEnviarExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.visEnviarExpediente" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   
   <div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Enviar expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Confirme la información antes de enviar el expediente."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial">Expediente Número</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="ExpedienteNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Solicitud Número</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="SolicitudNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Calificación</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="CalificacionLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Afectado/Quejoso</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="AfectadoLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Resolución</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="ResolucionLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Area</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="AreaLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de recepción</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="EstatusaLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de asignación</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Funcionario</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FuncionarioLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de inicio en quejas</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaQuejasLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Forma de contacto</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="ContactoLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de inicio en visitadurías</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaVisitaduriasLabel" runat="server" Text=""></asp:Label></td>
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
				<td class="Nombre">Problemática</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="ProblematicaLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Nivel de Autoridad</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="NivelAutoridadLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Detalle de Problemática</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="ProblematicaDetalleLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Mecanismo de Apertura</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="MecanismoAperturaLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Lugar de los hechos</td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="LugarHechosLabel" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Dirección de los hechos</td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="DireccionHechosLabel" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Observaciones</td>
				<td class="Espacio"></td>
				<td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Fundamento</td>
				<td class="Espacio"></td>
				<td class="Observaciones" colspan="5"><asp:Label ID="FundamentoLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre"><asp:Label ID="CierreOrientacionLabel" runat="server" Text="Cierre de Orientación"></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="TipoOrientacionLabel" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre"><asp:Label ID="CanalizacionesLabel" runat="server" Text="Canalizaciones" Visible="false"></asp:Label></td>
				<td class="Espacio"></td>
				<td colspan="5">
					<asp:GridView ID="grdCanalizacion" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" CssClass="GridDinamico" ShowHeader="false" Width="100%">
						<RowStyle CssClass="Grid_Row_Action" />
						<EditRowStyle Wrap="True" />
						<Columns>
							<asp:BoundField DataField="Nombre" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100%"></asp:BoundField>
						</Columns>
					</asp:GridView>
				</td>
			</tr>
        </table>
		<br />

		<!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="Button_General" width="125px" onclick="btnEnviar_Click" OnClientClick="return confirm('¿Seguro que desea enviar el Expediente para su aprobación?');" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

	</div>

	<div id="CheckList">
		<asp:Panel ID="pnlGestion" runat="server" CssClass="IconoPanel">
			<asp:Image ID="imgGestion" runat="server" ImageUrl="~/Include/Image/Icon/SeguimientoIcon_Success.png" /><br />
            Gestión
        </asp:Panel>
		<asp:Panel ID="pnlComparecencia" runat="server" CssClass="IconoPanel">
			<asp:Image ID="imgComparecencia" runat="server" ImageUrl="~/Include/Image/Icon/ComparecenciaIcon_Success.png" /><br />
            Comparecencia
        </asp:Panel>
		<asp:Panel ID="pnlAutoridad" runat="server" CssClass="IconoPanel">
			<asp:Image ID="imgAutoridad" runat="server" ImageUrl="~/Include/Image/Icon/AutoridadIcon_Success.png" /><br />
            Autoridades y Voces
        </asp:Panel>
		<asp:Panel ID="pnlResolucion" runat="server" CssClass="IconoPanel">
			<asp:Image ID="imgResolucion" runat="server" ImageUrl="~/Include/Image/Icon/ResolucionIcon_Success.png" /><br />
            Resolución
        </asp:Panel>
		<asp:Panel ID="pnlRecomendacion" runat="server" CssClass="IconoPanel">
			<asp:Image ID="imgRecomendacion" runat="server" ImageUrl="~/Include/Image/Icon/RecomendacionIcon_Success.png" /><br />
            Recomendación
        </asp:Panel>
		<asp:Panel ID="pnlAcuerdoNoResponsabilidad" runat="server" CssClass="IconoPanel">
			<asp:Image ID="imgAcuerdoNoResponsabilidad" runat="server" ImageUrl="~/Include/Image/Icon/RecomendacionIcon_Success.png" /><br />
            Acuerdo de No Responsabilidad
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="AtencionPanel" runat="server" Visible="true">
			<asp:Image ID="imgAtencion" runat="server" ImageUrl="~/Include/Image/Icon/AtencionVictimasIcon_Success.png"  /><br />
            Atención a víctimas
        </asp:Panel>
		 <%--<div id="Asuntos" style="clear:both; text-align:left;">
			<br />
			 <asp:Label ID="lblAsuntos" runat="server" CssClass="Asunto_Success"></asp:Label>
        </div>--%>
    </div>

	<asp:HiddenField ID="hddExpedienteId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

</asp:Content>
