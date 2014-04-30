<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeBusquedaExpedientes.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeBusquedaExpedientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                Búsqueda de Expedientes
            </td>
        </tr>
        <tr>
            <td class="SubTitulo" align="left">
                <asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para realizar la búsqueda"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaMiddleSpace_Title">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
                    <table border="0" style="width: 460px">
                        <tr>
                            <td class="Etiqueta">
                                Núm. de expediente
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:TextBox ID="txtNumeroExpediente" runat="server" CssClass="Textbox_General" Width="177px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="Etiqueta">
                                Quejoso
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:TextBox ID="txtQuejoso" runat="server" CssClass="Textbox_General" Width="177px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="Etiqueta">
                                Estatus
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="DropDownList_General"
                                    Width="183px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="Etiqueta">
                                Visitador
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:DropDownList ID="ddlVisitador" runat="server" CssClass="DropDownList_General"
                                    Width="183px">
                                </asp:DropDownList>
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
                <asp:Panel ID="pnlBotones" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General"
                                    Width="125px" OnClick="btnBuscar_Click" />
                            </td>
                            <td style="height: 24px; text-align: left; width: 130px;">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="Button_General"
                                    Width="125px" OnClick="btnCancelar_Click" />
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
            <td>
                <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                    <asp:GridView ID="gvApps" runat="server" AllowPaging="false" AllowSorting="true"
                        AutoGenerateColumns="False" Width="100%" DataKeyNames="ExpedienteId,Numero"
                        OnRowDataBound="gvApps_RowDataBound" OnSorting="gvApps_Sorting" OnRowCommand="gvApps_RowCommand">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width: 100px;">
                                        Expediente
                                    </td>
                                    <td style="width: 150px;">
                                        Asunto
                                    </td>
                                    <td style="width: 100px;">
                                        Fecha Visitadurías
                                    </td>
                                    <td style="width: 100px;">
                                        Visitador
                                    </td>
                                    <td style="width: 100px;">
                                        Estatus
                                    </td>
                                    <td style="width: 100px;">
                                        Quejosos
                                    </td>
                                    <td style="width: 100px;">
                                        Autoridades
                                    </td>
                                    <td style="width: 50px;">
                                        Editar
                                    </td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="8">
                                        No se encontraron expedientes registrados en el sistema
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="ExpedienteId" Visible="false" />
                            <asp:BoundField DataField="Numero" HeaderText="Expediente" SortExpression="Numero" />
                            <asp:BoundField DataField="Observaciones" HeaderText="Asunto" ItemStyle-Width="150px"
                                SortExpression="Observaciones"></asp:BoundField>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha Visitadurías" ItemStyle-Width="100px"
                                SortExpression="Fecha" DataFormatString="{0:MM-dd-yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="NombreFuncionario" HeaderText="Visitador" ItemStyle-Width="150px"
                                SortExpression="NombreFuncionario"></asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" ItemStyle-Width="100px"
                                SortExpression="Estatus"></asp:BoundField>
                            <asp:BoundField DataField="NombreCiudadano" HeaderText="Quejosos" SortExpression="NombreCiudadano"
                                ItemStyle-Width="100px" />
                            <asp:BoundField DataField="NombreAutoridad" HeaderText="Autoridades" SortExpression="NombreAutoridad" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument='<%#Eval("ExpedienteId")%>' CommandName="Editar"
                                        ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
</asp:Content>
