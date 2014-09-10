<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="QueAgregarDocumentos.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Quejas.QueAgregarDocumentos" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<asp:UpdatePanel ID="DocumentUpdate" runat="server">
        <ContentTemplate>
	
			<div id="TituloPaginaDiv">
				<table class="GeneralTable">
					<tr>
						<td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
							Agregar documentos a la solicitud
						</td>
					</tr>
					<tr>
						<td class="SubTitulo">
							<asp:Label ID="Label1" runat="server" Text="Agregue aquellos documentos que sirvan para complementar la información de la solicitud."></asp:Label>
						</td>
					</tr>
				</table>
			</div>

			<div id="InformacionDiv">
		
				<table class="SolicitudTable">
					<!-- Carátula -->
					<tr>
						<td class="Especial">Solicitud Número</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:Label ID="SolicitudNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Especial">Afectado/Quejoso</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:Label ID="AfectadoLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">Calificación</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="CalificacionLabel" runat="server" Text=""></asp:Label></td>
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
					<!-- Fin Carátula -->
					<tr>
						<td class="Nombre">Archivo</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td colspan="5" style="text-align:left;">
							<asp:FileUpload ID="fupArchivo" runat="server" Width="210px" />

						</td>
					</tr>
					<tr><td class="Nombre" colspan="7" style="text-align:left;">Descripción</td></tr>
					<tr>
						<td colspan="7"><CKEditor:CKEditorControl ID="ckeDescripcion" runat="server" BasePath="~/Include/Components/CKEditor/Core/" Height="90px" MaxLength="8000"></CKEditor:CKEditorControl></td>
					</tr>
				</table>
				<br />

				<!-- Botones Pie de Página -->
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr>
						<td style="text-align: left;">
							<asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="Button_General" width="125px" onclick="btnAgregar_Click" /> &nbsp;&nbsp;
							<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
						</td>
					</tr>
				</table>
				
				<!-- Grid -->
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr>
						<td style="text-align: left;">
							Documentos asociados al Expediente
						</td>
					</tr>
					<tr>
						<td>
							<asp:GridView ID="gvDocumento" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
								DataKeyNames="DocumentoId,ModuloId,NombreDocumento,Icono"
								OnRowCommand="gvDocumento_RowCommand" 
								OnRowDataBound="gvDocumento_RowDataBound" 
								OnSorting="gvDocumento_Sorting">
								<AlternatingRowStyle CssClass="Grid_Row_Alternating" />
								<HeaderStyle CssClass="Grid_Header" />
								<RowStyle CssClass="Grid_Row" />
								<EmptyDataTemplate>
									<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
										<tr class="Grid_Header">
											<td style="width:200px;">Nombre</td>
											<td>Descripción</td>
										</tr>
										<tr class="Grid_Row">
											<td colspan="2">No se encontraron Documentos asociados al Expediente</td>
										</tr>
									</table>
								</EmptyDataTemplate>
								<Columns>
									<asp:BoundField HeaderText="Nombre"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="NombreDocumento"						SortExpression="NombreDocumento"></asp:BoundField>
									<asp:BoundField HeaderText="Descripción"	ItemStyle-HorizontalAlign="Left"							DataField="Descripcion"		HtmlEncode="false"	SortExpression="Descripcion"></asp:BoundField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
										<ItemTemplate>
											<asp:ImageButton ID="imgView" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Visualizar" runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
										<ItemTemplate>
											<asp:ImageButton ID="imgDelete" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Borrar" ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
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

			<asp:HiddenField ID="hddSolicitudId" runat="server" Value="0"  />
			<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
			<asp:HiddenField ID="hddSort" runat="server" Value="NombreDocumento"  />
	
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="btnAgregar" />
		</Triggers>
	</asp:UpdatePanel>

</asp:Content>
