<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="visComparecencia.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.visComparecencia" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucTimer.ascx" tagname="wucTimer" tagprefix="wuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	<script language="javascript" type="text/javascript">

		// Funciones del programador

		function ClientItemSelected(sender, e) {
			$get("<%=hddServidorPublicoId.ClientID %>").value = e.get_value();
		}

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
                    Comparecencias
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="En esta sección se pueden registrar las comparecencias del expediente. "></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="InformacionDiv">
		
		<table class="SolicitudTable">
			<!-- Carátula -->
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
				<td class="Nombre">Cierre de Orientacion</td>
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
			<!-- Fin Carátula -->
        </table>
		<br />

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
                    Comparecencias registradas para esta solicitud
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvComparecencia" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="ExpedienteComparecenciaId,ModuloId,FechaComparecenciaCorta"
                        OnRowCommand="gvComparecencia_RowCommand" 
                        OnRowDataBound="gvComparecencia_RowDataBound" 
                        OnSorting="gvComparecencia_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
									<td style="width:70px;">Fecha</td>
									<td style="width:150px;">Tipo de Comparecencia</td>
									<td style="width:150px;">Lugar de Comparecencia</td>
                                    <td style="width:200px;">Funcionario que ejecuta</td>
                                    <td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="5">No se encontraron Comparecencias registradas en este expediente</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Fecha"						ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="FechaComparecenciaCorta"							SortExpression="FechaComparecenciaCorta"></asp:BoundField>
							<asp:BoundField HeaderText="Tipo de Comparecencia"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="TipoComparecenciaNombre"							SortExpression="TipoComparecenciaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Lugar de Comparecencia"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="70px"	DataField="LugarComparecenciaNombre"						SortExpression="LugarComparecenciaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Funcionario que ejecuta"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="FuncionarioEjecutaNombre"						SortExpression="FuncionarioEjecutaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"					ItemStyle-HorizontalAlign="Left"							DataField="DetalleCorto"				HtmlEncode="false"	SortExpression="DetalleCorto"></asp:BoundField>
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
		<asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock" >
			<asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:10px;" Height="730px" Width="800px">
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
								<td class="tdActionCeldaLeyendaItem">&nbsp;Funcionario que ejecuta</td>
								<td style="width:5px;"></td>
								<td><asp:DropDownList ID="ddlFuncionario" runat="server" Width="216px" CssClass="DropDownList_General"></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Fecha</td>
								<td style="width:5px;"></td>
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
								<td class="tdActionCeldaLeyendaItem">&nbsp;Tipo de comparecencia</td>
								<td style="width:5px;"></td>
								<td><asp:DropDownList ID="ddlTipoComparecencia" runat="server" Width="216px" CssClass="DropDownList_General"></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Lugar de comparecencia</td>
								<td style="width:5px;"></td>
								<td><asp:DropDownList ID="ddlLugarComparecencia" runat="server" Width="216px" CssClass="DropDownList_General"></asp:DropDownList></td>
							</tr>
							<tr style="height:10px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Ciudadanos a comparecer</td>
								<td style="width:5px;"></td>
								<td></td>
							</tr>
							<tr>
								<td colspan="3">
									<div style="border:1px solid #4B4878; height:90px; overflow-x:hidden; overflow-y:scroll; text-align:left; Width:100%">
										<asp:GridView ID="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="99%"
											DataKeyNames="CiudadanoId" 
											OnRowDataBound="gvCiudadano_RowDataBound"
											OnSorting="gvCiudadano_Sorting">
											<HeaderStyle CssClass="Grid_Header_Action" />
											<RowStyle CssClass="Grid_Row_Action" />
											<EmptyDataTemplate>
												<table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
													<tr class="Grid_Header_Action">
														<td>Nombre</td>
														<td style="width:100px;">Tipo</td>
														<td style="width:90px;">Edad</td>
														<td style="width:80px;">Sexo</td>
													</tr>
													<tr class="Grid_Row">
														<td colspan="4">No se encontraron Ciudadanos asociados al Expediente</td>
													</tr>
												</table>
											</EmptyDataTemplate>
											<Columns>
												<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
													<ItemTemplate>
														<asp:CheckBox ID="chkCiudadano" runat="server" EnableViewState="true" />
													</ItemTemplate>
												</asp:TemplateField>
												<asp:BoundField HeaderText="Nombre"	ItemStyle-HorizontalAlign="Left"							DataField="NombreCompleto"		SortExpression="NombreCompleto"></asp:BoundField>
												<asp:BoundField HeaderText="Tipo"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	DataField="NombreTipoCiudadano"	SortExpression="NombreTipoCiudadano"></asp:BoundField>
												<asp:BoundField HeaderText="Edad"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="90px"	DataField="Edad"				SortExpression="Edad"></asp:BoundField>
												<asp:BoundField HeaderText="Sexo"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="NombreSexo"			SortExpression="NombreSexo"></asp:BoundField>
											</Columns>
										</asp:GridView>
									</div>
								</td>
							</tr>
							<tr style="height:10px;"><td colspan="3"></td></tr>
							<tr>
								<td colspan="3">
									<table border="0" cellpadding="0" cellspacing="0">
										<tr class="trFilaItem">
											<td class="tdActionCeldaLeyendaItem">&nbsp;Servidor público</td>
											<td style="width:5px;"></td>
											<td style="width:405px;">
												<asp:TextBox ID="txtServidorPublico" runat="server" CssClass="Textbox_General" MaxLength="1000" Width="400px"></asp:TextBox>
											</td>
											<td style="text-align:left;">
												<asp:Button ID="btnAgregarFuncionario" runat="server" Text="Agregar" CssClass="Button_General" width="70px" onclick="btnAgregarFuncionario_Click" />
											</td>
										</tr>
										<tr>
											<td colspan="4">
												<asp:HiddenField ID="hddServidorPublicoId" runat="server" />
												<ajaxToolkit:AutoCompleteExtender
													ID="autoCompleteExtender" 
													runat="server"
													TargetControlID="txtServidorPublico"
													ServiceMethod="GetServiceList"
													CompletionInterval="100"
													CompletionSetCount="10"
													EnableCaching="false"
													FirstRowSelected="false"
													MinimumPrefixLength="2"
													OnClientItemSelected="ClientItemSelected"
													CompletionListCssClass="Autocomplete_CompletionListElement"
													CompletionListItemCssClass="Autocomplete_ListItem"
													CompletionListHighlightedItemCssClass="Autocomplete_HighLightedListItem">
												</ajaxToolkit:AutoCompleteExtender>
											</td>
										</tr>
										<tr>
											<td colspan="4" style="text-align:left;">
												<asp:Button ID="btnNuevoFuncionario" runat="server" Text="Nuevo Servidor Público" CssClass="Button_General" width="150px" onclick="btnNuevoFuncionario_Click" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr style="height:1px;"><td colspan="3"></td></tr>
							<tr>
								<td colspan="3">
									<div style="border:1px solid #4B4878; height:90px; overflow-x:hidden; overflow-y:scroll; text-align:left; Width:100%">
										<asp:GridView ID="gvServidorPublico" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="99%"
											DataKeyNames="ServidorPublicoId,NombreCompleto" 
											OnRowCommand="gvServidorPublico_RowCommand"
											OnRowDataBound="gvServidorPublico_RowDataBound"
											OnSorting="gvServidorPublico_Sorting">
											<HeaderStyle CssClass="Grid_Header_Action" />
											<RowStyle CssClass="Grid_Row_Action" />
											<EmptyDataTemplate>
												<table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
													<tr class="Grid_Header_Action">
														<td style="width:300px;">Autoridad</td>
														<td>Nombre</td>
													</tr>
													<tr class="Grid_Row">
														<td colspan="2" style="text-align:center;">No se han incluído Servidores Públicos en la Comparecencia</td>
													</tr>
												</table>
											</EmptyDataTemplate>
											<Columns>
												<asp:BoundField HeaderText="Autoridad"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="300px"	DataField="AutoridadAgrupada"	HtmlEncode="false"	SortExpression="AutoridadAgrupada"></asp:BoundField>
												<asp:BoundField HeaderText="Nombre"		ItemStyle-HorizontalAlign="Left"							DataField="NombreCompleto"							SortExpression="NombreCompleto"></asp:BoundField>
												<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="5%">
													<ItemTemplate>
														<asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="5%">
													<ItemTemplate>
														<asp:ImageButton ID="imgDelete" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
													</ItemTemplate>
												</asp:TemplateField>
											</Columns>
										</asp:GridView>
									</div>
								</td>
							</tr>
							<tr style="height:10px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Detalle</td>
								<td style="width:5px;"></td>
								<td></td>
							</tr>
							<tr>
								<td colspan="3">
									<CKEditor:CKEditorControl ID="ckeDetalle" BasePath="~/Include/Components/CKEditor/Core/" runat="server" Height="90px" MaxLength="8000"></CKEditor:CKEditorControl>
								</td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr>
								<td colspan="3" style="text-align:right;">
									<asp:Button ID="btnAction" runat="server" Text="" CssClass="Button_General" width="150px" onclick="btnAction_Click" />
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

	<asp:HiddenField ID="hddAreaId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddComparecenciaId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddExpedienteId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Fecha" />

</asp:Content>
