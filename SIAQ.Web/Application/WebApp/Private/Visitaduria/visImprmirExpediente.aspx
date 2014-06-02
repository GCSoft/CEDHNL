<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visImprmirExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.visImprmirExpediente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Imprimir expediente - Visitadurías</title>
        <link rel="shortcut icon" href="../../../../Include/Image/Content/Web/favicon.ico" type="image/png" />
        <link href="../../../../Include/Style/Content.css" rel="Stylesheet" type="text/css" />
        <link href="../../../../Include/Style/Control.css" rel="Stylesheet" type="text/css" />
        <link href="../../../../Include/Style/MasterPage.css" rel="Stylesheet" type="text/css" />
        <link href="../../../../Include/Style/Table.css" rel="Stylesheet" type="text/css" />
        <link href="../../../../Include/Style/Text.css" rel="Stylesheet" type="text/css" />
        <link href="../../../../Include/Style/Wait.css" rel="Stylesheet" type="text/css" />
        <link href="../../../../Include/Javascript/TinyBox/TinyBox.css" rel="Stylesheet" type="text/css" />
        <link href="../../../../Include/Javascript/ToolTip/ToolTip.css" rel="Stylesheet" type="text/css" />
    </head>

    <body>
        <form id="form1" runat="server">
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
                            <asp:GridView AllowPaging="false" AllowSorting="false" ID="CiudadanosGrid" runat="server"
                                AutoGenerateColumns="False" Width="100%" DataKeyNames="CiudadanoId">
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
                        RepeatDirection="Horizontal" RepeatLayout="Table" runat="server">
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
            </div>
        </form>
    </body>
</html>
