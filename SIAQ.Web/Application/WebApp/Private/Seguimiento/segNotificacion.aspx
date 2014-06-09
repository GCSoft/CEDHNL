<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segNotificacion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segNotificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">

</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<asp:UpdatePanel ID="DocumentUpdate" runat="server">
        <ContentTemplate>
			
			<div id="TituloPaginaDiv">
				<table class="GeneralTable">
					<tr>
						<td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
							Notificación de recomendaciones
						</td>
					</tr>
					<tr>
						<td class="SubTitulo">
							<asp:Label ID="Label1" runat="server" Text="Agregue los documentos de notificación en el seguimiento del expediente."></asp:Label>
						</td>
					</tr>
				</table>
			</div>

			<div id="InformacionDiv">
		
				<!-- Carátula -->
				<table class="SolicitudTable">
					<tr>
						<td class="Especial">Expediente número</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="ExpedienteNumeroLabel" runat="server" Text="0"></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">Calificación</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="CalificacionLabel" runat="server" Text=""></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Fecha de recepción</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Estatus</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server"></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Fecha de asignación</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Tipo de solicitud</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="TipoSolicitudLabel" runat="server"></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Fecha de inicio gestión</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="FechaInicioLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Defensor</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="DefensorLabel" runat="server"></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Última modificación</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="FechaUltimaLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Observaciones</td>
						<td class="Espacio"></td>
						<td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
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
						<td class="Nombre">Recomendación</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo" colspan="5"><asp:FileUpload ID="DocumentoFile" runat="server" Width="300px" /></td>
					</tr>
					<tr>
						<td class="Nombre">Tipo de documento</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo" colspan="5"><asp:DropDownList ID="TipoDocumentoList" runat="server" CssClass="DropDownList_General" Width="205px"></asp:DropDownList></td>
					</tr>
					<tr>
						<td class="Nombre">Nombre</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo" colspan="5"><asp:TextBox ID="NombreBox" runat="server" CssClass="Textbox_General" width="200px" ></asp:TextBox></td>
					</tr>
					<tr>
						<td class="Nombre">Descripción</td>
						<td class="Espacio"></td>
						<td class="Campo" colspan="5"><asp:TextBox ID="DescripcionBox" runat="server" CssClass="Textbox_General" TextMode="MultiLine" Height="100px" width="360px" ></asp:TextBox></td>
					</tr>
				</table>

				<!-- Botones -->
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr>
						<td style="text-align: left;">
							<asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="Button_General" width="125px" onclick="btnAgregar_Click" /> &nbsp;&nbsp;
							<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
						</td>
					</tr>
				</table>
				<br />
        
				<!-- Grid -->
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr>
						<td style="text-align: left;">
							Notificaciones adjuntadas
						</td>
					</tr>
					<tr>
						<td>
							<asp:GridView AutoGenerateColumns="False" ID="grdDocumento" runat="server" Style="text-align: center" Width="100%"
								OnRowCommand="grdDocumento_RowCommand"
								OnRowDataBound="grdDocumento_RowDataBound">
								<RowStyle CssClass="Grid_Row" />
								<EditRowStyle Wrap="True" />
								<HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
								<AlternatingRowStyle CssClass="Grid_Row_Alternating" />
								<EmptyDataTemplate>
									<table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
										<tr class="Grid_Header">
											<td>Nombre</td>
											<td style="width: 150px;">Tipo</td>
											<td style="width: 75px;"></td>
											<td style="width: 50px;"></td>
										</tr>
										<tr class="Grid_Row">
											<td colspan="4">No se encontraron documentos de notificación relacionados al expediente</td>
										</tr>
									</table>
								</EmptyDataTemplate>
								<Columns>
									<asp:BoundField DataField="NombreDocumento" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
									<asp:BoundField DataField="Descripcion" HeaderText="Descripción"></asp:BoundField>
									<asp:TemplateField HeaderText="Ver">
										<ItemTemplate>
											<asp:HyperLink ID="DocumentoLink" runat="server" Target="_blank" Text=""><asp:Image ID="DocumentoImage" runat="server" /></asp:HyperLink>
										</ItemTemplate>
										<ItemStyle HorizontalAlign="Center" Width="75px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Borrar">
										<ItemTemplate>
											<asp:ImageButton ID="EliminarButton" CommandArgument='<%#Eval("RepositorioId")%>' CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" OnClientClick="return confirm('¿En realidad desea eliminar el documento?');" runat="server" />
										</ItemTemplate>
										<ItemStyle HorizontalAlign="Center" Width="50px" />
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
						</td>
					</tr>
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
				</table>
				<br />

			</div>

			<asp:HiddenField ID="ExpedienteIdHidden" runat="server" Value="0"  />
			<asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0"  />
			<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
			<asp:HiddenField ID="hddSort" runat="server" Value="Numero" />

		 </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAgregar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
