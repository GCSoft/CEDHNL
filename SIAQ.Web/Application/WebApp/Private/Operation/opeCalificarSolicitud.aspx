<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeCalificarSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeCalificarSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                            Calificar Solicitud
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td class="SubTitulo">
                            Agregue aquellos documentos que sirvan para complementar la información de la solicitud
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="CalificarTable">
                    <tr class="trFilaItem">
                        <td class="Especial" style="width: 110px;">
                            Solicitud Número
                        </td>
                        <td class="tdCeldaItem">
                            <asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 30px;" class="SubTitulo">
                            Especifica la calificación de la solicitud
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" style="text-align: left">
                    <tr>
                        <td class="AnchoTablaCalSol">
                            Calificación
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCalificacion" Width="214px" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="AnchoTablaCalSol">
                            Cierre de orientación
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCierre" Width="214px" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="Orientacion_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="CeldaCanalizado" runat="server" visible="false">
                        <td class="AnchoTablaCalSol">
                            Canalizado a
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCanalizado" Width="214px" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="CeldaFundamento" runat="server" visible="false">
                        <td class="AnchoTablaCalSol">
                            Fundamento
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxFundamento" runat="server" CssClass="Textbox_General" TextMode="MultiLine"
                                Height="100px" Width="360px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0">
                    <tr>
                        <td style="text-align: left; width: 151px;">
                            <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="Button_General"
                                Width="125px" OnClick="GuardarCalificacionSol_Click" />
                        </td>
                        <td style="text-align: left;">
                            <asp:Button ID="btnCancelar" runat="server" Text="Regresar" CssClass="Button_General"
                                Width="125px" onclick="btnCancelar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
</asp:Content>
