<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="opeSolicitudPaginaImpresion.aspx.cs"
    Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeSolicitudPaginaImpresion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIAQ</title>
   <meta content="GCSoft - Web Project Creator BETA 1.0" name="autor" />
   <link rel="shortcut icon" href="~/Include/Image/Content/Web/favicon.ico" type="image/png" />
   <link href="~/Include/Style/Content.css" rel="Stylesheet" type="text/css" />
   <link href="~/Include/Style/Control.css" rel="Stylesheet" type="text/css" />
   <link href="~/Include/Style/MasterPage.css" rel="Stylesheet" type="text/css" />
   <link href="~/Include/Style/Table.css" rel="Stylesheet" type="text/css" />
   <link href="~/Include/Style/Text.css" rel="Stylesheet" type="text/css" />
   <link href="~/Include/Style/Wait.css" rel="Stylesheet" type="text/css" />
   <link href="~/Include/Javascript/TinyBox/TinyBox.css" rel="Stylesheet" type="text/css" />
   <link href="~/Include/Javascript/ToolTip/ToolTip.css" rel="Stylesheet" type="text/css" />

   <script src="../../../../Include/Javascript/TinyBox/TinyBox.js" type="text/javascript"></script>
   <script src="../../../../Include/Javascript/ToolTip/ToolTip.js" type="text/javascript"></script>
   <script language="javascript" type="text/javascript" src="../../../../Include/Javascript/GCSoft/GCSoft.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="TituloPaginaDiv">
            <table class="GeneralTable">
                <tr>
                    <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                        Detalle de Solictud
                    </td>
                </tr>
                <tr>
                    <td class="SubTitulo">
                        &nbsp;
                    </td>
                </tr>
            </table>
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
                    <td class="Etiqueta" colspan="5">
                        <asp:Label ID="LugarHechosLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="Nombre">
                        Dirección de los hechos
                    </td>
                    <td class="Espacio">
                    </td>
                    <td class="Etiqueta" colspan="5">
                        <asp:Label ID="DireccionHechosLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="tdCeldaMiddleSpace">
                    </td>
                </tr>
            </table>
            <br />
            <!-- Repeater para los comentarios -->
            <div class="SolicitudComentarioDiv">
                <div style="text-align: left;">
                    Comentarios &nbsp;&nbsp;
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
                        <asp:Button ID="btnRegresar" runat="server" CssClass="Button_General" 
                            Text="Regresar" Width="125px" onclick="btnRegresar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
    </div>
    </form>
</body>
</html>
