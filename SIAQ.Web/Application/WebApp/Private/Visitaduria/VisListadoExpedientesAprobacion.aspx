<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VisListadoExpedientesAprobacion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.VisListadoExpedientesAprobacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Listado de Expedientes por aprobar su cierre
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
				<asp:Panel id="pnlFormulario" runat="server" Width="100%">
					<table class="GeneralTable" border="0" style="width: 460px">
						<tr>
							<td class="Etiqueta">Área</td>
							<td class="Espacio"></td>
							<td class="Campo"><asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="true" CssClass="DropDownList_General" width="216px" onselectedindexchanged="ddlArea_SelectedIndexChanged" ></asp:DropDownList></td>
						</tr>
						<tr style="height:10px;"><td colspan="3"></td></tr>
					</table>
				</asp:Panel>
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
                                    <td style="width:80px;">Expediente</td>
									<td style="width:80px;">Solicitud</td>
									<td style="width:150px;">Área</td>
									<td style="width:150px;">Funcionario</td>
									<td style="width:200px;">Afectado y Acompañantes</td>
									<td>Observaciones</td>
									<td style="width:200px;">Estatus</td>
									<td style="width:25px;"></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="8">No se encontraron Expedientees</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Expediente"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="ExpedienteNumero"					SortExpression="ExpedienteNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Solicitud"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="SolicitudNumero"						SortExpression="SolicitudNumero"></asp:BoundField>
                            <asp:BoundField HeaderText="Área"						ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="AreaNombre"							SortExpression="AreaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Funcionario"				ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="FuncionarioNombre"					SortExpression="FuncionarioNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Afectado y Acompañantes"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="Todos"								SortExpression="Todos"></asp:BoundField>
							<asp:BoundField HeaderText="Observaciones"				ItemStyle-HorizontalAlign="Left"							DataField="Observaciones"	HtmlEncode="false"	SortExpression="Observaciones"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"					ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="EstatusNombre"						SortExpression="EstatusNombre"></asp:BoundField>
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
    </table>

	<asp:HiddenField ID="hddSort" runat="server" Value="ExpedienteNumero" />

</asp:Content>
