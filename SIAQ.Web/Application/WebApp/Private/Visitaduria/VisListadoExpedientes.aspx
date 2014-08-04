<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VisListadoExpedientes.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.VisListadoExpedientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Listado de Expedientes
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView id="gvExpediente" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="ExpedienteId,ExpedienteNumero" 
						OnRowCommand="gvExpediente_RowCommand" 
						OnRowDataBound="gvExpediente_RowDataBound"
						OnSorting="gvExpediente_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
                                    <td style="width:100px;">Número de Atención</td>
									<td style="width:100px;">Número de Expediente</td>
									<td style="width:100px;">Número de Solicitud</td>
									<td style="width:150px;">Estatus</td>
									<td style="width:75px;">Fecha</td>
									<td>Observaciones</td>
									<td style="width:25px;"></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="8">No se encontraron Expedientees</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Número de Atención"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px" DataField="ExpedienteNumero"							SortExpression="ExpedienteNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Número de Expediente"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="ExpedienteNumero"						SortExpression="ExpedienteNumero"></asp:BoundField>
                            <asp:BoundField HeaderText="Número de Solicitud"	ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px"	DataField="SolicitudNumero"							SortExpression="SolicitudNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"				ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="EstatusNombre"							SortExpression="EstatusNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="75px"	DataField="FechaExpediente"							SortExpression="FechaExpediente"></asp:BoundField>
							<asp:BoundField HeaderText="Observaciones"			ItemStyle-HorizontalAlign="Left"							DataField="Observaciones"		HtmlEncode="false"	SortExpression="Observaciones"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
									<asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
    </table>

	<asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />

</asp:Content>
