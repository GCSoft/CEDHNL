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
							<td class="Etiqueta">No. Solicitud</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtSolicitudNumero" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
						<tr>
							<td class="Etiqueta">No. Expediente</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtExpedienteNumero" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
						<tr>
                            <td class="Etiqueta">Ubicación</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:DropDownList ID="ddlUbicacionExpediente" runat="server" CssClass="DropDownList_General" Width="216px" ></asp:DropDownList></td>
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
                    <asp:GridView id="gvArchivo" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="ArchivoId,ExpedienteNumero" 
						onrowcommand="gvArchivo_RowCommand" 
						onrowdatabound="gvArchivo_RowDataBound"
						onsorting="gvArchivo_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
									<td style="width:100px;">Número de Solicitud</td>
									<td style="width:100px;">Número de Expediente</td>
									<td style="width:200px;">Área</td>
									<td style="width:200px;">Calificación</td>
									<td style="width:100px;">Ubicación</td>
									<td style="width:110px;">Fecha de Préstamo</td>
									<td>Usuario con el Expediente</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="7">Seleccione los filtros deseados y pulse el botón Buscar</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Número de Solicitud"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="SolicitudNumero"		SortExpression="SolicitudNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Número de Expediente"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="ExpedienteNumero"	SortExpression="ExpedienteNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Área"						ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="AreaNombre"			SortExpression="AreaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Calificación"				ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="CalificacionNombre"	SortExpression="CalificacionNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Ubicación"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px" DataField="UbicacionNombre"		SortExpression="UbicacionNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha de Préstamo"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="110px" DataField="Fecha"				SortExpression="Fecha"></asp:BoundField>
							<asp:BoundField HeaderText="Usuario con el Expediente"	ItemStyle-HorizontalAlign="Left"							DataField="UsuarioNombreRecibe"	SortExpression="UsuarioNombreRecibe"></asp:BoundField>
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
        <asp:HiddenField ID="hddSort" runat="server" Value="ExpedienteNumero" />
    </table>
</asp:Content>
