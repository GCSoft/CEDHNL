<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segImpugnacion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segImpugnacion" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

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
                    <asp:Label ID="Label1" runat="server" Text="Registre el envío del documento a la autoridad."></asp:Label>
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
        </table>

        <!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnImpugnar" runat="server" Text="Impugnar Documento" CssClass="Button_General" width="200px" onclick="btnImpugnar_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnRespuesta" runat="server" Text="Registrar Respuesta de Impugnación" CssClass="Button_General" width="200px" onclick="btnRespuesta_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="GridLabel" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvGestion" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
                        OnRowDataBound="gvGestion_RowDataBound" 
                        OnSorting="gvGestion_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:70px;">Fecha</td>
									<td style="width:200px;">Usuario</td>
									<td style="width:200px;">Estatus</td>
                                    <td>Gestión</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="4">No se ha gestionado el documento</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Fecha"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="Fecha"										SortExpression="Fecha"></asp:BoundField>
							<asp:BoundField HeaderText="Usuario"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="UsuarioNombre"								SortExpression="UsuarioNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="EstatusSeguimientoNombre"					SortExpression="EstatusSeguimientoNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Gestión"	ItemStyle-HorizontalAlign="Left"							DataField="Gestion"					HtmlEncode="false"	SortExpression="Gestion"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
        </table>

    </div>

	<!-- PopUp / Impugnar -->
	<asp:Panel id="pnlImpugnar" runat="server" CssClass="ActionBlock">
		<asp:Panel id="pnlImpugnarContent" runat="server" CssClass="ActionContent" style="top:100px;" Height="360px" Width="700px">
			<asp:Panel ID="pnlImpugnarHeader" runat="server" CssClass="ActionHeader">
				<table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
					<tr>
						<td style="width:10px"></td>
						<td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle"></asp:Label></td>
						<td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseImpugnarWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseImpugnarWindow_Click"></asp:ImageButton></td>
						<td style="width:10px"></td>
					</tr>
				</table>
			</asp:Panel>
			<asp:Panel ID="pnlImpugnarBody" runat="server" CssClass="ActionBody">
				<div style="margin:0 auto; width:98%;">
					<table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
						<tr style="height:20px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdActionCeldaLeyendaItem">&nbsp;Fecha de impugnacion</td>
							<td style="width:5px;"></td>
							<td><wuc:wucCalendar ID="calFechaImpugnar" runat="server" /></td>
						</tr>
						<tr style="height:5px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem"><td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Detalle</td></tr>
						<tr style="height:155px;">
							<td colspan="3">
								<CKEditor:CKEditorControl ID="ckeImpugnar" BasePath="~/Include/Components/CKEditor/Core/" runat="server" Height="90px" MaxLength="8000"></CKEditor:CKEditorControl>
							</td>
						</tr>
						<tr style="height:5px;"><td colspan="3"></td></tr>
						<tr>
							<td colspan="3" style="text-align:right;">
								<asp:Button ID="btnPopUpImpugnar" runat="server" Text="Impugnar" CssClass="Button_General" width="125px" onclick="btnPopUpImpugnar_Click" />
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:Label ID="lblActionMessageImpugnar" runat="server" CssClass="ActionContentMessage"></asp:Label>
							</td>
						</tr>
					</table>
				</div>
			</asp:Panel>
		</asp:Panel>
		<ajaxToolkit:DragPanelExtender id="dragPanelImpugnar" runat="server" TargetControlID="pnlImpugnarContent" DragHandleID="pnlImpugnarHeader"> </ajaxToolkit:DragPanelExtender>
	</asp:Panel>

	<!-- PopUp / Respuesta -->
	<asp:Panel id="pnlRespuesta" runat="server" CssClass="ActionBlock">
		<asp:Panel id="pnlRespuestaContent" runat="server" CssClass="ActionContent" style="top:100px;" Height="400px" Width="700px">
			<asp:Panel ID="pnlRespuestaHeader" runat="server" CssClass="ActionHeader">
				<table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
					<tr>
						<td style="width:10px"></td>
						<td style="text-align:left;"><asp:Label ID="Label2" runat="server" CssClass="ActionHeaderTitle"></asp:Label></td>
						<td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseRespuestaWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseRespuestaWindow_Click"></asp:ImageButton></td>
						<td style="width:10px"></td>
					</tr>
				</table>
			</asp:Panel>
			<asp:Panel ID="pnlRespuestaBody" runat="server" CssClass="ActionBody">
				<div style="margin:0 auto; width:98%;">
					<table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
						<tr style="height:20px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdActionCeldaLeyendaItem">&nbsp;Fecha de respuesta</td>
							<td style="width:5px;"></td>
							<td><wuc:wucCalendar ID="calFechaRespuesta" runat="server" /></td>
						</tr>
						<tr style="height:5px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem"><td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Detalle</td></tr>
						<tr style="height:155px;">
							<td colspan="3">
								<CKEditor:CKEditorControl ID="ckeRespuesta" BasePath="~/Include/Components/CKEditor/Core/" runat="server" Height="90px" MaxLength="8000"></CKEditor:CKEditorControl>
							</td>
						</tr>
						<tr style="height:5px;"><td colspan="3"></td></tr>
						<tr>
							<td colspan="3" style="text-align:right;">
								<asp:Button ID="btnPopUpRespuesta" runat="server" Text="Envío" CssClass="Button_General" width="125px" onclick="btnPopUpRespuesta_Click" />
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:Label ID="lblActionMessageRespuesta" runat="server" CssClass="ActionContentMessage"></asp:Label>
							</td>
						</tr>
					</table>
				</div>
			</asp:Panel>
		</asp:Panel>
		<ajaxToolkit:DragPanelExtender id="dragPanelRespuesta" runat="server" TargetControlID="pnlRespuestaContent" DragHandleID="pnlRespuestaHeader"> </ajaxToolkit:DragPanelExtender>
	</asp:Panel>

    <asp:HiddenField ID="hddRecomendacionId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddImpugnada" runat="server" Value="" />
	<asp:HiddenField ID="hddPublicada" runat="server" Value="" />
	<asp:HiddenField ID="hddSort" runat="server" Value="Fecha" />

</asp:Content>
