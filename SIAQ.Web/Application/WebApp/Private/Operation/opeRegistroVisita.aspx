<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroVisita.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroVisita" %>
<%@ Register src="../../../../Include/WebUserControls/wucFixedDateTime.ascx" tagname="wucFixedDateTime" tagprefix="wuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table class="GeneralTable">
		<tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Registrar visita
			</td>
		</tr>
		<tr>
			<td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione la siguiente información para registrar una nueva visita en el sistema."></asp:Label></td>
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
							<td class="Etiqueta">Área que visita</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo"><asp:DropDownList ID="ddlArea" runat="server" CssClass="DropDownList_General" width="216px"></asp:DropDownList></td>
						</tr>
						<tr>
							<td class="Etiqueta">Funcionario</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo"><asp:DropDownList ID="ddlUsuario" runat="server" CssClass="DropDownList_General" width="216px"></asp:DropDownList></td>
						</tr>
						<tr>
							<td class="Etiqueta">Motivo</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo"><asp:DropDownList ID="ddlMotivo" runat="server" CssClass="DropDownList_General" width="216px"></asp:DropDownList></td>
						</tr>
						<tr>
							<td class="Etiqueta">Visitante</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo">
								<script type = "text/javascript"> function ClientItemSelected(sender, e) { $get("<%=hddCiudadanoId.ClientID %>").value = e.get_value(); } </script>
								<asp:TextBox ID="txtCiudadano" runat="server" CssClass="Textbox_General" MaxLength="1000" Width="400px"></asp:TextBox>
								<asp:HiddenField ID="hddCiudadanoId" runat="server" />
								<ajaxToolkit:AutoCompleteExtender
									ID="autoCompleteExtender" 
									runat="server"
									TargetControlID="txtCiudadano"
									ServiceMethod="GetCitizenList"
									CompletionInterval="100"
									CompletionSetCount="10"
									EnableCaching="false"
									FirstRowSelected="false"
									MinimumPrefixLength="2"
									OnClientItemSelected="ClientItemSelected"
									CompletionListCssClass="Autocomplete_CompletionListElement"
									CompletionListItemCssClass="Autocomplete_ListItem"
									CompletionListHighlightedItemCssClass="Autocomplete_HighLightedListItem">
								</ajaxToolkit:AutoCompleteExtender>
							</td>
						</tr>
						<tr>
							<td colspan="3" style="text-align:left; vertical-align:bottom;">
								<asp:Button ID="btnAgregarCiudadano" runat="server" Text="Agregar" CssClass="Button_General" onclick="btnAgregarCiudadano_Click" Width="125px" />
							</td>
						</tr>
					</table>
					<table border="0" style="width:100%">
						<tr>
							<td style="text-align:Center;">
								<asp:GridView ID="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
									DataKeyNames="CiudadanoId,NombreCompleto" 
									OnRowDataBound="gvCiudadano_RowDataBound"
									OnRowCommand="gvCiudadano_RowCommand"
									OnSorting="gvCiudadano_Sorting">
									<RowStyle CssClass="Grid_Row" />
									<EditRowStyle Wrap="True" />
									<HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
									<AlternatingRowStyle CssClass="Grid_Row_Alternating" />
									<EmptyDataTemplate>
										<table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
											<tr class="Grid_Header">
												<td style="width:250px;">Nombre</td>
												<td style="width:90px;">Edad</td>
												<td style="width:80px;">Sexo</td>
												<td style="width:100px;">Telefono</td>
												<td>Domicilio</td>
											</tr>
											<tr class="Grid_Row">
												<td colspan="5" style="text-align:center;">No se han agregado ciudadanos a la visita</td>
											</tr>
										</table>
									</EmptyDataTemplate>
									<Columns>
										<asp:BoundField HeaderText="Nombre"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="NombreCompleto"			SortExpression="NombreCompleto"></asp:BoundField>
										<asp:BoundField HeaderText="Edad"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="90px"	DataField="Edad"					SortExpression="Edad"></asp:BoundField>
										<asp:BoundField HeaderText="Sexo"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="SexoNombre"				SortExpression="SexoNombre"></asp:BoundField>
										<asp:BoundField HeaderText="Telefono"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	DataField="TelefonoPrincipal"		SortExpression="TelefonoPrincipal"></asp:BoundField>
										<asp:BoundField HeaderText="Domicilio"	ItemStyle-HorizontalAlign="Left"							DataField="Domicilio"				SortExpression="Domicilio"></asp:BoundField>
										<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
											<ItemTemplate>
												<asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" />
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
							<td class="Etiqueta" style="width:180px">Detalle de visita</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo"></td>
							<td></td>
						</tr>
						<tr>
							<td colspan="4" style="text-align:left; vertical-align:bottom;">
								<CKEditor:CKEditorControl ID="ckeObservaciones" BasePath="~/Include/Components/CKEditor/Core/" runat="server" MaxLength="8000"></CKEditor:CKEditorControl>
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
							<td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" CssClass="Button_General" Text="Regresar" Width="125px" OnClick="btnRegresar_Click" /></td>
							<td style="height:24px;"></td>
						</tr>
					</table>
			</asp:Panel>
			</td>
		</tr>
		<tr><td class="tdCeldaMiddleSpace"></td></tr>
		<tr>
			<td style="text-align:left;">
				<asp:Label Text="Los campos marcados con " runat="server"></asp:Label> 
				<asp:Label CssClass="style3" Text="*" runat="server"></asp:Label>
				<asp:Label ID="Label1" Text="son obligatorios." runat="server"></asp:Label> 
			</td>
		</tr>
    </table>

	<asp:HiddenField ID="Sender" runat="server" Value=""  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" value="NombreCompleto" />

</asp:Content>
