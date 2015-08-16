<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="vicClimaLaboral.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Victimas.vicClimaLaboral" %>
<%@ Register src="../../../../Include/WebUserControls/wucFixedDateTime.ascx" tagname="wucFixedDateTime" tagprefix="wuc" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table class="GeneralTable">
		<tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Registrar incidencia
			</td>
		</tr>
		<tr>
			<td class="SubTitulo"><asp:Label ID="lblTitulo" runat="server" Text="Proporcione la siguiente información para registrar una nueva incidencia de clima laboral."></asp:Label></td>
		</tr>
		<tr>
			<td>
				<asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0">
						<tr>
							<td class="Etiqueta">Fecha y Hora</td>
							<td class="Espacio"></td>
							<td class="Campo"><wuc:wucFixedDateTime ID="wucFixedDateTime" runat="server" /></td>
						</tr>
						<tr>
							<td class="Etiqueta">Usuario</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo"><asp:DropDownList ID="ddlUsuario" runat="server" CssClass="DropDownList_General" width="216px"></asp:DropDownList></td>
						</tr>
						<tr>
							<td colspan="3" style="text-align:left; vertical-align:bottom;">
								<asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar" CssClass="Button_General" onclick="btnAgregarUsuario_Click" Width="125px" />
							</td>
						</tr>
					</table>
					<table border="0" style="width:100%">
						<tr>
							<td style="text-align:Center;">
								<asp:GridView ID="gvUsuario" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
									DataKeyNames="idUsuario,sFullName" 
									OnRowDataBound="gvUsuario_RowDataBound"
									OnRowCommand="gvUsuario_RowCommand"
									OnSorting="gvUsuario_Sorting">
									<RowStyle CssClass="Grid_Row" />
									<EditRowStyle Wrap="True" />
									<HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
									<AlternatingRowStyle CssClass="Grid_Row_Alternating" />
									<EmptyDataTemplate>
										<table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
											<tr class="Grid_Header">
												<td style="width:250px;">Área</td>
												<td style="width:80px;">Sexo</td>
												<td style="width:200px;">Correo</td>
												<td>Nombre</td>
											</tr>
											<tr class="Grid_Row">
												<td colspan="4" style="text-align:center;">No se han agregado Usuarios</td>
											</tr>
										</table>
									</EmptyDataTemplate>
									<Columns>
										<asp:BoundField HeaderText="Área"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="sArea"		SortExpression="sArea"></asp:BoundField>
										<asp:BoundField HeaderText="Sexo"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="SexoNombre"	SortExpression="SexoNombre"></asp:BoundField>
										<asp:BoundField HeaderText="Correo"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="sEmail"		SortExpression="sEmail"></asp:BoundField>
										<asp:BoundField HeaderText="Nombre"	ItemStyle-HorizontalAlign="Left"							DataField="sFullName"	SortExpression="sFullName"></asp:BoundField>
										<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
											<ItemTemplate>
												<asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%#Eval("idUsuario")%>' CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" />
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</td>
						</tr>
					</table>
					<br />
					<table border="0" style="width:100%">
						<tr>
							<td class="Etiqueta" style="width:180px">Observaciones</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo"></td>
							<td></td>
						</tr>
						<tr>
							<td colspan="4" style="text-align:left; vertical-align:bottom;">
								<CKEditor:CKEditorControl ID="ckeObservaciones" BasePath="~/Include/Components/CKEditor/Core/" runat="server"></CKEditor:CKEditorControl>
							</td>
						</tr>
					</table>
				</asp:Panel>
			</td>
		</tr>
		<tr><td class="tdCeldaMiddleSpace"></td></tr>
		<tr>
			<td>
				<asp:Panel id="pnlBotones" runat="server" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr>
							<td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnGuardar" runat="server" CssClass="Button_General" Text="Guardar"  width="125px" OnClick="btnGuardar_Click" /></td>
							<td style="height:24px;"></td>
						</tr>
					</table>
			</asp:Panel>
			</td>
		</tr>
		<tr><td class="tdCeldaMiddleSpace"></td></tr>
		<tr>
			<td style="text-align:left;">
				<asp:Label ID="Label1" Text="Los campos marcados con " runat="server"></asp:Label> 
				<asp:Label ID="Label2" CssClass="style3" Text="*" runat="server"></asp:Label>
				<asp:Label ID="Label3" Text="son obligatorios." runat="server"></asp:Label> 
			</td>
		</tr>
    </table>

	<asp:HiddenField ID="hddSort" runat="server" value="sFullName" />

</asp:Content>
