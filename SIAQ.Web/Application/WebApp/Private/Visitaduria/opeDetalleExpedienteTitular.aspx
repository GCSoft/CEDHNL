<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeDetalleExpedienteTitular.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeDetalleExpedienteTitular" %>

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
                <div id="SubMenuDivVisitador" runat="server">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="InformacionGeneralVisitadorButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png"
                                    runat="server" onclick="InformacionGeneralVisitadorButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="AprobarResolucionButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                                    runat="server" onclick="AprobarResolucionButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                <asp:ImageButton ID="AsignarVisitadorButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png"
                                    runat="server" onclick="AsignarVisitadorButton_Click"></asp:ImageButton>
                            </td>
                            <td>
                            </td>
                            <td style="width: 65px;">
                                &nbsp;</td>
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
                                Aprobar calificación
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
                        AutoGenerateColumns="False" Width="800px" DataKeyNames="CiudadanoId" 
                        onrowdatabound="gvCiudadanos_RowDataBound" onsorting="gvCiudadanos_Sorting">
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
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha nacimiento" SortExpression="Fecha nacimiento">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" SortExpression="Domicilio">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TelefonoPrincipal" HeaderText="Teléfono" SortExpression="Teléfono">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo">
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
        <tr>
            <td style="text-align: left;">
                Autoridades
            </td>
        </tr>
        <tr style="height: 3px;">
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGridAutoridades" runat="server" Width="100%">
                    <asp:GridView ID="gvAutoridades" runat="server" AllowPaging="false" AllowSorting="true"
                        AutoGenerateColumns="False" Width="800px" DataKeyNames="AutoridadId" 
                        onrowdatabound="gvAutoridades_RowDataBound" onsorting="gvAutoridades_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width: 228px;">
                                        Nombre
                                    </td>
                                    <td style="width: 220px;">
                                        Puesto
                                    </td>
                                    <td style="width: 142px;">
                                        Autoridad
                                    </td>
                                    <td style="width: 100px;">
                                        Comentarios
                                    </td>
                                    <td style="width: 100px;">
                                        Editar
                                    </td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="7">
                                        No se encontraron autoridades relacionados con el expediente
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
                            <asp:BoundField DataField="Autoridad" HeaderText="Autoridad" SortExpression="Autoridad">
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
                        <tr>
                            <td class="tdCeldaMiddleSpace">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdCeldaMiddleSpace">
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
                                <CKEditor:CKEditorControl ID="txtAsuntoSolicitud" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
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
                                    CssClass="Button_General" Width="200px" onclick="cmdGuardar_Click" />
                            </td>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="cmdRegresar" runat="server" Text="Regresar" CssClass="Button_General"
                                    Width="125px" onclick="cmdRegresar_Click" />
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
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
    <asp:HiddenField ID="hdnExpedienteId" runat="server" />
</asp:Content>
