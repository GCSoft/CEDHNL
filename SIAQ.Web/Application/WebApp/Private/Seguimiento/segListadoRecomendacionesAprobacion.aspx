<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segListadoRecomendacionesAprobacion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segListadoRecomendacionesAprobacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Listado de Recomendaciones por aprobar su cierre
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView id="gvRecomendacion" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="RecomendacionId,RecomendacionNumero,NombreAutoridad" 
						OnRowCommand="gvRecomendacion_RowCommand" 
						OnRowDataBound="gvRecomendacion_RowDataBound"
						OnSorting="gvRecomendacion_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:160px;">Tipo</td>
									<td style="width:100px;">Número</td>
									<td style="width:200px;">Funcionario</td>
                                    <td style="width:150px;">Nombre de Autoridad</td>
                                    <td style="width:150px;">Puesto</td>
                                    <td>Autoridades</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">No se encontraron Recomendaciones/Acuerdos de no responabilidad pendientes por aprobar</td>
                                </tr>
                            </table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Tipo"					ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="160px"	DataField="Tipo"								SortExpression="Tipo"></asp:BoundField>
							<asp:BoundField HeaderText="Número"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="RecomendacionNumero"					SortExpression="RecomendacionNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Funcionario"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="FuncionarioNombre"					SortExpression="FuncionarioNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Nombre de Autoridad"	ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="NombreAutoridad"						SortExpression="NombreAutoridad"></asp:BoundField>
                            <asp:BoundField HeaderText="Puesto"					ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="PuestoAutoridad"						SortExpression="PuestoAutoridad"></asp:BoundField>
                            <asp:BoundField HeaderText="Autoridades"			ItemStyle-HorizontalAlign="Left"							DataField="Autoridades"		HtmlEncode="false"	SortExpression="Autoridades"></asp:BoundField>
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

	<asp:HiddenField ID="hddSort" runat="server" Value="RecomendacionNumero" />

</asp:Content>
