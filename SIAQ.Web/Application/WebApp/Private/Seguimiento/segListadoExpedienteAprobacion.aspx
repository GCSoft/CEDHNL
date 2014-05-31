<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segListadoExpedienteAprobacion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segListadoExpedienteAprobacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Listado de Expedientes pendientes por aprobar su cierre
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView id="gvExpediente" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="ExpedienteId,Numero" 
						onrowcommand="gvExpediente_RowCommand" 
						onrowdatabound="gvExpediente_RowDataBound"
						onsorting="gvExpediente_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
									<td style="width:100px;">Numero</td>
									<td>Observaciones</td>
									<td style="width:70px;">Fecha</td>
									<td style="width:250px;">Estatus</td>
									<td style="width:120px;">TipoSolicitud</td>
									<td style="width:120px;">LugarHechos</td>
									<td style="width:25px;"></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="7">No se encontraron Expedientes pendientes de aprobación de cierre</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Numero"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px" DataField="Numero"			SortExpression="Numero"></asp:BoundField>
							<asp:BoundField HeaderText="Observaciones"	ItemStyle-HorizontalAlign="Left"							DataField="Observaciones"	SortExpression="Observaciones"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"			ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="70px"	DataField="Fecha"			SortExpression="Fecha"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="Estatus"			SortExpression="Estatus"></asp:BoundField>
							<asp:BoundField HeaderText="TipoSolicitud"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="TipoSolicitud"	SortExpression="TipoSolicitud"></asp:BoundField>
							<asp:BoundField HeaderText="LugarHechos"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="LugarHechos"		SortExpression="LugarHechos"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
									<asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
        <asp:HiddenField ID="hddSort" runat="server" Value="Numero" />
    </table>
</asp:Content>
