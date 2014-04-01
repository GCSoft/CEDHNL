<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeDiligenciaRecomendacion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeDiligenciaRecomendacion" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Include/WebUserControls/wucCalendar.ascx" TagName="caldenar"
    TagPrefix="cln" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <script type="text/javascript">

        // Funciones del programador
        function NumbersValidator(e) {

            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return (tecla > 47 && tecla < 58);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                Diligencias
            </td>
        </tr>
        <tr>
            <td class="SubTitulo">
                <asp:Label ID="Label2" runat="server" Text="En esta sección puede registrar diligencias o dar de alta nuevas diligencias relacionadas a un expediente."></asp:Label>
            </td>
        </tr>
        <tr style="height: 2px;">
            <td colspan="13">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormularioSecretaria" runat="server" Visible="true" Width="100%">
                    <table class="SolicitudTable">
                        <tr>
                            <td class="Especial">
                                Expediente número
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label>
                            </td>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Fecha de registro
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="FechaRegistroLabel" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Visitador que atienda
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="VisitadorAtiendeLabel" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Visitador que ejecuta
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:DropDownList ID="ddlVisitadorEjecuta" runat="server" Width="216px" CssClass="DropDownList_General">
                                </asp:DropDownList>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Fecha de la diligencia
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <cln:caldenar ID="calFecha" runat="server" />
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Tipo de diligencia
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:DropDownList ID="ddlTipoDiligencia" runat="server" Width="216px" CssClass="DropDownList_General">
                                </asp:DropDownList>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Lugar de diligencia
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:DropDownList ID="ddlLugarDiligencia" runat="server" Width="216px" CssClass="DropDownList_General">
                                </asp:DropDownList>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Detalle
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:TextBox ID="txtCampo" runat="server" CssClass="Textarea_General" TextMode="MultiLine"
                                    Width="210px"></asp:TextBox>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Solicitada por
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:TextBox ID="txtSolicitadaPor" runat="server" CssClass="Textbox_General" Width="210px"></asp:TextBox>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Resultado
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:TextBox ID="txtResultado" runat="server" CssClass="Textarea_General" TextMode="MultiLine"
                                    Width="210px"></asp:TextBox>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General"
                                    Width="125px" OnClick="btnGuardar_Click" />
                            </td>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General"
                                    Width="125px" OnClick="btnRegresar_Click" />
                            </td>
                            <td style="height: 24px; width: 530px;">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                Diligencias registradas para este expediente
            </td>
        </tr>
        <tr style="height: 3px;">
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDiligenciaRecomendacion" runat="server" Width="100%" Visible="false">
                    <asp:GridView ID="gvDiligenciasRecomendacion" runat="server" 
                        AllowPaging="false" AllowSorting="true"
                        AutoGenerateColumns="False" Width="800px" DataKeyNames="DiligenciaId" 
                        onrowcommand="gvDiligenciasRecomendacion_RowCommand" 
                        onrowdatabound="gvDiligenciasRecomendacion_RowDataBound" 
                        onsorting="gvDiligenciasRecomendacion_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width: 150px;">
                                        Fecha
                                    </td>
                                    <td style="width: 220px;">
                                        Visitador que ejecuta
                                    </td>
                                    <td style="width: 120px;">
                                        Tipo
                                    </td>
                                    <td style="width: 200px;">
                                        Detalle
                                    </td>
                                    <td style="width: 100px;">
                                        Editar
                                    </td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="7">
                                        No se encontraron diligencias registradas en esta recomendación
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="DiligenciaId" Visible="false" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                            <asp:BoundField DataField="NombreVisitadorEjecuta" HeaderText="Visitador que ejecuta"
                                SortExpression="NombreVisitadorEjecuta"></asp:BoundField>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo"></asp:BoundField>
                            <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="Detalle">
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Borrar"
                                        ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RecomendacionId" Visible="false" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace">
            </td>
        </tr>
        <tr class="trFilaFooter">
            <td>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
    <asp:HiddenField ID="hdnRecomendacionId" runat="server" />
    <asp:HiddenField ID="hdnDiligenciaId" runat="server" />
</asp:Content>
