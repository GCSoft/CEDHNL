<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="visRecomendacionExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.visRecomendacionExpediente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	<script type = "text/javascript">

		function RadioCheck(rb) {
			var gv = document.getElementById("<%=gvAutoridad.ClientID%>");
			var rbs = gv.getElementsByTagName("input");

			var row = rb.parentNode.parentNode;
			for (var i = 0; i < rbs.length; i++) {
				if (rbs[i].type == "radio") {
					if (rbs[i].checked && rbs[i] != rb) {
						rbs[i].checked = false;
						break;
					}
				}
			}
		}    

	</script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Recomendaciones al Expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Agregue las recomendaciones al expediente resuelto como recomendación."></asp:Label>
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
					<asp:Button ID="btnNuevaRecomendacion" runat="server" Text="Nueva" CssClass="Button_General" width="150px" onclick="btnNuevaRecomendacion_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="150px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Recomendaciones registradas para este Expediente
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvRecomendacion" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="RecomendacionId,NombreAutoridad"
                        OnRowCommand="gvRecomendacion_RowCommand" 
                        OnRowDataBound="gvRecomendacion_RowDataBound" 
                        OnSorting="gvRecomendacion_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:25px;" ></td>
                                    <td style="width:150px;">Nombre de Autoridad</td>
                                    <td style="width:150px;">Puesto</td>
                                    <td>Nivel 1 Autoridad</td>
                                    <td style="width:200px;">Nivel 2 Autoridad</td>
                                    <td style="width:200px;">Nivel 3 Autoridad</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">No se encontraron Recomendaciones asociadas al Expediente</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="25px">
                                <HeaderTemplate>
                                    <asp:ImageButton ID="imgSwapAll" runat="server" CommandName="SwapGridHeader" CommandArgument="-1" ImageUrl="~/Include/Image/Buttons/Expand_Header.png" OnClick="imgSwapAll_Click" onmouseover="tooltip.show('Expander todos los elementos', 'Der');" onmouseout="tooltip.hide();" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgSwapGrid" CommandName="SwapGrid" CommandArgument="<%#Container.DataItemIndex%>" runat="server" ImageUrl="~/Include/Image/Buttons/Expand.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Nombre de Autoridad"	ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="NombreAutoridad"	SortExpression="NombreAutoridad"></asp:BoundField>
                            <asp:BoundField HeaderText="Puesto"					ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="PuestoAutoridad"	SortExpression="PuestoAutoridad"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 1 Autoridad"		ItemStyle-HorizontalAlign="Left"							DataField="AutoridadNivel1"	SortExpression="AutoridadNivel1"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 2 Autoridad"		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="200px" DataField="AutoridadNivel2"	SortExpression="AutoridadNivel2"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 3 Autoridad"		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="200px" DataField="AutoridadNivel3"	SortExpression="AutoridadNivel3"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<%#Eval("RecomendacionId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%#Eval("RecomendacionId")%>' CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="0px">
								<ItemTemplate>
									<asp:Panel ID="pnlGridDetail" runat="server">
										<tr>
											<td align="center" colspan="100%" style="border:1px solid #C1C1C1">
                                                <asp:GridView id="gvRecomendacionDetalle" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" Width="90%"
                                                    DataKeyNames="RecomendacionDetalleId">
                                                    <alternatingrowstyle cssclass="Grid_Row_Alternating" />
                                                    <headerstyle cssclass="Grid_Header_Action_Alternative" />
                                                    <rowstyle cssclass="Grid_Row" />
                                                    <EmptyDataTemplate>
                                                        <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
															<tr class="Grid_Header_Action_Alternative">
																<td style="text-align:center; width:25px;"></td>
																<td style="text-align:center;">Detalle</td>
															</tr>
															<tr class="Grid_Row">
																<td colspan="2" style="text-align:center;">No se han agregado detalles de la recomendación</td>
															</tr>
														</table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:BoundField HeaderText=""								ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="25px"	DataField="RowNumber"></asp:BoundField>
														<asp:BoundField HeaderText="Detalle"	HtmlEncode="false"	ItemStyle-HorizontalAlign="Left"							DataField="Apartado"></asp:BoundField>
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

		<!-- PopUp -->
		<asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock" Visible="false" >
            <asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" Style="top:10px;" Height="700px" Width="900px">
                <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
                    <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
                        <tr>
                            <td style="width: 10px"></td>
                            <td style="text-align: left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle"></asp:Label></td>
                            <td style="vertical-align: middle; width: 14px;"><asp:ImageButton ID="imgActionCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgActionCloseWindow_Click"></asp:ImageButton></td>
                            <td style="width: 10px"></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
                    <div style="margin:0 auto; width:98%;">
                        <table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
                            <tr style="height:20px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem"><td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Autoridades señaladas como SI Responsables</td></tr>
                            <tr style="height:1px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td colspan="3">
									<div style="border:1px solid #4B4878; height:165px; overflow-x:hidden; overflow-y:scroll; text-align:left; Width:100%">
										<asp:GridView ID="gvAutoridad" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="99%"
											DataKeyNames="AutoridadId,ExpedienteId" 
											OnRowDataBound="gvAutoridad_RowDataBound"
											OnSorting="gvAutoridad_Sorting">
											<HeaderStyle CssClass="Grid_Header_Action" />
											<RowStyle CssClass="Grid_Row_Action" />
											<EmptyDataTemplate>
												<table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
													<tr class="Grid_Header_Action">
														<td style="width:25px;" ></td>
														<td style="width:100px;">Nombre de Autoridad</td>
														<td style="width:100px;">Puesto</td>
														<td>Nivel 1 Autoridad</td>
														<td style="width:200px;">Nivel 2 Autoridad</td>
														<td style="width:200px;">Nivel 3 Autoridad</td>
													</tr>
													<tr class="Grid_Row" style="text-align:center;">
														<td colspan="6">No se encontraron autoridades SI responsables asociadas al Expediente</td>
													</tr>
												</table>
											</EmptyDataTemplate>
											<Columns>
												<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
													<ItemTemplate>
														<asp:RadioButton ID="RowSelector" runat="server" onclick="RadioCheck(this);" />
													</ItemTemplate>
												</asp:TemplateField>
												<asp:BoundField HeaderText="Nombre de Autoridad"	ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="100px" DataField="NombreAutoridad"	SortExpression="NombreAutoridad"></asp:BoundField>
												<asp:BoundField HeaderText="Puesto"					ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="100px" DataField="PuestoAutoridad"	SortExpression="PuestoAutoridad"></asp:BoundField>
												<asp:BoundField HeaderText="Nivel 1 Autoridad"		ItemStyle-HorizontalAlign="Left"							DataField="AutoridadNivel1"	SortExpression="AutoridadNivel1"></asp:BoundField>
												<asp:BoundField HeaderText="Nivel 2 Autoridad"		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="200px" DataField="AutoridadNivel2"	SortExpression="AutoridadNivel2"></asp:BoundField>
												<asp:BoundField HeaderText="Nivel 3 Autoridad"		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="200px" DataField="AutoridadNivel3"	SortExpression="AutoridadNivel3"></asp:BoundField>
											</Columns>
										</asp:GridView>
									</div>
								</td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem"><td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Punto resolutivo</td></tr>
                            <tr class="trFilaItem">
								<td colspan="3">
									<CKEditor:CKEditorControl ID="ckeApartado" BasePath="~/Include/Components/CKEditor/Core/" runat="server" Height="90px" MaxLength="8000"></CKEditor:CKEditorControl>
								</td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr>
                                <td colspan="3" style="text-align:left;">
                                    <asp:Button ID="btnAgregarApartado" runat="server" Text="Agregar" CssClass="Button_General" Width="150px" OnClick="btnAgregarApartado_Click" />
                                </td>
                            </tr>
							<tr style="height:10px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
                                <td colspan="3">
									<div style="border:1px solid #4B4878; height:165px; overflow-x:hidden; overflow-y:scroll; text-align:left; Width:100%">
										<asp:GridView ID="gvAutoridadDetalle" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" Width="99%"
											DataKeyNames="RowNumber" 
											OnRowCommand="gvAutoridadDetalle_RowCommand"
											OnRowDataBound="gvAutoridadDetalle_RowDataBound">
											<HeaderStyle CssClass="Grid_Header_Action" />
											<RowStyle CssClass="Grid_Row_Action" />
											<EmptyDataTemplate>
												<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
													<tr class="Grid_Header_Action">
														<td style="width:25px;"></td>
														<td style="text-align:center;">Apartado</td>
													</tr>
													<tr class="Grid_Row">
														<td colspan="2" style="text-align:center;">No se han incluído puntos resolutivos en la Recomendación</td>
													</tr>
												</table>
											</EmptyDataTemplate>
											<Columns>
												<asp:BoundField						ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="25px"	DataField="RowNumber"						SortExpression="RowNumber"></asp:BoundField>
												<asp:BoundField HeaderText="Nombre"	ItemStyle-HorizontalAlign="Left"							DataField="Apartado"	HtmlEncode="false"	SortExpression="Apartado"></asp:BoundField>
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
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr>
                                <td colspan="3" style="text-align:right;">
                                    <asp:Button ID="btnAction" runat="server" Text="" CssClass="Button_General" Width="150px" OnClick="btnAction_Click" />
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
	<asp:HiddenField ID="hddExpedienteId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddRecomendacionId" runat="server" Value="0" />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="TipoRecomendacionNombre" />

</asp:Content>
