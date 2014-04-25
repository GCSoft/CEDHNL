<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarDocumentos.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarDocumentos" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <asp:UpdatePanel ID="DocumentUpdate" runat="server">
        <ContentTemplate>
            <table class="GeneralTable">
                <tr>
                    <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
	                    Agregar documentos a la solicitud
                    </td>
		        </tr>
                <tr>
                    <td class="SubTitulo">Agregue aquellos documentos que sirvan para complementar la información de la solicitud</td>
                </tr>
                <tr>
                    <td>
                        <table border="0" style="width: 100%">
                            <tr>
                                <td class="Especial">Solicitud número</td>
                                <td class="Espacio"></td>
                                <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
                                <td class="Espacio"></td>
                                <td class="Agregados" rowspan="6">
                                    <div id="AgregadosDiv">
                                        <div class="TituloDiv">Archivos agregados a la solicitud</div>

                                        <div class="ContenidoDiv">
                                            <asp:GridView AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" BorderWidth="0"
                                                CssClass="AgregadosGrid" ID="DocumentoGrid" OnRowCommand="DocumentoGrid_RowCommand" ShowHeader="false" 
                                                ShowFooter="false" runat="server" Width="100%">
                                                <EmptyDataTemplate>
                                                    No se han agregado documentos a la solicitud
                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Cuenta de usuario">
                                                        <ItemTemplate>
                                                            <asp:LinkButton CommandArgument='<%#Eval("RepositorioId")%>' CommandName="Select" ID="DocumentoLink" runat="server" Text='<%#Eval("NombreDocumento")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="EliminarButton" CommandArgument='<%#Eval("RepositorioId")%>' CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" OnClientClick="return confirm('¿En realidad desea eliminar este documento?');" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="Nombre">Archivo</td>
                                <td class="Espacio"></td>
                                <td class="Campo"><asp:FileUpload ID="DocumentoFile" runat="server" Width="210px" /></td>
                                <td class="Espacio"></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Tipo de documento</td>
                                <td class="Espacio"></td>
                                <td class="Campo"><asp:DropDownList ID="TipoDocumentoList" runat="server" CssClass="DropDownList_General" Width="198px"></asp:DropDownList></td>
                                <td class="Espacio"></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Nombre</td>
                                <td class="Espacio"></td>
                                <td class="Campo"><asp:TextBox ID="NombreBox" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
                                <td class="Espacio"></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Descripción</td>
                                <td class="Espacio"></td>
                                <td class="Campo"><asp:TextBox ID="DescripcionBox" runat="server" CssClass="Textbox_General" TextMode="MultiLine" Height="100px" width="360px" ></asp:TextBox></td>
                                <td class="Espacio"></td>
                            </tr>
                            <tr>
                                <td class="Botones" colspan="5">
                                    <br />
                                    <asp:Button ID="GuardarButton" runat="server" Text="Agregar" CssClass="Button_General" width="125px" onclick="GuardarButton_Click"/>
                                    <input class="Button_General" id="RegresarButton" onclick="document.location.href='opeDetalleSolicitud.aspx?s=<%= _SolicitudId %>';" style="width: 125px;" type="button" value="Regresar" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

            <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GuardarButton" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

