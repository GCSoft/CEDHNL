<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeLstRecDefensor.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.opeLstRecDefensor" %>

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
                Listado de recomendaciones
            </td>
        </tr>
        <tr>
            <td class="SubTitulo">
                <asp:Label ID="Label2" runat="server" Text="Listado de recomendaciones asignadas al defensor"></asp:Label>
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
                        AutoGenerateColumns="False" Width="800px" DataKeyNames="Recomendacion" OnRowCommand="gvApps_RowCommand"
                        OnRowDataBound="gvApps_RowDataBound" OnSorting="gvApps_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width: 100px;">
                                        Recomendación
                                    </td>
                                    <td style="width: 200px;">
                                        Asunto
                                    </td>
                                    <td style="width: 100px;">
                                        Fecha Seguimientos
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
                                    <td style="width: 100px;">
                                        Atender
                                    </td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="7">
                                        No se encontraron Recomendaciones registrados en el sistema
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="Expediente" Visible="false" />
                            <asp:BoundField DataField="Recomendacion" HeaderText="Recomendación" SortExpression="Recomendacion" />
                            <asp:BoundField DataField="Asunto" HeaderText="Asunto" SortExpression="Asunto">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaSeguimientos" HeaderText="Fecha Seguimientos" SortExpression="FechaSeguimientos">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quejosos" HeaderText="Quejosos" SortExpression="Quejosos">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Autoridades" HeaderText="Autoridades" SortExpression="Autoridades">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument='<%#Eval("Recomendacion")%>' CommandName="Editar"
                                        ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter">
            <td>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
</asp:Content>
