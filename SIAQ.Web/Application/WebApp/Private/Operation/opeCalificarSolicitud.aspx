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
                            En esta pantalla se puede especificar la calificación de la solicitud para determinar qué información complementaria debe capturarse en las demás pantallas.
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
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" style="text-align: left">
                    <tr>
                        <td class="AnchoTablaCalSol">Calificación</td>
                        <td>
                            <asp:DropDownList AutoPostBack="true" ID="CalificacionList" OnSelectedIndexChanged="CalificacionList_SelectedIndexChanged" runat="server" Width="214px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="CeldaCierre" runat="server" visible="false">
                        <td class="AnchoTablaCalSol">Cierre de orientación</td>
                        <td>
                            <asp:DropDownList AutoPostBack="true" ID="CierreList" Width="214px" runat="server" OnSelectedIndexChanged="CierreList_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="CeldaCanalizado" runat="server" visible="false">
                        <td class="AnchoTablaCalSol">Canalizado a</td>
                        <td>
                            <asp:DropDownList ID="CanalizadoList" Width="214px" runat="server"></asp:DropDownList>&nbsp;&nbsp;
                            <asp:Button ID="AgregarButton" runat="server" Text="Agregar" onclick="AgregarButton_Click" />
                        </td>
                    </tr>
                    <tr id="CeldaGrid" runat="server" visible="false">
                        <td class="AnchoTablaCalSol"></td>
                        <td>
                            <asp:GridView AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" CssClass="GridDinamico"
                                DataKeyNames="TipoOrientacionId" ID="CanalizacionGrid" runat="server" ShowHeader="false">
                                <RowStyle CssClass="Row" />
                                <EditRowStyle Wrap="True" />
                                <AlternatingRowStyle CssClass="Alternating" />
                                <Columns>
                                    <asp:BoundField DataField="Nombre" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="179"></asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="EliminarButton" CommandArgument='<%#Eval("TipoOrientacionId")%>' CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" OnClientClick="return confirm('¿En realidad desea eliminar esta canalización?');" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="28" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="CeldaFundamento">
                        <td class="AnchoTablaCalSol">Fundamento</td>
                        <td>
                            <asp:TextBox ID="FundamentoBox" runat="server" CssClass="Textbox_General" TextMode="MultiLine" Height="100px" Width="360px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0">
                    <tr>
                        <td style="text-align: left; width: 151px;">
                            <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="Button_General" Width="125px" OnClick="GuardarCalificacionSol_Click" />
                        </td>
                        <td style="text-align: left;">
                            <asp:Button ID="btnCancelar" runat="server" Text="Regresar" CssClass="Button_General" Width="125px" onclick="btnCancelar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
</asp:Content>
