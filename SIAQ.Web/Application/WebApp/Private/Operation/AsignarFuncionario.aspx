<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="AsignarFuncionario.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.AsignarFuncionario" %>

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
                                <td class="Especial">Solicitud número</td>
                                <td class="Espacio"></td>
                                <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
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
