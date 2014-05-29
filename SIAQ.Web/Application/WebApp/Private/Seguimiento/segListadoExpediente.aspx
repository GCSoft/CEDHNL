<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segListadoExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segListadoExpediente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Listado de Expedientes
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" style="text-align:left; font-size:11px" width="100%">
                        <tr>
                            <td colspan="3">Expedientes disponibles</td>
                        </tr>
					</table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView id="gvExpedientes" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="ExpedientesId, tiActivo, Nombre" 
						onrowcommand="gvExpedientes_RowCommand" 
						onrowdatabound="gvExpedientes_RowDataBound"
						onsorting="gvExpedientes_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:150px;">Nombre del País</td>
									<td>Descripción</td>
									<td style="width:100px;">Estatus</td>
									<td style="width:25px;" ></td>
									<td style="width:25px;" ></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="5">No se encontraron Expedientes disponibles</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Nombre del País"	ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="Nombre"		SortExpression="Nombre"></asp:BoundField>
							<asp:BoundField HeaderText="Descripción"		ItemStyle-HorizontalAlign="Left"							DataField="Descripcion"	SortExpression="Descripcion"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"			ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="Estatus"		SortExpression="Estatus"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
									<asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
									<asp:ImageButton ID="imgAction" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Action" ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
        <asp:HiddenField ID="hddSort" runat="server" Value="Nombre" />
    </table>
</asp:Content>
