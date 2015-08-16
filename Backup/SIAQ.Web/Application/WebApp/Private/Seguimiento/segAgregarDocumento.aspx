<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segAgregarDocumento.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segAgregarDocumento" %>
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
							<asp:Label ID="lblEncabezado" runat="server" ></asp:Label>
						</td>
					</tr>
					<tr>
						<td class="SubTitulo">
							<asp:Label ID="Label1" runat="server" Text="Agregue aquellos documentos que sirvan para complementar la información del Recomendacion."></asp:Label>
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
						<td colspan="7"><CKEditor:CKEditorControl ID="ckeDescripcion" runat="server" BasePath="~/Include/Components/CKEditor/Core/" Height="90px"></CKEditor:CKEditorControl></td>
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
							Documentos asociados al Recomendacion
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
											<td colspan="2">No se encontraron Documentos asociados al Recomendacion</td>
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

			<asp:HiddenField ID="hddRecomendacionId" runat="server" Value="0"  />
			<asp:HiddenField ID="hddExpedienteId" runat="server" Value="0"  />
			<asp:HiddenField ID="hddSolicitudId" runat="server" Value="0"  />
			<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
			<asp:HiddenField ID="hddSort" runat="server" Value="NombreDocumento"  />
	
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="btnAgregar" />
		</Triggers>
	</asp:UpdatePanel>

</asp:Content>
