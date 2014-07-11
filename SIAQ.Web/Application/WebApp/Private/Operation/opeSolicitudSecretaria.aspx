<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeSolicitudSecretaria.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeSolicitudSecretaria" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Listado de solicitudes
            </td>
	    </tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView ID="SolicitudGrid" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="SolicitudId, NumeroSol"
						OnRowCommand="SolicitudGrid_RowCommand"
						OnRowDataBound="SolicitudGrid_RowDataBound"
                        OnSorting="SolicitudGrid_Sorting">
                        <alternatingrowstyle cssclass="Grid_Row_Alternating" />
                        <headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width:100px;">Número Solicitud</td>
                                    <td style="width:100px;">Forma Contacto</td>
                                    <td style="width:150px;">Funcionario</td>
                                    <td>Detalle Queja</td>
                                    <td style="width:200px;">Estatus</td>
                                    <td style="width:30px;"></td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">No se encontraron solicitudes registradas en el sistema</td>
                                </tr>
                            </table>
						</EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField HeaderText="Número Solicitud"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="NumeroSol"								SortExpression="NumeroSol"></asp:BoundField>
                            <asp:BoundField HeaderText="Forma Contacto"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="NombreFormaContacto"						SortExpression="NombreFormaContacto"></asp:BoundField>
                            <asp:BoundField HeaderText="Funcionario"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="NombreFuncionario"						SortExpression="NombreFuncionario"></asp:BoundField>
                            <asp:BoundField HeaderText="Detalle Queja"		ItemStyle-HorizontalAlign="Left"							DataField="Observaciones"		HtmlEncode="false"	SortExpression="Observaciones"></asp:BoundField>
                            <asp:BoundField HeaderText="Estatus"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="NombreEstatus"							SortExpression="NombreEstatus"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument='<%#Eval("SolicitudId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                                </ItemTemplate>
							</asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
    </table>

    <asp:HiddenField ID="hddSort" runat="server" value="NumeroSol" />

</asp:Content>
