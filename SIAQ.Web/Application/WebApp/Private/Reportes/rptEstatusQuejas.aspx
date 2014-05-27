<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="rptEstatusQuejas.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Reportes.rptEstatusQuejas1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Reportes - Estatus de Quejas
            </td>
		</tr>
        <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlBotones" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" /></td>
                            <td style="height:24px; "></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    Aqui va el Crystal
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
    </table>
</asp:Content>
