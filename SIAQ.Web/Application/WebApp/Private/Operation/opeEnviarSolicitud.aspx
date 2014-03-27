<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeEnviarSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeEnviarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <asp:UpdatePanel ID="PageUpdate" runat="server">
        <ContentTemplate>
            <table class="GeneralTable">
                <tr>
                    <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
	                    Agregar documentos a la solicitud
                    </td>
		        </tr>
                <tr>
                    <td class="SubTitulo">Por favor confirme el envío de la solicitud, una vez enviada ya no se podrá modificar su contenido</td>
                </tr>
                <tr>
                    <td>
                        <table border="0" style="width: 100%">
                            <tr>
                                <td class="Especial">Solicitud Número</td>
                                <td class="Espacio"></td>
				                <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Calificación</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="CalificacionLabel" runat="server" Text=""></asp:Label></td>
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Estatus</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="EstatusaLabel" runat="server" Text=""></asp:Label></td>
                                <td class="Espacio"></td>
                                <td class="Nombre">Fecha de recepción</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Funcionario</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="FuncionarioLabel" runat="server" Text=""></asp:Label></td>
                                <td class="Espacio"></td>
                                <td class="Nombre">Fecha de asignación</td><td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Forma de contacto</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="ContactoLabel" runat="server" Text=""></asp:Label></td>
                                <td class="Espacio"></td>
                                <td class="Nombre">Fecha de inicio gestión</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="FechaGestionLabel" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Tipo de solicitud</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="TipoSolicitudLabel" runat="server" Text=""></asp:Label></td>
                                <td class="Espacio"></td>
                                <td class="Nombre">Última modificación</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="FechaModificacionLabel" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Observaciones (Recepción)</td>
                                <td class="Espacio"></td>
				                <td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Lugar de los hechos</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="LugarHechosLabel" runat="server" Text=""></asp:Label></td>
                                <td></td>
                                <td></td>
                                <td></td>
				                <td></td>
                            </tr>
                            <tr>
                                <td class="Nombre">Dirección de los hechos</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:Label ID="DireccionHechosLabel" runat="server" Text=""></asp:Label></td>
                                <td></td>
                                <td></td>
                                <td></td>
				                <td></td>
                            </tr>
                            <tr>
                                <td class="Botones" colspan="3">
                                    <br />
                                    <asp:Button ID="SendButton" runat="server" Text="Enviar solicitud" CssClass="Button_General" width="125px" onclick="SendButton_Click"/> &nbsp;&nbsp;&nbsp;
                                    <input class="Button_General" id="RegresarButton" onclick="document.location.href='opeDetalleSolicitud.aspx?s=<%= _SolicitudId %>';" style="width: 125px;" type="button" value="Regresar" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
