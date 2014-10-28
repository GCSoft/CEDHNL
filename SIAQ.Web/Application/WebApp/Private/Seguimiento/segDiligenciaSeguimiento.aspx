<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segDiligenciaSeguimiento.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segDiligenciaSeguimiento" %>
<%@ Register src="../../../../Include/WebUserControls/wucFixedDateTime.ascx" tagname="wucFixedDateTime" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucTimer.ascx" tagname="wucTimer" tagprefix="wuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	<script language="javascript" type="text/javascript">

		// Funciones del programador

		function WAFocus(ControlID) {
			var oControl = document.getElementById(ControlID);

			oControl.focus();
			if (oControl.type == 'text' || oControl.type == 'password') { oControl.select(); }
		}

    </script>
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
                    <asp:Label ID="Label1" runat="server" Text="En esta sección puede registrar diligencias o dar de alta nuevas diligencias relacionadas a un seguimiento."></asp:Label>
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
				<td class="Nombre">Tipo</td>
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
					<asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="Button_General" width="125px" onclick="btnNuevo_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Diligencias registradas para este expediente
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDiligencia" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="DiligenciaId,ModuloId,Fecha"
                        OnRowCommand="gvDiligencia_RowCommand" 
                        OnRowDataBound="gvDiligencia_RowDataBound" 
                        OnSorting="gvDiligencia_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
									<td style="width:70px;">Módulo</td>
                                    <td style="width:70px;">Fecha</td>
									<td style="width:150px;">Tipo de Diligencia</td>
                                    <td style="width:200px;">Funcionario que ejecuta</td>
                                    <td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="5">No se encontraron diligencias registradas en esta solicitud</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Módulo"						ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="70px"	DataField="ModuloNombre"								SortExpression="ModuloNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"						ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="Fecha"										SortExpression="Fecha"></asp:BoundField>
							<asp:BoundField HeaderText="Tipo de Diligencia"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="Tipo"										SortExpression="Tipo"></asp:BoundField>
							<asp:BoundField HeaderText="Funcionario que ejecuta"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="NombreVisitadorEjecuta"						SortExpression="NombreVisitadorEjecuta"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"					ItemStyle-HorizontalAlign="Left"							DataField="Detalle"					HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDetail" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Detalle" ImageUrl="~/Include/Image/Buttons/ConsultarCiudadano.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Borrar" ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SolicitudId" Visible="false" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
        </table>
        
		<!-- PopUp -->
		<asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock">
			<asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:10px;" Height="680px" Width="800px">
				<asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
					<table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
						<tr>
							<td style="width:10px"></td>
							<td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle"></asp:Label></td>
							<td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton></td>
							<td style="width:10px"></td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
					<div style="margin:0 auto; width:98%;">
						<table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
							<tr style="height:20px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Fecha de registro</td>
								<td style="width:5px;"></td>
								<td><wuc:wucFixedDateTime ID="wucFixedDateTime" runat="server" /></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Funcionario que ejecuta</td>
								<td></td>
								<td><asp:DropDownList ID="ddlFuncionario" runat="server" Width="216px" CssClass="DropDownList_General"></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Fecha de diligencia</td>
								<td></td>
								<td><wuc:wucCalendar ID="calFecha" runat="server" /></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Hora Inicio/Fin</td>
								<td style="width:5px;"></td>
								<td class="tdActionCeldaLeyendaItem">
									<wuc:wucTimer ID="tmrInicio" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<wuc:wucTimer ID="tmrFin" runat="server" />
								</td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Tipo de diligencia</td>
								<td></td>
								<td class="tdCeldaItem"><asp:DropDownList ID="ddlTipoDiligencia" runat="server" Width="216px" CssClass="DropDownList_General"></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Lugar de diligencia</td>
								<td></td>
								<td class="tdCeldaItem"><asp:DropDownList ID="ddlLugarDiligencia" runat="server" Width="216px" CssClass="DropDownList_General"></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Solicitada por</td>
								<td></td>
								<td class="tdCeldaItem"><asp:TextBox ID="txtSolicitadaPor" runat="server" CssClass="Textbox_General" Width="210px" MaxLength="1000"></asp:TextBox></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem"><td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Detalle</td></tr>
							<tr style="height:155px;">
								<td colspan="3">
									<CKEditor:CKEditorControl ID="ckeDetalle" BasePath="~/Include/Components/CKEditor/Core/" runat="server" Height="90px" MaxLength="8000"></CKEditor:CKEditorControl>
								</td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem"><td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Resultado</td></tr>
							<tr style="height:155px;">
								<td colspan="3">
									<CKEditor:CKEditorControl ID="ckeResultado" BasePath="~/Include/Components/CKEditor/Core/" runat="server" Height="90px" MaxLength="8000"></CKEditor:CKEditorControl>
								</td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr>
								<td colspan="3" style="text-align:right;">
									<asp:Button ID="btnAction" runat="server" Text="" CssClass="Button_General" width="125px" onclick="btnAction_Click" />
								</td>
							</tr>
							<tr>
								<td colspan="3">
									<asp:Label ID="lblActionMessage" runat="server" CssClass="ActionContentMessage"></asp:Label>
								</td>
							</tr>
						</table>
					</div>
				</asp:Panel>
			</asp:Panel>
			<ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"> </ajaxToolkit:DragPanelExtender>
		</asp:Panel>

	</div>

	<asp:HiddenField ID="hddRecomendacionId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddExpedienteId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSolicitudId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddDiligenciaId" runat="server" />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Fecha" />

</asp:Content>
