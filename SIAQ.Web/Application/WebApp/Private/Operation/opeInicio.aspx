<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeInicio.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="Tamanoletra" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Recepción
			</td>
		</tr>
        <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr style="height:20px;"><td colspan="9"></td></tr>
                        <tr>
                            <td style="width:10%;"></td>
                            <td style="width:20%;"><asp:ImageButton ID="imgRegistrarSol" runat="server" ImageUrl="~/Include/Image/Icon/RegistrarSolicitud.png" onclick="imgRegistrarSol_Click"></asp:ImageButton></td>
                            <td style="width:10%;"></td>
                            <td style="width:20%;"><asp:ImageButton ID="imgRegistrarVis" runat="server" ImageUrl="~/Include/Image/Icon/RegistrarVisita.png" onclick="imgRegistrarVis_Click"></asp:ImageButton></td>
                            <td style="width:10%;"></td>
                            <td style="width:20%;"><asp:ImageButton ID="imgBuscarSol" runat="server" ImageUrl="~/Include/Image/Icon/BuscarSolicitud.png" onclick="imgBuscarSol_Click"></asp:ImageButton></td>
                            <td style="width:10%;"></td>
                        </tr>
                        <tr>
                            <td style="width:10%;"></td>
                            <td style="width:20%;">Registrar solicitud</td>
                            <td style="width:10%;"></td>
                            <td style="width:20%;">Registrar visita</td>
                            <td style="width:10%;"></td>
                            <td style="width:20%;">Buscar solicitud</asp:ImageButton></td>
                            <td style="width:10%;"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      </table>
</asp:Content>
