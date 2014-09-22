<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VicAgregarDocumento.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.VicAgregarDocumento" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">

</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<asp:UpdatePanel ID="DocumentUpdate" runat="server">
        <ContentTemplate>
	
			<div id="TituloPaginaDiv">
				<table class="GeneralTable">
					<tr>
						<td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
							Agregar documentos
						</td>
					</tr>
					<tr>
						<td class="SubTitulo">
							<asp:Label ID="Label1" runat="server" Text="Agregue aquellos documentos que sirvan para complementar Dictámen."></asp:Label>
						</td>
					</tr>
				</table>
			</div>

			<div id="InformacionDiv">
		
				<table class="SolicitudTable">
					<!-- Carátula -->
					<tr>
						<td class="Especial">Folio</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:Label ID="AtencionNumeroFolio" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Especial">Afectado</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:Label ID="AfectadoLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">No. Oficio</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="AtencionNumeroOficio" runat="server" Text=""></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">Área</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="AreaLabel" runat="server" Text=""></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">Expediente número</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="ExpedienteNumeroLabel" runat="server" Text=""></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">Solicitud número</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="SolicitudNumeroLabel" runat="server" Text=""></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Fecha de Atención</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="FechaAtencionLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Estatus</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server" Text=""></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Fecha de Asignación</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Médico</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="DoctorLabel" runat="server" Text=""></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Ultima Modificación</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="UltimaModificacionLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Dictámen Médico</td>
						<td class="Espacio"></td>
						<td class="Etiqueta" colspan="5"><asp:Label ID="DictamenMedicoLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Lugar de Revisión</td>
						<td class="Espacio"></td>
						<td class="Etiqueta" colspan="5"><asp:Label ID="LugarRevisionLabel" runat="server" Text=""></asp:Label></td>
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
											<td colspan="2">No se encontraron Documentos asociados al Dictámen</td>
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

			<asp:HiddenField ID="hddAtencionId" runat="server" Value="0"  />
			<asp:HiddenField ID="hddExpedienteId" runat="server" Value="0"/>  
			<asp:HiddenField ID="hddSolicitudId" runat="server" Value="0"/>
			<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
			<asp:HiddenField ID="hddSort" runat="server" Value="NombreDocumento"  />
	
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="btnAgregar" />
		</Triggers>
	</asp:UpdatePanel>

</asp:Content>