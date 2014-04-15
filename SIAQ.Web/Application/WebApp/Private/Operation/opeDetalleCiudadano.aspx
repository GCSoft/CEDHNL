<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeDetalleCiudadano.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeDetalleCiudadano" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Include/WebUserControls/wucCalendar.ascx" TagName="calendar"
    TagPrefix="cal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <script type="text/javascript">

        function CheckNumeric(e) {

            if (window.event) // IE 
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8) {
                    event.returnValue = false;
                    return false;

                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8) {
                    e.preventDefault();
                    return false;

                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                Detalle ciudadano
            </td>
        </tr>
        <tr>
            <td class="SubTitulo">
                <asp:Label ID="Label2" runat="server" Text="Detalle de los datos del ciudadano"></asp:Label>
            </td>
        </tr>
        <tr style="height: 2px;">
            <td colspan="13">
            </td>
        </tr>
        <tr>
            <td style="background-color: #CCCCCC; text-align: left;">
                Información general
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormularioInfoGral" runat="server" Visible="true" Width="100%">
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
                                Nombre
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Escolaridad
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblEscolaridad" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Apellido paterno
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblApellidoPaterno" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Estado civil
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblEstadoCivil" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Apellido materno
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblApellidoMaterno" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Teléfono principal
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblTelefonoPrincipal" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Sexo
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblSexo" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Otro teléfono
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblOtroTelefono" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Fecha de nacimiento
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblFechaNacimiento" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Correo electrónico
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblCorreoElectronico" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Nacionalidad
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblNacionalidad" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Dependientes económicos
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblDependientesEconomicos" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Ocupación
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblOcupacion" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Forma de enterarse de la CEDH
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblFormaEnterarse" runat="server" Text=""></asp:Label>
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
            <td style="background-color: #CCCCCC; text-align: left;">
                Domicilio
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormularioDomicilio" runat="server" Visible="true" Width="100%">
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
                                País
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblPais" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Nombre calle
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblCalle" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Estado
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Núm exterior
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblNoExterior" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Ciudad
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblCiudad" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Núm interior
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblNumInterior" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Colonia
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblColonia" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Años residiendo en NL
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="lblAniosResidiendoNL" runat="server" Text=""></asp:Label>
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
            <td style="background-color: #CCCCCC; text-align: left;">
                Solicitudes de intervención
            </td>
        </tr>
        <tr style="height: 3px;">
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSollicitudesIntervencion" runat="server" Width="100%">
                    <asp:GridView ID="gvSollicitudesIntervencion" runat="server" AllowPaging="false"
                        AllowSorting="true" AutoGenerateColumns="False" Width="800px" 
                        DataKeyNames="SolicitudId"
                        onrowdatabound="gvSollicitudesIntervencion_RowDataBound" 
                        onsorting="gvSollicitudesIntervencion_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width: 100px;">
                                        Solicitud
                                    </td>
                                    <td style="width: 200px;">
                                        Fecha
                                    </td>
                                    <td style="width: 100px;">
                                        Participa como
                                    </td>
                                    <td style="width: 100px;">
                                        Calificación
                                    </td>
                                    <td style="width: 100px;">
                                        Expediente
                                    </td>
                                    <td style="width: 100px;">
                                        Estatus
                                    </td>
                                    <td style="width: 100px;">
                                        Tipo
                                    </td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="7">
                                        No se encontraron solicitudes relacionados al ciudadano seleccionado
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="SolicitudId" Visible="false" />
                            <asp:BoundField DataField="Solicitud" HeaderText="Solicitud" SortExpression="Solicitud">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ParticipaComo" HeaderText="Participa como" SortExpression="ParticipaComo">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Calificacion" HeaderText="Calificación" SortExpression="Calificacion">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NumeroExpediente" HeaderText="Expediente" SortExpression="NumeroExpediente">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TipoSolicitud" HeaderText="Tipo" SortExpression="TipoSolicitud">
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
            <td style="background-color: #CCCCCC; text-align: left;">
                Visitas a la CEDH
            </td>
        </tr>
        <tr style="height: 3px;">
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlVisitasCEDH" runat="server" Width="100%">
                    <asp:GridView ID="gvVisitasCEDH" runat="server" AllowPaging="false" AllowSorting="true"
                        AutoGenerateColumns="False" Width="800px" DataKeyNames="VisitaId" 
                        onrowdatabound="gvVisitasCEDH_RowDataBound" onsorting="gvVisitasCEDH_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width: 100px;">
                                        Fecha
                                    </td>
                                    <td style="width: 200px;">
                                        Funcionario visitado
                                    </td>
                                    <td style="width: 200px;">
                                        Área visitada 
                                    </td>
                                    <td style="width: 300px;">
                                        Motivo de la visita
                                    </td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="4">
                                        No se encontraron visitas relacionados al ciudadano seleccionado
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="VisitaId" Visible="false">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FuncionarioVisitado" HeaderText="Funcionario visitado" SortExpression="FuncionarioVisitado">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AreaVisitada" HeaderText="Area visitada" SortExpression="AreaVisitada">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Observaciones" HeaderText="Motivo de la visita" SortExpression="Observaciones">
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
            <td style="background-color: #CCCCCC; text-align: left;">
                Documentos
            </td>
        </tr>
        <tr style="height: 3px;">
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDocumentos" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
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
                                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General"
                                    Width="125px" onclick="btnRegresar_Click" />
                            </td>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                
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
        <tr class="trFilaFooter">
            <td>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnCiudadanoId" runat="server" />
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
</asp:Content>
