<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segDetalleExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segDetalleExpediente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Detalle del expediente
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" style="text-align:left; font-size:11px" width="100%">
                        <tr>
                            <td colspan="3">Proporcione la información solicitada para dar seguimiento a las recomendaciones del expediente </td>
                        </tr>
					</table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
        <asp:HiddenField ID="hddSort" runat="server" Value="Nombre" />
    </table>
</asp:Content>
