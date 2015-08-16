<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="QueDetalleSolicitudCierre.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Quejas.QueDetalleSolicitudCierre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Detalle de Solictud
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label2" runat="server" Text="Valide las solicitud y determine si se cerrará o se rechazará."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="SubMenuDiv">
		<asp:Panel CssClass="IconoPanel" ID="AprobarCalificacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AprobarCalificacionButton" ImageUrl="~/Include/Image/Icon/ConfirmacionCierreIcon.png" runat="server" OnClick="AprobarCalificacionButton_Click" ></asp:ImageButton><br />
            Aprobar calificación
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="RechazarCalificacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="RechazarCalificacionButton" ImageUrl="~/Include/Image/Icon/RechazarCierreIcon.png" runat="server" OnClick="RechazarCalificacionButton_Click" OnClientClick="return confirm('¿Seguro que desea rechazar la solicitud?');"></asp:ImageButton><br />
            Rechazar calificación
        </asp:Panel>
    </div>

	<div id="InformacionDiv">
		
		<!-- Calificación -->
        <table class="SolicitudTable">
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
                <td class="Nombre">Estatus</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="EstatusaLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de recepción</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Funcionario</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FuncionarioLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de asignación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Forma de contacto</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="ContactoLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de inicio gestión</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaGestionLabel" runat="server" Text=""></asp:Label></td>
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
			<tr style="height:10px;"><td colspan="7"></td></tr>
        </table>

		<!-- Ciudadanos -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Ciudadanos
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="CiudadanoId,NombreCompleto" 
						OnRowDataBound="gvCiudadano_RowDataBound"
                        OnSorting="gvCiudadano_Sorting">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
									<td style="width:100px;">Tipo</td>
									<td style="width:250px;">Nombre</td>
									<td style="width:90px;">Edad</td>
									<td style="width:80px;">Sexo</td>
                                    <td style="width:100px;">Telefono</td>
									<td>Domicilio</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">No se encontraron Ciudadanos asociados a la Solicitud</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Tipo"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	DataField="NombreTipoCiudadano"		SortExpression="NombreTipoCiudadano"></asp:BoundField>
							<asp:BoundField HeaderText="Nombre"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="NombreCompleto"			SortExpression="NombreCompleto"></asp:BoundField>
							<asp:BoundField HeaderText="Edad"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="90px"	DataField="Edad"					SortExpression="Edad"></asp:BoundField>
							<asp:BoundField HeaderText="Sexo"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="NombreSexo"				SortExpression="NombreSexo"></asp:BoundField>
							<asp:BoundField HeaderText="Telefono"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	DataField="TelefonoPrincipal"		SortExpression="TelefonoPrincipal"></asp:BoundField>
							<asp:BoundField HeaderText="Domicilio"	ItemStyle-HorizontalAlign="Left"							DataField="Domicilio"				SortExpression="Domicilio"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
        </table>
        <br />

		<!-- Documentos -->
        <div style="text-align: left;">Documentos anexos</div>
        <div class="DocumentoListDiv">
            <asp:DataList ID="dlstDocumentoList" runat="server" CellPadding="5" CellSpacing="5" HorizontalAlign="Left" RepeatDirection="Horizontal" RepeatLayout="Table" OnItemDataBound="dlstDocumentoList_ItemDataBound" >
                <ItemTemplate>
                    <div class="Item">
                        <asp:Image ID="DocumentoImage" runat="server" />
                        <br />
                        <asp:Label CssClass="Texto" ID="DocumentoLabel" runat="server" Text="Nombre del documento"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:Label CssClass="Texto" ID="SinDocumentoLabel" runat="server" Text=""></asp:Label>
        </div>

		<!-- Comentarios -->
		<div class="SolicitudComentarioDiv">
            <div style="text-align: left;">
                Asuntos
            </div>
            <div class="TituloDiv"><asp:Label ID="ComentarioTituloLabel" runat="server" Text=""></asp:Label></div>
            <asp:Repeater ID="repComentarios" runat="server">
                <HeaderTemplate>
                    <table border="1" class="ComentarioSolicitudTable">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="Numero">
							<%# DataBinder.Eval(Container.DataItem, "iRow") %>
						</td>
                        <td>
							<table class="ComentarioSolicitudTable">
								<tr>
									<td class="Nombre">
										<%# DataBinder.Eval(Container.DataItem, "UsuarioNombre")%>
									</td>
                                    <td class="Fecha">
										<%# DataBinder.Eval(Container.DataItem, "Fecha")%>
									</td>
                                </tr>
                                <tr>
                                    <td class="Texto" colspan="2">
										<%# DataBinder.Eval(Container.DataItem, "Comentario")%>
									</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label CssClass="Texto" ID="SinComentariosLabel" runat="server" Text=""></asp:Label>
        </div>

		<!-- Autoridad y voces señaladas -->
		<asp:Panel ID="pnlAutoridades" runat="server" Width="100%">
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr><td class="tdCeldaMiddleSpace"></td></tr>
				<tr>
					<td style="text-align: left;">
						Autoridad y voces señaladas
					</td>
				</tr>
				<tr>
					<td>
						<asp:GridView id="gvAutoridades" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
							DataKeyNames="AutoridadId,Nombre"
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
										<td style="width:140px;">Nombre</td>
										<td style="width:140px;">Puesto</td>
										<td style="width:140px;">Autoridad N1</td>
										<td style="width:140px;">Autoridad N2</td>
										<td style="width:140px;">Autoridad N3</td>
										<td>Comentarios</td>
										<td style="width:25px;" ></td>
									</tr>
									<tr class="Grid_Row">
										<td colspan="8">No se encontraron Autoridades añadidas a la solicitud</td>
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
								<asp:BoundField HeaderText="Nombre de Autoridad"    ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nombre"      SortExpression="Nombre"></asp:BoundField>
								<asp:BoundField HeaderText="Puesto"                 ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Puesto"      SortExpression="Puesto"></asp:BoundField>
								<asp:BoundField HeaderText="Nivel 1 Autoridad"      ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel1"      SortExpression="Nivel1"></asp:BoundField>
								<asp:BoundField HeaderText="Nivel 2 Autoridad"      ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel2"      SortExpression="Nivel2"></asp:BoundField>
								<asp:BoundField HeaderText="Nivel 3 Autoridad"      ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel3"      SortExpression="Nivel3"></asp:BoundField>
								<asp:BoundField HeaderText="Comentarios"            ItemStyle-HorizontalAlign="Left"                            DataField="Comentarios" SortExpression="Comentarios"></asp:BoundField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="25px">
									<ItemTemplate>
										<asp:Panel ID="pnlGridDetail" runat="server">
											<tr>
												<td align="center" colspan="100%" style="border:1px solid #C1C1C1">
													<asp:GridView id="gvVocesDetalle" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" Width="800px"
														DataKeyNames="VozId">
														<alternatingrowstyle cssclass="Grid_Row_Alternating" />
														<headerstyle cssclass="Grid_Header_Action_Alternative" />
														<rowstyle cssclass="Grid_Row" />
														<EmptyDataTemplate>
															<table border="1px" cellpadding="0px" cellspacing="0px">
																<tr class="Grid_Header_Action_Alternative">
																	<td style="text-align:center; width:180px;">Voz1</td>
																	<td style="text-align:center; width:180px;">Voz2</td>
																	<td style="text-align:center; width:180px;">Voz3</td>
																	<td style="text-align:center; width:260px;">Comentarios</td>
																</tr>
																<tr class="Grid_Row">
																	<td colspan="4" style="text-align:center;">No se han agregado voces a la autoridad</td>
																</tr>
															</table>
														</EmptyDataTemplate>
														<Columns>
															<asp:BoundField HeaderText="Voz1" 			ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="180px"	DataField="Voz1"></asp:BoundField>
															<asp:BoundField HeaderText="Voz2" 			ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="180px"	DataField="Voz2"></asp:BoundField>
															<asp:BoundField HeaderText="Voz3"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="180px"	DataField="Voz3"></asp:BoundField>
															<asp:BoundField HeaderText="Comentarios"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="260px"	DataField="Comentarios"></asp:BoundField>
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
			<br />
		</asp:Panel>

		<!-- Diligencias -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Diligencias
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDiligencia" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="DiligenciaId"
                        OnRowDataBound="gvDiligencia_RowDataBound" 
                        OnSorting="gvDiligencia_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" Width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:150px;">Fecha</td>
                                    <td style="width:250px;">Funcionario que ejecuta</td>
                                    <td style="width:120px;">Tipo</td>
									<td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="4">No se encontraron diligencias registradas en esta solicitud</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Fecha"						ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="150px"	DataField="Fecha"										SortExpression="Fecha"></asp:BoundField>
                            <asp:BoundField HeaderText="Funcionario que ejecuta"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="NombreVisitadorEjecuta"						SortExpression="NombreVisitadorEjecuta"></asp:BoundField>
							<asp:BoundField HeaderText="Tipo"						ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="Tipo"										SortExpression="Tipo"></asp:BoundField>
                            <asp:BoundField HeaderText="Detalle"					ItemStyle-HorizontalAlign="Left"							DataField="Detalle"					HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
        </table>
        <br />

		<!-- Indicadores  -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="DivisonTabla">&nbsp;Género</td></tr>
			<tr><td></td></tr>
			<tr>
				<td>
					<asp:CheckBoxList ID="chkIndicadorGenero" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="20"></asp:CheckBoxList>
				</td>
			</tr>
		</table>

		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="DivisonTabla">&nbsp;Edad</td></tr>
			<tr><td></td></tr>
			<tr>
				<td>
					<asp:CheckBoxList ID="chkIndicadorEdad" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="20"></asp:CheckBoxList>
				</td>
			</tr>
		</table>

		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="DivisonTabla">&nbsp;Actividad</td></tr>
			<tr><td></td></tr>
			<tr>
				<td>
					<asp:CheckBoxList ID="chkIndicadorActividad" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="20"></asp:CheckBoxList>
				</td>
			</tr>
		</table>

		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="DivisonTabla">&nbsp;Condición</td></tr>
			<tr><td></td></tr>
			<tr>
				<td>
					<asp:CheckBoxList ID="chkIndicadorCondicion" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="20"></asp:CheckBoxList>
				</td>
			</tr>
		</table>

		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="DivisonTabla">&nbsp;Comunidades</td></tr>
			<tr><td></td></tr>
			<tr>
				<td>
					<asp:CheckBoxList ID="chkIndicadorComunidades" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="20"></asp:CheckBoxList>
				</td>
			</tr>
		</table>

		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="DivisonTabla">&nbsp;Victimas</td></tr>
			<tr><td></td></tr>
			<tr>
				<td>
					<asp:CheckBoxList ID="chkIndicadorVictimas" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="20"></asp:CheckBoxList>
				</td>
			</tr>
		</table>

		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="DivisonTabla">&nbsp;Temas</td></tr>
			<tr><td></td></tr>
			<tr>
				<td>
					<asp:CheckBoxList ID="chkIndicadorTemas" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="20"></asp:CheckBoxList>
				</td>
			</tr>
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

	</div>

	<asp:HiddenField ID="hddSolicitudId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddCalificacionId" runat="server" Value="0"  />
	<asp:HiddenField ID="Sender" runat="server" Value=""  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="NombreTipoCiudadano" />

</asp:Content>
