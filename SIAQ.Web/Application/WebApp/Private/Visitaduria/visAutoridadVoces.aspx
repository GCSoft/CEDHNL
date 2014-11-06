<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="visAutoridadVoces.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.visAutoridadVoces" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Confirmar Autoridades y Voces Señaladas en el Expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Confirme las Autoridades y Voces señaladas asociadas al Expediente."></asp:Label>
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
                <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnAgregarAutoridad" runat="server" Text="Agregar autoridad" CssClass="Button_General" width="125px" onclick="btnAgregarAutoridad_Click" /></td>
                <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" /></td>
				<td style="height:24px;">&nbsp;</td>
            </tr>
        </table>

		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Autoridades y Voces registradas en el Expediente
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView id="gvAutoridades" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="AutoridadId,ModuloId,Nombre"
                        OnRowCommand="gvAutoridades_RowCommand"
                        OnRowDataBound="gvAutoridades_RowDataBound"
                        OnSorting="gvAutoridades_Sorting">
                        <alternatingrowstyle cssclass="Grid_Row_Alternating" />
                        <headerstyle cssclass="Grid_Header" />
                        <rowstyle cssclass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:25px;" ></td>
									<td style="width:140px;">Calificación</td>
                                    <td style="width:140px;">Nombre de Autoridad</td>
                                    <td style="width:140px;">Puesto</td>
                                    <td style="width:140px;">Nivel 1 Autoridad</td>
                                    <td style="width:140px;">Nivel 2 Autoridad</td>
                                    <td style="width:140px;">Nivel 3 Autoridad</td>
                                    <td>Comentarios</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="8">No se encontraron Autoridades asociadas al Expediente</td>
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
							<asp:BoundField HeaderText="Calificación"			ItemStyle-ForeColor="#FF6600"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="140px" DataField="CalificacionAutoridadNombre"	SortExpression="CalificacionAutoridadNombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Nombre de Autoridad"									ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nombre"						SortExpression="Nombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Puesto"													ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Puesto"						SortExpression="Puesto"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 1 Autoridad"										ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel1"						SortExpression="Nivel1"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 2 Autoridad"										ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel2"						SortExpression="Nivel2"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 3 Autoridad"										ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel3"						SortExpression="Nivel3"></asp:BoundField>
                            <asp:BoundField HeaderText="Comentarios"											ItemStyle-HorizontalAlign="Left"                            DataField="Comentarios"					SortExpression="Comentarios"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="EditButton" runat="server" CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="SelectButton" runat="server" CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Seleccionar" ImageUrl="~/Include/Image/Buttons/AgregarVisita.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="DeleteButton" runat="server" CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Borrar" ImageUrl="~/Include/Image/Buttons/Delete.png" OnClientClick="return confirm('¿Seguro que desea eliminar esta autoridad junto con sus voces?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="0px">
								<ItemTemplate>
									<asp:Panel ID="pnlGridDetail" runat="server">
										<tr>
											<td align="center" colspan="100%" style="border:1px solid #C1C1C1">
                                                <asp:GridView id="gvVocesDetalle" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" Width="90%"
                                                    DataKeyNames="VozId">
                                                    <alternatingrowstyle cssclass="Grid_Row_Alternating" />
                                                    <headerstyle cssclass="Grid_Header_Action_Alternative" />
                                                    <rowstyle cssclass="Grid_Row" />
                                                    <EmptyDataTemplate>
                                                       <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
															<tr class="Grid_Header_Action_Alternative">
																<td style="text-align:center; width:180px;">Hecho Violatorio 1</td>
																<td style="text-align:center; width:180px;">Hecho Violatorio 2</td>
																<td style="text-align:center; width:180px;">Hecho Violatorio 3</td>
																<td style="text-align:center;">Comentarios</td>
																<td style="text-align:center; width:100px;">Calificación</td>
															</tr>
															<tr class="Grid_Row">
																<td colspan="5" style="text-align:center;">No se han agregado voces a la autoridad</td>
															</tr>
														</table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Hecho Violatorio 1" 							ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="180px"	DataField="Voz1"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Hecho Violatorio 2" 							ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="180px"	DataField="Voz2"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Hecho Violatorio 3"								ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="180px"	DataField="Voz3"></asp:BoundField>
														<asp:BoundField HeaderText="Comentarios"									ItemStyle-HorizontalAlign="Left"							DataField="Comentarios"></asp:BoundField>
														<asp:BoundField HeaderText="Calificación"	ItemStyle-ForeColor="#FF6600"	ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="180px"	DataField="CalificacionAutoridadNombre"></asp:BoundField>
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
            <asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" Style="top:10px;" Height="390px" Width="450px">
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
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem" style="width:80px;">&nbsp;Primer nivel</td>
                                <td style="width:5px;"></td>
                                <td><asp:DropDownList ID="ddlAutoridadNivel1" runat="server" CssClass="DropDownList_General" Width="316px" AutoPostBack="True" OnSelectedIndexChanged="ddlAutoridadNivel1_SelectedIndexChanged"></asp:DropDownList></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Segundo nivel</td>
                                <td></td>
                                <td><asp:DropDownList ID="ddlAutoridadNivel2" runat="server" CssClass="DropDownList_General"  Width="316px" AutoPostBack="True" OnSelectedIndexChanged="ddlAutoridadNivel2_SelectedIndexChanged"></asp:DropDownList></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Tercer nivel</td>
                                <td></td>
                                <td><asp:DropDownList ID="ddlAutoridadNivel3" runat="server" CssClass="DropDownList_General" Width="316px"></asp:DropDownList></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Calificación</td>
                                <td></td>
                                <td><asp:DropDownList ID="ddlCalificacionAutoridad" runat="server" CssClass="DropDownList_General" Width="316px"></asp:DropDownList></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Nombre funcionario público a cargo</td>
                            </tr>
                            <tr style="height:1px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td></td>
                                <td></td>
                                <td class="tdCeldaItem"><asp:TextBox ID="tbActionNombreFuncionario" runat="server" CssClass="Textbox_General" Width="310px" MaxLength="50"></asp:TextBox></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Puesto actual</td>
                                <td></td>
                                <td class="tdCeldaItem"><asp:TextBox ID="tbActionPuestoActual" runat="server" CssClass="Textbox_General" Width="310px" MaxLength="50"></asp:TextBox></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem" style="vertical-align:top">&nbsp;Comentarios</td>
                                <td></td>
                                <td class="tdCeldaItem"><asp:TextBox ID="tbActionComentarios" runat="server" CssClass="Textarea_General" Width="310px" Height="70px" MaxLength="400" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr>
                                <td colspan="3" style="text-align:right;">
                                    <asp:Button ID="btnActionAutoridad" runat="server" Text="Agregar" CssClass="Button_General" Width="125px" OnClick="btnActionAutoridad_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnActionCancelar" runat="server" Text="Cancelar" CssClass="Button_General" Width="125px" OnClick="btnActionCancelar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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

		<!-- PopUp Voces -->
		<asp:Panel id="pnlVoces" runat="server" CssClass="ActionBlock" Visible="false" >
            <asp:Panel ID="pnlVocesContent" runat="server" CssClass="ActionContent" Style="top:10px;" Height="630px" Width="1000px">
                <asp:Panel ID="pnlVocesHeader" runat="server" CssClass="ActionHeader">
                    <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
                        <tr>
                            <td style="width: 10px"></td>
                            <td style="text-align: left;"><asp:Label ID="lblVocesTitle" runat="server" CssClass="ActionHeaderTitle" Text="Agregar voces a autoridad"></asp:Label></td>
                            <td style="vertical-align: middle; width: 14px;"><asp:ImageButton ID="imgVocesCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgVocesCloseWindow_Click"></asp:ImageButton></td>
                            <td style="width: 10px"></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlVocesBody" runat="server" CssClass="ActionBody">
                    <div style="margin:0 auto; width:98%;">
                        <table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
                            <tr style="height:20px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Nombre de Autoridad</td>
                                <td style="width:5px;"></td>
                                <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesNombre" runat="server"></asp:Label></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Puesto</td>
                                <td style="width:5px;"></td>
                                <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesPuesto" runat="server"></asp:Label></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Autoridad N1</td>
                                <td style="width:5px;"></td>
                                <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesNivel1" runat="server"></asp:Label></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Autoridad N2</td>
                                <td style="width:5px;"></td>
                                <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesNivel2" runat="server"></asp:Label></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Autoridad N3</td>
                                <td style="width:5px;"></td>
                                <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesNivel3" runat="server"></asp:Label></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Observaciones</td>
                                <td style="width:5px;"></td>
                                <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesObservaciones" runat="server"></asp:Label></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
                                <td class="tdActionCeldaLeyendaItem">&nbsp;Hechos violatorios</td>
                                <td style="width:5px;"></td>
                                <td></td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr>
                                <td colspan="3">
									<table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <div id="tblHeader_Voces" style="border:0px solid #000000; clear:both; position:relative; width:100%;">
                                                    <table cellspacing="0" rules="all" border="1" style="border-collapse:collapse; width:100%;">
                                                        <tr class="Grid_Header_Action">
                                                            <th scope="col" style="width:154px;">Primer nivel</th>
                                                            <th scope="col" style="width:154px;">Segundo nivel</th>
                                                            <th scope="col" style="width:154px;">Tercer nivel</th>
															<th scope="col" style="width:250px;">Comentarios</th>
															<th scope="col" style="width:168px;">Calificación</th>
                                                            <th scope="col"></th>
                                                        </tr>
                                                        <tr class="Grid_Header_Action">
                                                            <th scope="col" style="vertical-align:top;"><asp:DropDownList id="ddlVocesTemporal_Nivel1"	runat="server" AutoPostBack="True"  CssClass="DropDownList_General" Width="148px" OnSelectedIndexChanged="ddlVocesNivel1_SelectedIndexChanged"></asp:DropDownList></th>
                                                            <th scope="col" style="vertical-align:top;"><asp:DropDownList id="ddlVocesTemporal_Nivel2"	runat="server" AutoPostBack="True"  CssClass="DropDownList_General" Width="148px" OnSelectedIndexChanged="ddlVocesNivel2_SelectedIndexChanged"></asp:DropDownList></th>
                                                            <th scope="col" style="vertical-align:top;"><asp:DropDownList id="ddlVocesTemporal_Nivel3"	runat="server"                      CssClass="DropDownList_General" Width="148px"></asp:DropDownList></th>
															<th scope="col" style="vertical-align:top;"><asp:TextBox id="txtVocesTemporal_Comentarios"	runat="server"                      CssClass="Textarea_General"		Width="240px" Height="40px" TextMode="MultiLine" MaxLength="400"></asp:TextBox></th>
															<th scope="col" style="vertical-align:top;"><asp:DropDownList id="ddlCalificacionVoces"		runat="server"                      CssClass="DropDownList_General" Width="160px"></asp:DropDownList></th>
                                                            <th scope="col" style="vertical-align:top;"><asp:Button ID="btnVocesTemporal_Nuevo"			runat="server"                      CssClass="Button_General"  Text="Agregar" width="70px" onclick="btnVocesTemporal_Nuevo_Click" /></th>
                                                        </tr>
                                                    </table>
                                                </div>
												<div style="border:1px solid #4B4878; height:250px; overflow-x:hidden; overflow-y:scroll; text-align:left; Width:100%">
													<asp:GridView id="gvAutoridadVoces" runat="server" border="0" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" ShowHeader="false" Width="99%"
														DataKeyNames="VozId,CalificacionAutoridadId,ModuloId,Comentarios"
														OnRowCommand="gvAutoridadVoces_RowCommand"
														OnRowDataBound="gvAutoridadVoces_RowDataBound">
														<HeaderStyle CssClass="Grid_Header_Action" />
														<RowStyle CssClass="Grid_Row_Action" />
														<EmptyDataTemplate>
															<div class="Grid_Row" style="border:0px; clear:both; left:-1px; position:relative; text-align:center; top:-2px; width:100%;">
                                                                No se encontraron Voces asociadas a la Autoridad
                                                            </div>
														</EmptyDataTemplate>
														<Columns>
															<asp:BoundField	HeaderText="Primer nivel"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="153px"	DataField="Voz1"></asp:BoundField>
															<asp:BoundField	HeaderText="Segundo nivel"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="154px"	DataField="Voz2"></asp:BoundField>
															<asp:BoundField	HeaderText="Tercer nivel"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="154px"	DataField="Voz3"></asp:BoundField>
															<asp:TemplateField HeaderText="Comentarios" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px">
																<ItemTemplate>
																	<asp:TextBox id="txtComentarioVoz" runat="server" CssClass="Textarea_General" MaxLength="400" TextMode="MultiLine" Width="240px" Height="40px"></asp:TextBox>
																</ItemTemplate>
															</asp:TemplateField>
															<asp:TemplateField HeaderText="Calificación" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="168px">
																<ItemTemplate>
																	<asp:DropDownList id="ddlCalificacionVoz" runat="server" CssClass="DropDownList_General" Width="160px"></asp:DropDownList>
																</ItemTemplate>
															</asp:TemplateField>
															<asp:TemplateField	ItemStyle-HorizontalAlign ="Center">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgEliminar" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" ToolTip="Eliminar Voz" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
														</Columns>
													</asp:GridView>
												</div>
											</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
                            <tr>
                                <td colspan="3" style="text-align:right;">
									<asp:Button ID="btnAutoridadVoces_Editar" runat="server" CssClass="Button_General" Text="Actualizar Voces" width="125px" OnClick="btnAutoridadVoces_Editar_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnAutoridadVoces_Cancelar" runat="server" Text="Cancelar" CssClass="Button_General" Width="125px" OnClick="btnAutoridadVoces_Cancelar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblAutoridadVoces_Message" runat="server" CssClass="ActionContentMessage"></asp:Label>
                                </td>
                            </tr>
						</table>
                    </div>
                </asp:Panel>
            </asp:Panel>
            <ajaxToolkit:DragPanelExtender id="dragPanelVoces" runat="server" TargetControlID="pnlVocesContent" DragHandleID="pnlVocesHeader"> </ajaxToolkit:DragPanelExtender>
        </asp:Panel>

	</div>

	<asp:HiddenField ID="hddAutoridadId" runat="server" />
	<asp:HiddenField ID="hddExpedienteId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Nombre" />

</asp:Content>
