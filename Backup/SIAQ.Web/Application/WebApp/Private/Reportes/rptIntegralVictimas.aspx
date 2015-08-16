<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="rptIntegralVictimas.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Reportes.rptIntegralVictimas1" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Reporte integral víctimas
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <td>
			<asp:Panel id="pnlFormulario" runat="server" Width="100%">
                <table border="0" style="width: 460px;">
					<tr>
						<td class="Etiqueta">Fecha Inicial</td>
                        <td class="Espacio"></td>
                        <td class="Campo">
							<wuc:wucCalendar ID="wucFechaInicial" runat="server" />
						</td>
                    </tr>
                    <tr>
                        <td class="Etiqueta">Fecha Final</td>
                        <td class="Espacio"></td>
                        <td class="Campo">
							<wuc:wucCalendar ID="wucFechaFinal" runat="server" />
						</td>
                    </tr>
                </table>
			</asp:Panel>
        </td>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="btnAceptar" runat="server" CssClass="Button_General" 
                                    onclick="btnAceptar_Click" Text="Aceptar" width="125px" />
                            </td>
                            <td style="height: 24px;"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
