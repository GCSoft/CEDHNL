<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeAsignarVisitador.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAsignarVisitador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <script type="text/javascript">

        // Funciones del programador
        function NumbersValidator(e) {

            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return (tecla > 47 && tecla < 58);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                Asignar visitador
            </td>
        </tr>
        <tr>
            <td class="SubTitulo">
                <asp:Label ID="Label2" runat="server" Text="Seleccione el visitador al que se le asignará el expediente para su seguimiento"></asp:Label>
            </td>
        </tr>
        <tr style="height: 2px;">
            <td colspan="13">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormularioSecretaria" runat="server" Visible="true" Width="100%">
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
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
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
                                Visitador
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:DropDownList ID="ddlVisitador" runat="server" Width="216px" CssClass="DropDownList_General">
                                </asp:DropDownList>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="btnAsignarExpediente" runat="server" Text="Asignar a expediente"
                                    CssClass="Button_General" Width="125px" OnClick="btnAsignarExpediente_Click" />
                            </td>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General"
                                    Width="125px" OnClick="btnRegresar_Click" />
                            </td>
                            <td style="height: 24px; width: 530px;">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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
        <tr>
            <td style="background-color: #CCCCCC; text-align: left;">
                Detalle del expediente
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server" Visible="true" Width="100%">
                    <table class="SolicitudTable">
                        <tr>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td colspan="4">
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
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
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
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                Ciudadanos
            </td>
        </tr>
        <tr style="height: 3px;">
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGridCiudadanos" runat="server" Width="100%">
                    <asp:GridView ID="gvCiudadanos" runat="server" AllowPaging="false" AllowSorting="true"
                        AutoGenerateColumns="False" Width="100%" DataKeyNames="CiudadanoId" OnRowDataBound="gvCiudadanos_RowDataBound"
                        OnSorting="gvCiudadanos_Sorting" OnRowCommand="gvCiudadanos_RowCommand">
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
                            <asp:BoundField DataField="Sexo" HeaderText="Sexo" SortExpression="Sexo">
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha nacimiento" SortExpression="FechaNacimiento">
                            </asp:BoundField>
                            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" SortExpression="Domicilio">
                            </asp:BoundField>
                            <asp:BoundField DataField="TelefonoPrincipal" HeaderText="Teléfono" SortExpression="TelefonoPrincipal">
                            </asp:BoundField>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo">
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Borrar"
                                        ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDocumentos" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
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
                                <div class="SolicitudComentarioDiv">
                                    <div style="text-align: left;">
                                        Comentarios &nbsp;&nbsp;
                                        <asp:LinkButton ID="lnkAgregarComentario" runat="server" CssClass="LinkButton_Regular"
                                            Text="Agregar comentario" OnClick="lnkAgregarComentario_Click"></asp:LinkButton>
                                    </div>
                                    <div class="TituloDiv">
                                        <asp:Label ID="ComentarioTituloLabel" runat="server" Text=""></asp:Label></div>
                                    <asp:Repeater ID="ComentarioRepeater" runat="server">
                                        <HeaderTemplate>
                                            <table class="ComentarioSolicitudTable">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# DataBinder.Eval(Container.DataItem, "Numero") %>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "NombreUsuario") %>
                                                            </td>
                                                            <td>
                                                                <%# DataBinder.Eval(Container.DataItem, "Fecha") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
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
                                <asp:Panel ID="pnlAction" runat="server" CssClass="ActionBlock" Visible="false">
                                    <asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" Style="top: 200px;"
                                        Height="400px" Width="800px">
                                        <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
                                            <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; width: 100%">
                                                <tr>
                                                    <td style="width: 10px">
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle" Text="Asunto de la solicitud"></asp:Label>
                                                    </td>
                                                    <td style="vertical-align: middle; width: 14px;">
                                                        <asp:ImageButton ID="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png"
                                                            ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton>
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
                                                            <asp:Button ID="btnAction" runat="server" Text="Agregar comentario" CssClass="Button_General"
                                                                Width="200px" OnClick="btnAction_Click" />
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
                                    <ajaxToolkit:DragPanelExtender ID="dragPanelAction" runat="server" TargetControlID="pnlAction"
                                        DragHandleID="pnlActionHeader">
                                    </ajaxToolkit:DragPanelExtender>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdCeldaMiddleSpace">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr class="trFilaFooter">
            <td>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
    <asp:HiddenField ID="hdnExpedienteId" runat="server" />
    <asp:HiddenField ID="hdnComentarioId" runat="server" />
</asp:Content>
