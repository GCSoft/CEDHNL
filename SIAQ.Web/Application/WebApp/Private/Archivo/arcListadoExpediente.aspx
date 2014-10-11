<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="arcListadoExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Archivo.arcListadoExpediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Listado de Archivos
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView id="gvArchivo" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="ArchivoId,ExpedienteNumero" 
						OnRowCommand="gvArchivo_RowCommand" 
						OnRowDataBound="gvArchivo_RowDataBound"
						OnSorting="gvArchivo_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
                                    <td style="width:120px;">Número de Solicitud</td>
									<td style="width:120px;">Número de Expediente</td>
									<td style="width:200px;">Fecha</td>
									<td style="width:200px;">Área</td>
									<td>Calificación</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="5">No se encontraron Archivoes</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Número de Solicitud"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="SolicitudNumero"		SortExpression="SolicitudNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Número de Expediente"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="ExpedienteNumero"	SortExpression="ExpedienteNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="200px"	DataField="Fecha"				SortExpression="Fecha"></asp:BoundField>
							<asp:BoundField HeaderText="Área"					ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="AreaNombre"			SortExpression="AreaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Calificación"			ItemStyle-HorizontalAlign="Left"							DataField="CalificacionNombre"	SortExpression="CalificacionNombre"></asp:BoundField>
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
        <asp:HiddenField ID="hddSort" runat="server" Value="Fecha" />
    </table>
</asp:Content>
