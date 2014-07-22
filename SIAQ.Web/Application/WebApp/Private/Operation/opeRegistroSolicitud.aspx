<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroSolicitud" %>
<%@ Register src="../../../../Include/WebUserControls/wucBusquedaCiudadano.ascx" tagname="wucBusquedaCiudadano" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucFixedDateTime.ascx" tagname="wucFixedDateTime" tagprefix="wuc" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table class="GeneralTable">
		<tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Registrar solicitud
			</td>
		</tr>
		<tr>
			<td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione la siguiente información para registrar una nueva solicitud en el sistema."></asp:Label></td>
		</tr>
		<tr>
			<td>
				<asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table  border="0" style="width: 460px">
						<tr>
							<td class="Etiqueta">Fecha y Hora</td>
							<td class="Espacio"></td>
							<td class="Campo"><wuc:wucFixedDateTime ID="wucFixedDateTime" runat="server" /></td>
						</tr>
						<tr>
							<td class="Etiqueta">Nombre del Ciudadano</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo"><wuc:wucBusquedaCiudadano ID="wucBusquedaCiudadano" runat="server" OnItemSelected="wucBusquedaCiudadano_ItemSelected" /></td>
						</tr>
						<tr>
							<td class="Etiqueta">Funcionario</td>
							<td class="Espacio"></td>
							<td class="Campo"><asp:DropDownList ID="ddlFuncionario" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
						</tr>
						<tr>
							<td class="Etiqueta">Forma de Contacto</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo"><asp:DropDownList ID="ddlFormaContacto" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
						</tr>
						<tr>
							<td class="Etiqueta">Observaciones</td>
							<td class="VinetaObligatorio">*</td>
							<td class="Campo"></td>
						</tr>
					</table>
					<table border="0" style="width:100%">
						<tr>
							<td colspan="3" style="text-align:left;"><CKEditor:CKEditorControl ID="ckeObservaciones" BasePath="~/Include/Components/CKEditor/Core/" runat="server" MaxLength="8000"></CKEditor:CKEditorControl></td>
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
							<td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General" width="125px" onclick="btnGuardar_Click" /></td>
							<td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" /></td>
							<td style="height:24px;"></td>
						</tr>
					</table>
				</asp:Panel>
			</td>
		</tr>
		<tr><td class="tdCeldaMiddleSpace"></td></tr>
		<tr>
			<td style="text-align: left;">
				<asp:Label Text="Los campos marcados con " runat="server"></asp:Label> 
				<asp:Label CssClass="VinetaObligatorio" Text="*" runat="server"></asp:Label>
				<asp:Label ID="Label4" Text="son obligatorios." runat="server"></asp:Label> 
			</td>
		</tr>
		<tr class="trFilaFooter"><td></td></tr>
	</table>

	<asp:HiddenField ID="Sender" runat="server" Value=""  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

</asp:Content>