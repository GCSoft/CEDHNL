<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segDetalleRecomendacionCierre.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segDetalleRecomendacionCierre" %>
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
					<asp:Label ID="Label1" runat="server" Text="Proporcione la información solicitada para dar seguimiento a las recomendaciones del expediente."></asp:Label>
				</td>
			</tr>
		</table>
	</div>

	<div id="SubMenuDiv">
       <asp:Panel CssClass="IconoPanel" ID="AprobarProyectoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AprobarProyectoButton" ImageUrl="~/Include/Image/Icon/ConfirmacionCierreIcon.png" runat="server" OnClick="AprobarProyectoButton_Click" OnClientClick="return confirm('¿Seguro que desea aprobar el documento?');"></asp:ImageButton><br />
            Aprobar documento
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="RechazarProyectoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="RechazarProyectoButton" ImageUrl="~/Include/Image/Icon/RechazarCierreIcon.png" runat="server" OnClick="RechazarProyectoButton_Click" OnClientClick="return confirm('¿Seguro que desea rechazar el documento?');"></asp:ImageButton><br />
            Rechazar documento
        </asp:Panel>
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

		<!-- Puntos Resolutivos-->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr>
				<td style="text-align: left;">
					Puntos Resolutivos
				</td>
			</tr>
			<tr>
				<td>
					<asp:GridView ID="gvPuntosResolutivos" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="RecomendacionDetalleId" 
						OnRowDataBound="gvPuntosResolutivos_RowDataBound"
						OnSorting="gvPuntosResolutivos_Sorting">
						<RowStyle CssClass="Grid_Row" />
						<EditRowStyle Wrap="True" />
						<HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
						<AlternatingRowStyle CssClass="Grid_Row_Alternating" />
						<EmptyDataTemplate>
							<table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:50px;">No</td>
									<td style="width:150px;">Estatus</td>
									<td>Detalle</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="3">No se encontraron Puntos Resolutivos asociados a la Recomendacion/Acuerdo de No Responsabilidad</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="No"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="50px"	DataField="RowNumber"						SortExpression="RowNumber"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="150px"	DataField="EstatusPuntoResolutivoNombre"	SortExpression="EstatusPuntoResolutivoNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"	ItemStyle-HorizontalAlign="Left"							DataField="Detalle"		HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
						</Columns>
					</asp:GridView>
				</td>
			</tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
		</table>
		<br />

		<!-- Gestion de Documento-->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr>
				<td style="text-align: left;">
					Gestión de Documento
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
		<br />

		<!-- Gestion de Puntos Resolutivos-->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr>
				<td style="text-align: left;">
					Gestión de Puntos Resolutivos
				</td>
			</tr>
			<tr>
				<td>
					<asp:GridView ID="gvGestionPuntosResolutivos" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="RecomendacionDetalleId,RowNumber"
						OnRowCommand="gvGestionPuntosResolutivos_RowCommand"
						OnRowDataBound="gvGestionPuntosResolutivos_RowDataBound"
						OnSorting="gvGestionPuntosResolutivos_Sorting">
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
		<br />

		<!-- Ciudadanos-->
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
									<td colspan="6">No se encontraron Ciudadanos asociados al Expediente</td>
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
					<asp:GridView ID="gvDiligencia" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="DiligenciaId,ModuloId,Fecha"
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

		<!-- Asuntos/Comentarios -->
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
										<%# DataBinder.Eval(Container.DataItem, "Fecha")%><br />
										<%# DataBinder.Eval(Container.DataItem, "ModuloNombre")%> - <%# DataBinder.Eval(Container.DataItem, "Tipo")%>
										<asp:HiddenField ID="hddModuloId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ModuloId")%>' />
									</td>
								</tr>
								<tr>
									<td class="Texto" colspan="2">
										<%# DataBinder.Eval(Container.DataItem, "Comentario")%>
									</td>
								</tr>
								<tr>
									<td colspan="2" style="text-align:right;">
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

	<asp:HiddenField ID="hddRecomendacionId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="Sender" runat="server" Value = ""  />
	<asp:HiddenField ID="hddSort" runat="server" Value="RowNumber" />

</asp:Content>
