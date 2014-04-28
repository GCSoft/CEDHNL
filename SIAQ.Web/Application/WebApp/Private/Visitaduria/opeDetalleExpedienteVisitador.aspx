<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeDetalleExpedienteVisitador.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeDetalleExpedienteVisitador" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
                Detalle del expediente
            </td>
        </tr>
        <tr>
            <td class="SubTitulo">
                <asp:Label ID="Label2" runat="server" Text="Proporcione la información solicitada para llenar el expediente"></asp:Label>
            </td>
        </tr>
        <tr style="height: 2px;">
            <td colspan="13">
            </td>
        </tr>
        <tr>
            <td>
                <div id="SubMenuDivSecretaria" runat="server" visible="true">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="InformacionGeneralSecretariaButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png"
                                    runat="server" OnClick="InformacionGeneralSecretariaButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="AsignarVisitadorButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                                    runat="server" OnClick="AsignarVisitadorButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                            </td>
                        </tr>
                        <tr style="height: 2px;">
                            <td colspan="13">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 65px; font-size: 10px;">
                                Información general
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                                Asignar visitador
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                            </td>
                        </tr>
                        <tr style="height: 30px;">
                            <td colspan="13">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="SubMenuDivVisitador" runat="server" visible="false">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="InformacionGeneralVisitadorButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png"
                                    runat="server" OnClick="InformacionGeneralVisitadorButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="AcuerdoCalificacionButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                                    runat="server" OnClick="AcuerdoCalificacionButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="DiligenciasButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                                    runat="server" OnClick="DiligenciasButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="SeguimientoButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                                    runat="server" OnClick="SeguimientoButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="ResolucionButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                                    runat="server" OnClick="ResolucionButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="EnviarExpedienteButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                                    runat="server" OnClick="EnviarExpedienteButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                            </td>
                        </tr>
                        <tr style="height: 2px;">
                            <td colspan="13">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 65px; font-size: 10px;">
                                Información general
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                                Acuerdo de calificación definitiva
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                                Diligencias
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                                Seguimiento
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                                Resolución
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                                Enviar expediente
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                            </td>
                        </tr>
                        <tr style="height: 30px;">
                            <td colspan="13">
                            </td>
                        </tr>
                    </table>
                </div>
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
                        AutoGenerateColumns="False" Width="800px" DataKeyNames="CiudadanoId" OnRowCommand="gvCiudadanos_RowCommand"
                        OnRowDataBound="gvCiudadanos_RowDataBound" OnSorting="gvCiudadanos_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px">
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
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha nacimiento" SortExpression="FechaNacimiento">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" SortExpression="Domicilio">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TelefonoPrincipal" HeaderText="Teléfono" SortExpression="TelefonoPrincipal">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo">
                                <ItemStyle HorizontalAlign="Left" />
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
        <tr>
            <td>
                <asp:Panel ID="pnlBotones" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 24px; text-align: left; width: 205px;">
                                <asp:Button ID="cmdRegresar" runat="server" Text="Regresar"
                                    CssClass="Button_General" Width="125px" OnClick="cmdRegresar_Click" />
                            </td>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                &nbsp;</td>
                            <td style="height: 24px; width: 530px;">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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
                                ToolTip="Cerrar Ventana" onclick="imgCloseWindow_Click"></asp:ImageButton>
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
                                    Width="200px" onclick="btnAction_Click" />
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
        <tr class="trFilaFooter">
            <td>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
    <asp:HiddenField ID="hdnExpedienteId" runat="server" />
    <asp:HiddenField ID="hdnComentarioId" runat="server" />
</asp:Content>
