<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeInicio.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeInicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Pantalla de inicio
			</td>
		</tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr style="height:20px;"><td colspan="9"></td></tr>
                        <tr>
                            <td style="width:11%;"></td>
                            <td style="width:11%;"><asp:ImageButton ID="imgRegistrarSol" runat="server" ImageUrl="~/Include/Image/Web/Registro.jpg" onclick="imgRegistrarSol_Click"></asp:ImageButton></td>
                            <td style="width:11%;"></td>
                            <td style="width:11%;"><asp:ImageButton ID="imgRegistrarVis" runat="server" ImageUrl="~/Include/Image/Web/Registro.jpg" onclick="imgRegistrarVis_Click"></asp:ImageButton></td>
                            <td style="width:11%;"></td>
                            <td style="width:11%;"><asp:ImageButton ID="imgBuscarSol" runat="server" ImageUrl="~/Include/Image/Web/Buscar.jpg" onclick="imgBuscarSol_Click"></asp:ImageButton></td>
                            <td style="width:11%;"></td>
                            <td style="width:11%;"><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Include/Image/Web/img_x.jpg"></asp:ImageButton></td>
                            <td style="width:11%;"></td>
                        </tr>
                        <tr style="height:20px;"><td colspan="9"></td></tr>
                        <tr>
                            <td style="width:11%;"></td>
                            <td style="width:11%; font-size:10px;">Registrar Solicitud</td>
                            <td style="width:11%;"></td>
                            <td style="width:11%; font-size:10px;">Registrar visita</td>
                            <td style="width:11%;"></td>
                            <td style="width:11%; font-size:10px;">Buscar solicitud</td>
                            <td style="width:11%;"></td>
                            <td style="width:11%;"></td>
                            <td style="width:11%;"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      </table>
</asp:Content>
