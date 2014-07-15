<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarDocumentos.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarDocumentos" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
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
                            <asp:Label ID="Label2" runat="server" Text="Agregue aquellos documentos que sirvan para complementar la información de la solicitud."></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <div id="InformacionDiv">
				
				<!-- Carátula -->
                <table class="SolicitudTable">
                    <tr>
						<td class="Especial">Solicitud Número</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
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
						<td class="Nombre">Observaciones (Recepción)</td>
						<td class="Espacio"></td>
						<td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Lugar de los hechos</td>
						<td class="Espacio"></td>
						<td class="Etiqueta" colspan="5"><asp:Label ID="LugarHechosLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Dirección de los hechos</td>
						<td class="Espacio"></td>
						<td class="Etiqueta" colspan="5"><asp:Label ID="DireccionHechosLabel" runat="server" Text=""></asp:Label></td>
					</tr>
                    <tr>
                        <td class="Nombre">Archivo</td>
                        <td class="Espacio"></td>
                        <td class="Campo" coslpan="5"><asp:FileUpload ID="DocumentoFile" runat="server" Width="210px" /></td>
                    </tr>
                    <tr>
                        <td class="Nombre">Tipo de documento</td>
                        <td class="Espacio"></td>
                        <td class="Campo" coslpan="5"><asp:DropDownList ID="TipoDocumentoList" runat="server" CssClass="DropDownList_General" Width="198px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="Nombre">Nombre</td>
                        <td class="Espacio"></td>
                        <td class="Campo" coslpan="5"><asp:TextBox ID="NombreBox" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="Nombre">Descripción</td>
                        <td class="Espacio"></td>
                        <td class="Campo" coslpan="5"><asp:TextBox ID="DescripcionBox" runat="server" CssClass="Textbox_General" TextMode="MultiLine" Height="100px" width="360px" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="Botones" colspan="7">
                            <br />
                            <asp:Button ID="GuardarButton" runat="server" Text="Agregar" CssClass="Button_General" width="125px" onclick="GuardarButton_Click"/>
                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click"/>
                        </td>
                    </tr>
                </table>

                <br /><br />
                <div>
                    <asp:GridView AutoGenerateColumns="False" ID="DocumentoGrid" OnRowCommand="DocumentoGrid_RowCommand"
                        OnRowDataBound="DocumentoGrid_RowDataBound" PageSize="10" runat="server" Style="text-align: center" Width="100%">
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
                                    <td colspan="4">No se encontraron documentos relacionados al expediente</td>
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
                </div>

            <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GuardarButton" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

