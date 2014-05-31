<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="visDetalleExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.visDetalleExpediente" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Detalle de Solictud
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label2" runat="server" Text="Seleccione las opciones disponibles para capturar la información de la solicitud."></asp:Label>
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
            Asignar visitador
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="CiudadanoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AcuerdoButton" ImageUrl="/Include/Image/Icon/AcuerdoIcon.png" runat="server" OnClick="AcuerdoButton_Click"></asp:ImageButton><br />
            Acuerdo de calificación definitiva
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="CalificarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DiligenciasButton" ImageUrl="/Include/Image/Icon/DiligenciaIcon.png" runat="server" OnClick="DiligenciasButton_Click"></asp:ImageButton><br />
            Diligencias
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="DocumentoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DocumentoButton" ImageUrl="/Include/Image/Icon/DocumentoIcon.png" runat="server" OnClick="DocumentoButton_Click"></asp:ImageButton><br />
            Agregar documentos
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="AutoridadPanel" runat="server" Visible="true">
            <asp:ImageButton ID="SeguimientoButton" ImageUrl="/Include/Image/Icon/SeguimientoIcon.png" runat="server" OnClick="SeguimientoButton_Click"></asp:ImageButton><br />
            Seguimiento
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="DiligenciasPanel" runat="server" Visible="true">
            <asp:ImageButton ID="ComparecenciaPanel" ImageUrl="/Include/Image/Icon/ComparecenciaIcon.png" runat="server" OnClick="ComparecenciaPanel_Click"></asp:ImageButton><br />
            Comparecencia
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="IndicadorPanel" runat="server" Visible="true">
            <asp:ImageButton ID="ResolucionButton" ImageUrl="/Include/Image/Icon/IndicadorIcon.png" runat="server" OnClick="ResolucionButton_Click"></asp:ImageButton><br />
            Resolución
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="Panel1" runat="server" Visible="true">
            <asp:ImageButton ID="RecomendacionButton" ImageUrl="/Include/Image/Icon/DocumentoIcon.png" runat="server" OnClick="RecomendacionButton_Click"></asp:ImageButton><br />
            Recomendaciones
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="ImprimirPanel" runat="server" Visible="true">
            <asp:ImageButton ID="ImprimirButton" ImageUrl="/Include/Image/Icon/ImprimirIcon.png" runat="server" onclick="ImprimirButton_Click"></asp:ImageButton><br />
            Imprimir
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="EnviarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="EnviarButton" ImageUrl="/Include/Image/Icon/EnviarIcon.png" runat="server" OnClick="EnviarButton_Click"></asp:ImageButton><br />
            Enviar expediente
        </asp:Panel>
    </div>
</asp:Content>
