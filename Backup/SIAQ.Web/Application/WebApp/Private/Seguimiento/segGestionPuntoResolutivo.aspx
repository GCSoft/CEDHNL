<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segGestionPuntoResolutivo.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segGestionPuntoResolutivo" %>
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
                    <asp:Label ID="Label1" runat="server" Text="Agregue información al expediente de seguimiento."></asp:Label>
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
                    <asp:GridView ID="gvPuntosResolutivos" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="RecomendacionDetalleId,RowNumber"
						OnRowCommand="gvPuntosResolutivos_RowCommand"
						OnRowDataBound="gvPuntosResolutivos_RowDataBound"
                        OnSorting="gvPuntosResolutivos_Sorting">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
									<td style="width:25px;" ></td>
									<td style="width:50px;">No</td>
									<td style="width:150px;">Estatus</td>
									<td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="4">No se encontraron Puntos Resolutivos asociados a la Recomendacion/Acuerdo de No Responsabilidad</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="25px">
                                <HeaderTemplate>
                                    <asp:ImageButton ID="imgSwapAll" runat="server" CommandName="SwapGridHeader" CommandArgument="-1" ImageUrl="~/Include/Image/Buttons/Collapse_Header.png" OnClick="imgSwapAll_Click" onmouseover="tooltip.show('Contraer todos los elementos', 'Der');" onmouseout="tooltip.hide();" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgSwapGrid" CommandName="SwapGrid" CommandArgument="<%#Container.DataItemIndex%>" runat="server" ImageUrl="~/Include/Image/Buttons/Collapse.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:BoundField HeaderText="No"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="50px"	DataField="RowNumber"						SortExpression="RowNumber"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="150px"	DataField="EstatusPuntoResolutivoNombre"	SortExpression="EstatusPuntoResolutivoNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"	ItemStyle-HorizontalAlign="Left"							DataField="Detalle"		HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="EditButton" runat="server" CommandArgument='<%#Eval("RecomendacionDetalleId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="0px">
								<ItemTemplate>
									<asp:Panel ID="pnlGridDetail" runat="server">
										<tr>
											<td align="center" colspan="100%" style="border:1px solid #C1C1C1">
												<asp:GridView ID="gvGestionPuntoResolutivo" runat="server" AllowPaging="false" AllowSorting="false"  AutoGenerateColumns="False" Width="90%">
													<AlternatingRowStyle CssClass="Grid_Row_Alternating" />
													<HeaderStyle CssClass="Grid_Header_Action_Alternative" />
													<RowStyle CssClass="Grid_Row" />
													<EmptyDataTemplate>
														<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
															<tr class="Grid_Header_Action_Alternative">
																<td style="width:70px;">Fecha</td>
																<td style="width:200px;">Usuario</td>
																<td style="width:200px;">Estatus</td>
																<td>Gestión</td>
															</tr>
															<tr class="Grid_Row" style="text-align:center;">
																<td colspan="4">No se ha gestionado el punto resolutivo</td>
															</tr>
														</table>
													</EmptyDataTemplate>
													<Columns>
														<asp:BoundField HeaderText="Fecha"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="Fecha"										SortExpression="Fecha"></asp:BoundField>
														<asp:BoundField HeaderText="Usuario"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="UsuarioNombre"								SortExpression="UsuarioNombre"></asp:BoundField>
														<asp:BoundField HeaderText="Estatus"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="EstatusPuntoResolutivoNombre"				SortExpression="EstatusPuntoResolutivoNombre"></asp:BoundField>
														<asp:BoundField HeaderText="Gestión"	ItemStyle-HorizontalAlign="Left"							DataField="Gestion"					HtmlEncode="false"	SortExpression="Gestion"></asp:BoundField>
													</Columns>
												</asp:GridView>
												<br />
											</td>
										</tr>
									</asp:Panel>
								</ItemTemplate>
							</asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
        </table>

    </div>

	<!-- PopUp / Editar Estatus Punto Resolutivo -->
	<asp:Panel id="pnlEstatusPuntoResolutivo" runat="server" CssClass="ActionBlock">
		<asp:Panel id="pnlEstatusPuntoResolutivoContent" runat="server" CssClass="ActionContent" style="top:10px;" Height="400px" Width="700px">
			<asp:Panel ID="pnlEstatusPuntoResolutivoHeader" runat="server" CssClass="ActionHeader">
				<table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
					<tr>
						<td style="width:10px"></td>
						<td style="text-align:left;"><asp:Label ID="lblEstatusPuntoResolutivoTitle" runat="server" CssClass="ActionHeaderTitle" Text="Editar estatus de punto resolutivo"></asp:Label></td>
						<td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseEstatusPuntoResolutivoWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseEstatusPuntoResolutivoWindow_Click"></asp:ImageButton></td>
						<td style="width:10px"></td>
					</tr>
				</table>
			</asp:Panel>
			<asp:Panel ID="pnlEstatusPuntoResolutivoBody" runat="server" CssClass="ActionBody">
				<div style="margin:0 auto; width:98%;">
					<table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
						<tr style="height:20px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdActionCeldaLeyendaItem">&nbsp;Fecha</td>
							<td style="width:5px;"></td>
							<td><wuc:wucCalendar ID="calFechaEstatusPuntoResolutivo" runat="server" /></td>
						</tr>
						<tr style="height:5px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdActionCeldaLeyendaItem">&nbsp;Estatus</td>
							<td style="width:5px;"></td>
							<td><asp:DropDownList ID="ddlPopUpEstatusPuntoResolutivo" runat="server" Width="316px" CssClass="DropDownList_General"></asp:DropDownList></td>
						</tr>
						<tr style="height:5px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem"><td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Detalle</td></tr>
						<tr style="height:155px;">
							<td colspan="3">
								<CKEditor:CKEditorControl ID="ckeEstatusPuntoResolutivo" BasePath="~/Include/Components/CKEditor/Core/" runat="server" Height="90px"></CKEditor:CKEditorControl>
							</td>
						</tr>
						<tr style="height:5px;"><td colspan="3"></td></tr>
						<tr>
							<td colspan="3" style="text-align:right;">
								<asp:Button ID="btnPopUpEstatusPuntoResolutivo" runat="server" Text="Actualizar Estatus" CssClass="Button_General" width="180px" onclick="btnPopUpEstatusPuntoResolutivo_Click" />
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:Label ID="lblActionMessageEstatusPuntoResolutivo" runat="server" CssClass="ActionContentMessage"></asp:Label>
							</td>
						</tr>
					</table>
				</div>
			</asp:Panel>
		</asp:Panel>
		<ajaxToolkit:DragPanelExtender id="dragPanelEstatusPuntoResolutivo" runat="server" TargetControlID="pnlEstatusPuntoResolutivoContent" DragHandleID="pnlEstatusPuntoResolutivoHeader"> </ajaxToolkit:DragPanelExtender>
	</asp:Panel>

    <asp:HiddenField ID="hddRecomendacionId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddRecomendacionDetalleId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="RowNumber"  />

</asp:Content>
