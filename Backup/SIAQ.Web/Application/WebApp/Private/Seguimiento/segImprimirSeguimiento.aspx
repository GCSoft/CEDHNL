<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="segImprimirSeguimiento.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segImprimirSeguimiento" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>SIAQ - Vista Previa Impresión</title>
		<meta content="GCSoft - Web Project Creator BETA 1.0" name="autor" />
		<link rel="shortcut icon" href="~/Include/Image/Content/Web/favicon.ico" type="image/png" />
		<link href="~/Include/Style/Content.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/Control.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/MasterPage.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/Table.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/Text.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/Wait.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Javascript/TinyBox/TinyBox.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Javascript/ToolTip/ToolTip.css" rel="Stylesheet" type="text/css" />
		<script src="../../../../Include/Javascript/TinyBox/TinyBox.js" type="text/javascript"></script>
		<script src="../../../../Include/Javascript/ToolTip/ToolTip.js" type="text/javascript"></script>
		<script language="javascript" type="text/javascript" src="../../../../Include/Javascript/GCSoft/GCSoft.js"></script>
	</head>
	<body>
		<form id="form1" runat="server">
			
			<div id="TituloPaginaDiv">
				<table class="GeneralTable">
					<tr>
						<td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
							<asp:Label ID="lblEncabezado" runat="server" ></asp:Label>
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
							<asp:GridView ID="gvPuntosResolutivos" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" Width="100%"
								DataKeyNames="RecomendacionDetalleId"
								OnRowDataBound="gvPuntosResolutivos_RowDataBound">
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
							<asp:GridView ID="gvGestion" runat="server" AllowPaging="false" AllowSorting="false"  AutoGenerateColumns="False" Width="100%"
								OnRowDataBound="gvGestion_RowDataBound">
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
							<asp:GridView ID="gvGestionPuntosResolutivos" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" Width="100%"
								DataKeyNames="RecomendacionDetalleId,RowNumber"
								OnRowDataBound="gvGestionPuntosResolutivos_RowDataBound">
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
							<asp:GridView ID="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" Width="100%"
								DataKeyNames="CiudadanoId,NombreCompleto" 
								OnRowDataBound="gvCiudadano_RowDataBound">
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
							<asp:GridView ID="gvDiligencia" runat="server" AllowPaging="false" AllowSorting="false"  AutoGenerateColumns="False" Width="100%"
								DataKeyNames="DiligenciaId,ModuloId,Fecha"
								OnRowDataBound="gvDiligencia_RowDataBound">
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
								</Columns>
							</asp:GridView>
						</td>
					</tr>
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
				</table>
				<br />

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

		</form>
	</body>
</html>
