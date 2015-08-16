<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="QueListadoSolicitudesEnProceso.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Quejas.QueListadoSolicitudesEnProceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Listado de solicitudes en proceso
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView id="gvSolicitud" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="SolicitudId,NumeroSol" 
						OnRowCommand="gvSolicitud_RowCommand" 
						OnRowDataBound="gvSolicitud_RowDataBound"
						OnSorting="gvSolicitud_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
                                    <td style="width:80px;">Solicitud</td>
                                    <td style="width:150px;">Calificación</td>
                                    <td style="width:150px;">Funcionario</td>
									<td style="width:150px;">Afectado</td>
									<td style="width:150px;">Acompañantes</td>
                                    <td>Observaciones</td>
                                    <td style="width:200px;">Estatus</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="7">No se encontraron Solicitudes pendientes de aprobación</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Solicitud"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="NumeroSol"								SortExpression="NumeroSol"></asp:BoundField>
							<asp:BoundField HeaderText="Calificación"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="CalificacionNombre"						SortExpression="CalificacionNombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Funcionario"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="FuncionarioNombre"						SortExpression="FuncionarioNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Afectado"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="Afectados"								SortExpression="Afectados"></asp:BoundField>
							<asp:BoundField HeaderText="Acompañantes"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="Acompanantes"							SortExpression="Acompanantes"></asp:BoundField>
                            <asp:BoundField HeaderText="Observaciones"		ItemStyle-HorizontalAlign="Left"							DataField="Observaciones"		HtmlEncode="false"	SortExpression="Observaciones"></asp:BoundField>
                            <asp:BoundField HeaderText="Estatus"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="EstatusNombre"							SortExpression="EstatusNombre"></asp:BoundField>
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
        <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
    </table>
</asp:Content>
