<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="visDetalleExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.visDetalleExpediente" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <script language="javascript" type="text/javascript">
        function ImprimirExpediente() {
            var ExpedienteId = 0;

            ExpedienteId = document.getElementById("<%= ExpedienteIdHidden.ClientID %>");

            window.open("visImprmirExpediente.aspx?E=" + ExpedienteId.Value, "ImprimirExpediente", "");
        }
    </script>
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
                    <asp:Label ID="Label2" runat="server" Text="Seleccione las opciones disponibles para capturar la información de la solicitud."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <div id="SubMenuDiv">
        <asp:Panel CssClass="IconoPanel" ID="InformacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="InformacionGeneralButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png" runat="server" OnClick="InformacionGeneralButton_Click"></asp:ImageButton><br />
            Información general
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="AsignarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AsignarButton" ImageUrl="/Include/Image/Icon/AsignarIcon.png" runat="server" OnClick="AsignarButton_Click"></asp:ImageButton><br />
            Asignar visitador
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="AcuerdoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AcuerdoButton" ImageUrl="/Include/Image/Icon/AcuerdoIcon.png" runat="server" OnClick="AcuerdoButton_Click"></asp:ImageButton><br />
            Acuerdo de calificación definitiva
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="DiligenciaPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DiligenciasButton" ImageUrl="/Include/Image/Icon/DiligenciaIcon.png" runat="server" OnClick="DiligenciasButton_Click"></asp:ImageButton><br />
            Diligencias
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="DocumentoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DocumentoButton" ImageUrl="/Include/Image/Icon/DocumentoIcon.png" runat="server" OnClick="DocumentoButton_Click"></asp:ImageButton><br />
            Agregar documentos
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="SeguimientoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="SeguimientoButton" ImageUrl="/Include/Image/Icon/SeguimientoIcon.png" runat="server" OnClick="SeguimientoButton_Click"></asp:ImageButton><br />
            Seguimiento
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="ComparecenciaPanel" runat="server" Visible="true">
            <asp:ImageButton ID="ComparecenciaButton" ImageUrl="/Include/Image/Icon/ComparecenciaIcon.png" runat="server" OnClick="ComparecenciaPanel_Click"></asp:ImageButton><br />
            Comparecencia
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="ResolucionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="ResolucionButton" ImageUrl="/Include/Image/Icon/ResolucionIcon.png" runat="server" OnClick="ResolucionButton_Click"></asp:ImageButton><br />
            Resolución
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="RecomendacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="RecomendacionButton" ImageUrl="/Include/Image/Icon/RecomendacionIcon.png" runat="server" OnClick="RecomendacionButton_Click"></asp:ImageButton><br />
            Recomendaciones
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="ImprimirPanel" runat="server" Visible="true">
            <asp:ImageButton ID="ImprimirButton" ImageUrl="/Include/Image/Icon/ImprimirIcon.png" OnClientClick="ImprimirExpediente();" runat="server"></asp:ImageButton><br />
            Imprimir
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="EnviarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="EnviarButton" ImageUrl="/Include/Image/Icon/EnviarIcon.png" runat="server" OnClick="EnviarButton_Click"></asp:ImageButton><br />
            Enviar expediente
        </asp:Panel>
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
                <td class="tdCeldaMiddleSpace">
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    Ciudadanos
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="CiudadanosGrid" runat="server" AllowPaging="false" AllowSorting="true"
                        AutoGenerateColumns="False" Width="100%" DataKeyNames="CiudadanoId" OnRowCommand="CiudadanosGrid_RowCommand"
                        OnRowDataBound="CiudadanosGrid_RowDataBound" OnSorting="CiudadanosGrid_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width: 100px;">
                                        Nombre
                                    </td>
                                    <td style="width: 200px;">
                                        Sexo
                                    </td>
                                    <td style="width: 100px;">
                                        Fecha nacimiento
                                    </td>
                                    <td style="width: 100px;">
                                        Domicilio
                                    </td>
                                    <td style="width: 100px;">
                                        Teléfono
                                    </td>
                                    <td style="width: 100px;">
                                        Tipo
                                    </td>
                                    <td style="width: 100px;">
                                        Editar
                                    </td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="7">
                                        No se encontraron ciudadanos relacionados con el expediente
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="CiudadanoId" Visible="false" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                            <asp:BoundField DataField="Sexo" HeaderText="Sexo" SortExpression="Sexo"></asp:BoundField>
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha nacimiento" SortExpression="FechaNacimiento">
                            </asp:BoundField>
                            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" SortExpression="Domicilio">
                            </asp:BoundField>
                            <asp:BoundField DataField="TelefonoPrincipal" HeaderText="Teléfono" SortExpression="TelefonoPrincipal">
                            </asp:BoundField>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Borrar"
                                        ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="tdCeldaMiddleSpace">
                </td>
            </tr>
            <tr>
                <td class="tdCeldaMiddleSpace">
                </td>
            </tr>
        </table>

        <br />
        <!-- Datalist para documentos -->
        <div style="text-align: left;">
            Documentos anexos</div>
        <div class="DocumentoListDiv">
            <asp:DataList CellPadding="5" CellSpacing="5" ID="DocumentoList" HorizontalAlign="Left"
                RepeatDirection="Horizontal" RepeatLayout="Table" OnItemDataBound="DocumentList_ItemDataBound"
                runat="server">
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
        <!-- Fin datalist -->

        <!-- Repeater para los comentarios -->
        <div class="SolicitudComentarioDiv">
            <div style="text-align: left;">
                Asuntos &nbsp;&nbsp;
                <asp:LinkButton ID="AgregarComentarioLink" runat="server" CssClass="LinkButton_Regular" Text="Agregar comentario" OnClick="AgregarComentarioLink_Click"></asp:LinkButton>
            </div>
            <div class="TituloDiv">
                <asp:Label ID="ComentarioTituloLabel" runat="server" Text=""></asp:Label></div>
            <asp:Repeater ID="ComentarioRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1" class="ComentarioSolicitudTable">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="Numero">
                            <%# DataBinder.Eval(Container.DataItem, "Numero") %>
                        </td>
                        <td>
                            <table class="ComentarioSolicitudTable">
                                <tr>
                                    <td class="Nombre">
                                        <%# DataBinder.Eval(Container.DataItem, "NombreUsuario") %>
                                    </td>
                                    <td class="Fecha">
                                        <%# DataBinder.Eval(Container.DataItem, "Fecha") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Texto" colspan="2">
                                        <%# DataBinder.Eval(Container.DataItem, "Comentario") %>
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
        <!-- Fin repeater -->

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
                    <input class="Button_General" id="RegresarButton" onclick="document.location.href='opeBusquedaExpedientes.aspx';" style="width: 125px;" type="button" value="Regresar" />
                </td>
            </tr>
        </table>
    </div>

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
                            <asp:ImageButton ID="CloseWindowButton" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png"
                                ToolTip="Cerrar Ventana" onclick="CloseWindowButton_Click"></asp:ImageButton>
                        </td>
                        <td style="width: 10px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
                <div style="margin: 0 auto; width: 98%;">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; text-align: left;"
                        width="100%">
                        <tr style="height: 20px;">
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr class="trFilaItem">
                            <td class="tdActionCeldaLeyendaItem" colspan="3">
                                <CKEditor:CKEditorControl ID="txtAsuntoSolicitud" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                        <tr style="height: 5px;">
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: right;">
                                <asp:Button ID="AgregarComentarioButton" runat="server" Text="Agregar comentario" CssClass="Button_General" Width="200px" onclick="AgregarComentarioButton_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblActionMessage" runat="server" CssClass="ActionContentMessage"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>

    <asp:HiddenField ID="ExpedienteIdHidden" runat="server" Value="0" />
</asp:Content>
