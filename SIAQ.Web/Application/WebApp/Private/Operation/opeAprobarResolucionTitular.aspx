﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAprobarResolucionTitular.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAprobarResolucionTitular" %>

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
                Aprobar resolución
            </td>
        </tr>
        <tr>
            <td class="SubTitulo">
                <asp:Label ID="Label2" runat="server" Text="Indique si la resolución del expediente es aprobada o no dependiendo de la información proporcionada"></asp:Label>
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
                                Tipo de resolución
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="TipoResolucionLabel" runat="server" Text=""></asp:Label>
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
                            <td class="Etiqueta">
                                <asp:Label ID="VisitadorLabel" runat="server" Text=""></asp:Label> 
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Fecha de inicio de gestión
                            </td>
                            <td class="Espacio">

                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="FechaInicioGestionLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Núm de recomendación
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:TextBox ID="NumRecomendacionText" runat="server" Width="200px" CssClass="Textbox_General"></asp:TextBox>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                                Fecha de resolución
                            </td>
                            <td class="Espacio">

                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="FechaResolucionLabel" runat="server" Text=""></asp:Label>
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
                                <asp:Button ID="btnAprobarResolucion" runat="server" Text="Aprobar resolución"
                                    CssClass="Button_General" Width="125px" onclick="btnAprobarResolucion_Click" 
                                    />
                            </td>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="btnRechazarResolucion" runat="server" 
                                    Text="Rechazar resolución" CssClass="Button_General"
                                    Width="125px" onclick="btnRechazarResolucion_Click" />
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
            <td style="background-color:#CCCCCC; text-align:left;"">
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
                        AutoGenerateColumns="False" Width="800px" DataKeyNames="CiudadanoId" 
                        onrowcommand="gvCiudadanos_RowCommand" 
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
                        onrowcommand="gvAutoridades_RowCommand" 
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
        <tr class="trFilaFooter">
            <td>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
    <asp:HiddenField ID="hdnExpedienteId" runat="server" />
</asp:Content>
