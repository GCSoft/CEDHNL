<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="rptTema.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Reportes.rptTema1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">Reportes - Temas</td>
        </tr>
        <tr>
            <td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para buscar la solicitud."></asp:Label></td>
        </tr>
        <tr>
            <td>
				<asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" style="width: 460px">
						<tr>
                            <td class="Etiqueta">Estatus</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:DropDownList ID="cboEstatus" runat="server" CssClass="DropDownList_General" Width="216px" ></asp:DropDownList></td>
                        </tr>
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
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 24px; text-align: left; width: 130px;">
								<asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" onclick="btnBuscar_Click" />
							</td>
                            <td style="height: 24px;"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
    </table>
</asp:Content>
