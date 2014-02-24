<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarCiudadanosSol.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarCiudadanosSol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
			<td class="tdCeldaTituloEncabezado">
				Agregar ciudadanos a la solicitud
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Solicitud número:</td>
                        <td class="tdCeldaItem"><asp:Label ID="lblNumSolicitud" runat="server" Text="20202"></asp:Label></td>
                        <td></td>
                    </tr>
                    <tr style="height:30px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:TextBox ID="txtAgrega" runat="server" CssClass="Textbox_General" Width="210px"></asp:TextBox></td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>   
                </table>
            </asp:Panel>
         </td>
      </tr>
    </table>
</asp:Content>
