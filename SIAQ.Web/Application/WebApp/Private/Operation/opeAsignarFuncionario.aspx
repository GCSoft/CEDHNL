<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAsignarFuncionario.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.AsignarFuncionario" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <asp:UpdatePanel ID="AsignarUpdate" runat="server">
        <ContentTemplate>
            <table class="GeneralTable">
                <tr>
                    <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
	                    Asignar la solicitud a un funcionario de Quejas
                    </td>
		        </tr>
                <tr>
                    <td class="SubTitulo">Seleccione el funcionario a asignar a la solicitud.</td>
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
                                <td class="Nombre">Funcionario</td>
                                <td class="Espacio"></td>
				                <td class="Etiqueta"><asp:DropDownList ID="FuncionarioList" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
                                <td></td>
                                <td></td>
                                <td></td>
				                <td></td>
                            </tr>
                            <tr>
                                <td class="Botones" colspan="3">
                                    <br />
                                    <asp:Button ID="SaveButton" runat="server" Text="Asignar" CssClass="Button_General" width="125px" onclick="SaveButton_Click"/>&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="RegresarButton" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="RegresarButton_Click"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

            <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
        </ContentTemplate>
        <Triggers>
            
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
