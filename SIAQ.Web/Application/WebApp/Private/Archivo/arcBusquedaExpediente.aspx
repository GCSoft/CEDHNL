<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="arcBusquedaExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Archivo.arcBusquedaExpediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Búsqueda de Expedientes
            </td>
        </tr>
        <tr>
            <td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para buscar el expediente."></asp:Label></td>
        </tr>
		<tr>
            <td>
				<asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" style="width: 460px">
						<tr>
							<td class="Etiqueta">No. Expediente</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtExpediente" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
						<tr>
							<td class="Etiqueta">Quejoso</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtQuejoso" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
						<tr>
                            <td class="Etiqueta">Usuario con el Expediente</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:DropDownList ID="ddlUsuario" runat="server" CssClass="DropDownList_General" Width="216px" ></asp:DropDownList></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
		<tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 24px; text-align: left; width: 130px;">
								<asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" onclick="btnBuscar_Click" />
							</td>
                            <td style="height: 24px;"></td>
                        </tr>
                    </table>
                </asp:Panel>
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
									<td style="width:100px;">Número</td>
									<td style="width:100px;">Ubicación</td>
									<td style="width:300px;">Usuario con el Expediente</td>
									<td style="width:110px;">Fecha de Préstamo</td>
									<td>Comentarios</td>
									<td style="width:25px;"></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="6">Seleccione los filtros deseados y pulse el botón Buscar</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Número"						ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px" DataField="Numero"				SortExpression="Numero"></asp:BoundField>
							<asp:BoundField HeaderText="Ubicación"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px" DataField="Ubicacion"			SortExpression="Ubicacion"></asp:BoundField>
							<asp:BoundField HeaderText="Usuario con el Expediente"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="300px" DataField="UsuarioNombreRecibe"	SortExpression="UsuarioNombreRecibe"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha de Préstamo"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="110px" DataField="FechaPrestamo"		SortExpression="FechaPrestamo"></asp:BoundField>
							<asp:BoundField HeaderText="Comentarios"				ItemStyle-HorizontalAlign="Left"							DataField="Comentarios"			SortExpression="Comentarios"></asp:BoundField>
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
