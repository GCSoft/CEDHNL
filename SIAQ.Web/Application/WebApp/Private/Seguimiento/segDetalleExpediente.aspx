<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segDetalleExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segDetalleExpediente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	<script language="javascript" type="text/javascript">
		
		function ImprimirExpediente() {
			var ExpedienteId = 0;

			ExpedienteId = document.getElementById("<%= ExpedienteIdHidden.ClientID %>");

			window.open("visImprmirExpediente.aspx?E=" + ExpedienteId.Value, "ImprimirExpediente", "");
		}

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Detalle de Expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label2" runat="server" Text="Proporcione la información solicitada para dar seguimiento a las recomendaciones del expediente."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="SubMenuDiv">
        <asp:Panel CssClass="IconoPanel" ID="InformacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="InformacionGeneralButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png" runat="server" OnClick="InformacionGeneralButton_Click"></asp:ImageButton><br />
            Información general
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="AsignarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AsignarButton" ImageUrl="/Include/Image/Icon/AsignarIcon.png" runat="server" OnClick="AsignarButton_Click"></asp:ImageButton><br />
            Asignar defensor
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="SeguimientoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="SeguimientoButton" ImageUrl="/Include/Image/Icon/SeguimientoIcon.png" runat="server" OnClick="SeguimientoButton_Click"></asp:ImageButton><br />
            Seguimiento
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="NotificacionesPanel" runat="server" Visible="true">
            <asp:ImageButton ID="NotificacionesButton" ImageUrl="/Include/Image/Icon/NotificacionIcon.png" runat="server" OnClick="NotificacionesButton_Click"></asp:ImageButton><br />
            Notificaciones
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="DiligenciaPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DiligenciasButton" ImageUrl="/Include/Image/Icon/DiligenciaIcon.png" runat="server" OnClick="DiligenciasButton_Click"></asp:ImageButton><br />
            Diligencias
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="CerrarExpedientePanel" runat="server" Visible="true">
            <asp:ImageButton ID="CerrarExpedienteButton" ImageUrl="/Include/Image/Icon/CerrarExpedienteIcon.png" runat="server" OnClick="CerrarExpedienteButton_Click"></asp:ImageButton><br />
            Cerrar Expediente
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="ConfirmarCierreExpedientePanel" runat="server" Visible="true">
            <asp:ImageButton ID="ConfirmarCierreExpedienteButton" ImageUrl="/Include/Image/Icon/ConfirmacionCierreIcon.png" runat="server" OnClick="ConfirmarCierreExpedienteButton_Click"></asp:ImageButton><br />
            Confirmar Cierre de Expediente
        </asp:Panel>
    </div>

	<div id="InformacionDiv">
        
        <!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

    </div>

	<asp:HiddenField ID="EstatusIdHidden" runat="server" Value="0"  />
	<asp:HiddenField ID="ExpedienteIdHidden" runat="server" Value="0"  />
	<asp:HiddenField ID="FuncionarioIdHidden" runat="server" Value="0"  />
	<asp:HiddenField ID="Sender" runat="server" Value=""  />

</asp:Content>
