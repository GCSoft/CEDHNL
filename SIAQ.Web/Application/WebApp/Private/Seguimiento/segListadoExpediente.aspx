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
									<td style="width:150px;">Recomendación</td>
									<td>Asunto</td>
									<td style="width:100px;">Fecha</td>
									<td style="width:120px;">Estatus</td>
									<td style="width:120px;">Quejosos</td>
									<td style="width:140px;">Autoridades</td>
									<td style="width:25px;"></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="7">No se encontraron Expedientes disponibles</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Recomendación"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="150px" DataField="Recomendacion"		SortExpression="Recomendacion"></asp:BoundField>
							<asp:BoundField HeaderText="Asunto"			ItemStyle-HorizontalAlign="Left"							DataField="Asunto"				SortExpression="Asunto"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"			ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="FechaSeguimientos"	SortExpression="FechaSeguimientos"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="Estatus"				SortExpression="Estatus"></asp:BoundField>
							<asp:BoundField HeaderText="Quejosos"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="Quejosos"			SortExpression="Quejosos"></asp:BoundField>
							<asp:BoundField HeaderText="Autoridades"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="Autoridades"			SortExpression="Autoridades"></asp:BoundField>
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
        <asp:HiddenField ID="hddSort" runat="server" Value="Recomendacion" />
    </table>
</asp:Content>
