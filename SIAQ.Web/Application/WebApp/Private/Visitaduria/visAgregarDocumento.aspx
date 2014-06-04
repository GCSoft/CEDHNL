<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="visAgregarDocumento.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.visAgregarDocumento" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Agregar documentos al expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label2" runat="server" Text="Agregue aquellos documentos que sirvan para complementar la información del expediente."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <div id="InformacionDiv">
        <table class="SolicitudTable">
            <tr>
                <td class="Especial">
                    Expediente número
                </td>
                <td class="Espacio">
                </td>
                <td class="Campo">
                    <asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label>
                </td>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td class="Nombre">
                    Calificación
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="CalificacionLlabel" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td class="Nombre">
                    Estatus
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="EstatusaLabel" runat="server" Text=""></asp:Label>
                </td>
                <td class="Espacio">
                </td>
                <td class="Nombre">
                    Fecha de recepción
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Nombre">
                    Visitador
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="VisitadorLabel" runat="server"></asp:Label>
                </td>
                <td class="Espacio">
                </td>
                <td class="Nombre">
                    Fecha de asignación
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Nombre">
                    Forma de contacto
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="FormaContactoLabel" runat="server" Text=""></asp:Label>
                </td>
                <td class="Espacio">
                </td>
                <td class="Nombre">
                    Fecha de inicio gestión
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="FechaGestionLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Nombre">
                    Tipo de solicitud
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="TipoSolicitudLabel" runat="server" Text=""></asp:Label>
                </td>
                <td class="Espacio">
                </td>
                <td class="Nombre">
                    Última modificación
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="FechaModificacionLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Nombre">
                    Observaciones (Recepción)
                </td>
                <td class="Espacio">
                </td>
                <td class="Observaciones" colspan="5">
                    <asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Nombre">
                    Lugar de los hechos
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta" colspan="5">
                    <asp:Label ID="LugarHechosLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Nombre">
                    Dirección de los hechos
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta" colspan="5">
                    <asp:Label ID="DireccionHechos" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td class="tdCeldaMiddleSpace">
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <asp:Button CssClass="Button_General" ID="AgregarButton" OnClick="AgregarButton_Click" runat="server" Text="Agregar documento" />&nbsp;&nbsp;&nbsp;
                    <input class="Button_General" id="RegresarButton" onclick="document.location.href='visDetalleExpediente.aspx';" style="width: 125px;" type="button" value="Regresar" />
                </td>
            </tr>
        </table>

        <br /><br />
        <div>
            <asp:GridView AutoGenerateColumns="False" ID="DocumentoGrid" PageSize="10" runat="server" Style="text-align: center" Width="100%">
                <RowStyle CssClass="Grid_Row" />
                <EditRowStyle Wrap="True" />
                <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                <EmptyDataTemplate>
                    <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                        <tr class="Grid_Header">
                            <td>Nombre</td>
                            <td style="width: 1;">Tipo</td>
                            <td style="width: 50px;"></td>
                        </tr>
                        <tr class="Grid_Row">
                            <td colspan="3">No se encontraron documentos relacionados al expediente</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción"></asp:BoundField>
                    <asp:TemplateField HeaderText="Borrar">
                        <ItemTemplate>
                            <asp:ImageButton ID="EliminarButton" CommandArgument='<%#Eval("RepositorioId")%>' CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" OnClientClick="return confirm('¿En realidad desea eliminar el documento?');" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <!-- Panel para agregar documentos -->
    <asp:Panel ID="pnlAction" runat="server" CssClass="ActionBlock" Visible="false">
        <asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" Style="top:180px;" Height="400px" Width="800px">
            <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
                <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; width: 100%">
                    <tr>
                        <td style="width: 10px">
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle" Text="Asunto de la solicitud"></asp:Label>
                        </td>
                        <td style="vertical-align: middle; width: 14px;">
                            <asp:ImageButton ID="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" onclick="imgCloseWindow_Click"></asp:ImageButton>
                        </td>
                        <td style="width: 10px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
                <table class="GeneralTable">
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
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
