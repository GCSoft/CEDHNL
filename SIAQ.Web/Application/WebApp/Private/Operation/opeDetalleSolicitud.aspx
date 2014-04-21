<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeDetalleSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeDetalleSolicitud" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
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
            <asp:ImageButton ID="InformacionGeneralButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png"
                runat="server" OnClick="InformacionGeneralButton_Click"></asp:ImageButton><br />
            Información general
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="CiudadanoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="CiudadanoButton" ImageUrl="/Include/Image/Icon/CiudadanoIcon.png"
                runat="server" OnClick="CiudadanoButton_Click"></asp:ImageButton><br />
            Agregar ciudadanos
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="CalificarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="CalificarButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                runat="server" OnClick="CalificarButton_Click"></asp:ImageButton><br />
            Calificar solicitud
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="AutoridadPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AutoridadButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png"
                runat="server" OnClick="AutoridadButton_Click"></asp:ImageButton><br />
            Agegar autoridades señaladas y voces
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="DiligenciasPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DiligenciaPanel" ImageUrl="/Include/Image/Icon/DiligenciaIcon.png"
                runat="server" OnClick="DiligenciaPanel_Click"></asp:ImageButton><br />
            Diligencias
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="IndicadorPanel" runat="server" Visible="true">
            <asp:ImageButton ID="IndicadorButton" ImageUrl="/Include/Image/Icon/IndicadorIcon.png"
                runat="server" OnClick="IndicadorButton_Click"></asp:ImageButton><br />
            Grupos minoritarios
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="DocumentoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DocumentoButton" ImageUrl="/Include/Image/Icon/DocumentoIcon.png"
                runat="server" OnClick="DocumentoButton_Click"></asp:ImageButton><br />
            Agregar documentos
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="EnviarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="EnviarButton" ImageUrl="/Include/Image/Icon/EnviarIcon.png"
                runat="server" OnClick="EnviarButton_Click"></asp:ImageButton><br />
            Enviar solicitud
        </asp:Panel>
    </div>
    <div id="InformacionDiv">
        <table class="SolicitudTable">
            <tr>
                <td class="Especial">
                    Solicitud Número
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
                    <asp:Label ID="CalificacionLabel" runat="server" Text=""></asp:Label>
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
                    Funcionario
                </td>
                <td class="Espacio">
                </td>
                <td class="Etiqueta">
                    <asp:Label ID="FuncionarioLabel" runat="server" Text=""></asp:Label>
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
                    <asp:Label ID="ContactoLabel" runat="server" Text=""></asp:Label>
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
                <td class="Campo" colspan="5">
                    <asp:DropDownList ID="LugarHechosList" runat="server" CssClass="DropDownList_General"
                        Width="198px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Nombre">
                    Dirección de los hechos
                </td>
                <td class="Espacio">
                </td>
                <td class="Campo" colspan="5">
                    <asp:TextBox CssClass="Textarea_General" ID="DireccionHechosBox" runat="server" TextMode="multiline"
                        Width="193px"></asp:TextBox>
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
                    <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                        <asp:GridView AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" DataKeyNames="SolicitudId"
                            ID="gvCiudadano" PageSize="30" runat="server" Style="text-align: center" UpdateAfterCallBack="True"
                            Width="800px" OnRowCommand="gvCiudadano_RowCommand" OnRowDataBound="gvCiudadano_RowDataBound"
                            OnSorting="gvCiudadano_Sorting">
                            <RowStyle CssClass="Grid_Row" />
                            <EditRowStyle Wrap="True" />
                            <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                            <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                            <EmptyDataTemplate>
                                <table border="1px" cellpadding="0px" cellspacing="0px" width="800px">
                                    <tr class="Grid_Header">
                                        <td style="width: 100px;">
                                            Nombre
                                        </td>
                                        <td style="width: 50px;">
                                            Sexo
                                        </td>
                                        <td style="width: 100px;">
                                            Fecha nacimiento
                                        </td>
                                        <td style="width: 200px;">
                                            Domicilio
                                        </td>
                                        <td style="width: 100px;">
                                            Telefono
                                        </td>
                                        <td style="width: 100px;">
                                            Tipo
                                        </td>
                                        <td style="width: 50px;">
                                            Editar
                                        </td>
                                    </tr>
                                    <tr class="Grid_Row">
                                        <td colspan="7">
                                            No se encontraron Ciudadanos registrados en el sistema
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="NombreCiudadano" HeaderText="Nombre"></asp:BoundField>
                                <asp:BoundField DataField="NombreSexo" HeaderText="Sexo"></asp:BoundField>
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha nacimiento"></asp:BoundField>
                                <asp:BoundField DataField="Domicilio" HeaderText="Funcionario"></asp:BoundField>
                                <asp:BoundField DataField="TelefonoPrincipal" HeaderText="Estatus"></asp:BoundField>
                                <asp:BoundField DataField="NombreTipoCiudadano" HeaderText="Quejosos"></asp:BoundField>
                                <asp:TemplateField HeaderText="Borrar">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
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
                <td class="tdCeldaMiddleSpace">
                </td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    Autoridades
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlGrid2" runat="server" Width="100%">
                        <asp:GridView ID="gvAutoridades" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                            UpdateAfterCallBack="True" Width="800px" Style="text-align: center" DataKeyNames="AutoridadId"
                            PageSize="30" OnRowCommand="gvAutoridades_RowCommand" OnRowDataBound="gvAutoridades_RowDataBound"
                            OnSorting="gvAutoridades_Sorting">
                            <RowStyle CssClass="Grid_Row" />
                            <EditRowStyle Wrap="True" />
                            <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                            <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                            <EmptyDataTemplate>
                                <table border="1px" cellpadding="0px" cellspacing="0px">
                                    <tr class="Grid_Header">
                                        <td style="width: 250px;">
                                            Nombre
                                        </td>
                                        <td style="width: 220px;">
                                            Puesto
                                        </td>
                                        <td style="width: 250px;">
                                            Comentarios
                                        </td>
                                    </tr>
                                    <tr class="Grid_Row">
                                        <td colspan="7">
                                            No se encontraron autoridades relacionados con la solicitud
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="AutoridadId" Visible="false" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:BoundField DataField="Puesto" HeaderText="Puesto" SortExpression="Puesto">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" SortExpression="Comentarios">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
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
                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar información de solicitud"
                        CssClass="Button_General" Width="200px" OnClick="GuardarButton_Click" />
                    <input class="Button_General" id="RegresarButton" onclick="document.location.href='opeBusquedaSolicitud.aspx';"
                        style="width: 125px;" type="button" value="Regresar" />
                </td>
            </tr>
        </table>
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
    <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
    <asp:HiddenField ID="hdnComentarioId" runat="server" />
</asp:Content>
