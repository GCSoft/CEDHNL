<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeDetalleRecomendacionDirector.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.opeDetalleRecomendacionDirector" %>

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
                Buscar solicitud
            </td>
        </tr>
        <tr>
            <td class="SubTitulo">
                <asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para buscar la solicitud."></asp:Label>
            </td>
        </tr>
        <tr style="height: 2px;">
            <td colspan="13">
            </td>
        </tr>
        <tr>
            <td>
                <div id="SubMenuDiv">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="InformacionGeneralButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png"
                                    runat="server" OnClick="InformacionGeneralButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="AsignarDefensorButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                                    runat="server" onclick="AsignarDefensorButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="ConfirmarCierreButton" ImageUrl="/Include/Image/Icon/EnviarIcon.png"
                                    runat="server" onclick="ConfirmarCierreButton_Click"></asp:ImageButton>
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
                                Asignar defensor
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px; font-size: 10px;">
                                Confirmar cierre de expediente
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
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
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
                            <td class="Etiqueta">
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
                                Defensor
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="DefensorLabel" runat="server"></asp:Label>
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
                                Núm. solicitud
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="NumSolicitudLabel" runat="server" Text=""></asp:Label>
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
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
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
                                Observaciones
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Observaciones" colspan="5">
                                <asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo" colspan="5">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo" colspan="5">
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
                Recomendaciones del expediente
            </td>
        </tr>
        <tr style="height: 3px;">
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                    <asp:GridView ID="gvRecomendaciones" runat="server" AllowPaging="false" AllowSorting="true"
                        AutoGenerateColumns="False" Width="800px" DataKeyNames="RecomendacionId" OnRowCommand="gvRecomendaciones_RowCommand"
                        OnRowDataBound="gvRecomendaciones_RowDataBound" OnSorting="gvRecomendaciones_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width: 60px;">
                                        Recomendación
                                    </td>
                                    <td style="width: 130px;">
                                        Autoridad
                                    </td>
                                    <td style="width: 80px;">
                                        Puesto
                                    </td>
                                    <td style="width: 130px;">
                                        Última notificación
                                    </td>
                                    <td style="width: 140px;">
                                        Estatus
                                    </td>
                                    <td style="width: 80px">
                                        Editar
                                    </td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">
                                        No se encontraron recomendaciones registradas en el sistema
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField HeaderText="Recomendación" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px"
                                DataField="RecomendacionId" SortExpression="RecomendacionId"></asp:BoundField>
                            <asp:BoundField HeaderText="Autoridad" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="130px"
                                DataField="Autoridad" SortExpression="Autoridad"></asp:BoundField>
                            <asp:BoundField HeaderText="Puesto" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px"
                                DataField="Puesto" SortExpression="Puesto"></asp:BoundField>
                            <asp:BoundField HeaderText="Última modificación" ItemStyle-HorizontalAlign="Left"
                                ItemStyle-Width="130px" DataField="UltimaModificacion" SortExpression="UltimaModificacion">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Estatus" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px"
                                DataField="Estatus" SortExpression="Estatus"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument='<%#Eval("RecomendacionId")%>' CommandName="Editar"
                                        ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
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
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDocumentos" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="text-align: left;">
                                Documentos anexos
                            </td>
                        </tr>
                        <tr style="height: 3px;">
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:ImageButton ID="imgWord" runat="server" ImageUrl="~/Include/Image/Web/word.png">
                                </asp:ImageButton>
                            </td>
                            <td style="text-align: left;">
                                <asp:ImageButton ID="imgPdf" runat="server" ImageUrl="~/Include/Image/Web/pdf.png">
                                </asp:ImageButton>
                            </td>
                            <td style="text-align: left;">
                                <asp:ImageButton ID="imgImages" runat="server" ImageUrl="~/Include/Image/Web/imgs.png">
                                </asp:ImageButton>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdCeldaLeyendaItemFondoBlanco">
                                Dictamen médico
                            </td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">
                                Anotaciones
                            </td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">
                                Foto 1
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 3px;">
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left;">
                                Asunto de la solicitud
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="background-color: Gray;">
                                Barra de Herramientas
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="background-color: Gray;">
                                <asp:TextBox ID="txtAsunto" runat="server" TextMode="MultiLine" CssClass="Textarea_General"
                                    Width="800px"></asp:TextBox>
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
                                <asp:Button ID="cmdGuardar" runat="server" Text="Guardar información del expediente"
                                    CssClass="Button_General" Width="200px" OnClick="cmdGuardar_Click" />
                            </td>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="cmdRegresar" runat="server" Text="Regresar" CssClass="Button_General"
                                    Width="125px" OnClick="cmdRegresar_Click" />
                            </td>
                            <td style="height: 24px; width: 530px;">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter">
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
