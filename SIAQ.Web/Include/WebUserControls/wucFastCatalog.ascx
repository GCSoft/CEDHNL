<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucFastCatalog.ascx.cs" Inherits="SIAQ.Web.Include.WebUserControls.wucFastCatalog" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!-- Control -->
<asp:Panel ID="pnlControl" runat="server" style="border:1px solid #5E8291; height:20px; left:0px; text-align:center; top:0px; width:20px;">
   <table border="0" cellpadding="0" cellspacing="0">
      <tr>
         <td style="width:20px;"><asp:ImageButton ID="imgAgregar" runat="server" Enabled="false" ImageUrl="~/Include/Image/Buttons/FastCatalog_Off.png" onclick="imgAgregar_Click" /></td>
      </tr>
   </table>
</asp:Panel>

<!-- Pop Up -->
<asp:Panel ID="pnlAction" runat="server" CssClass="ActionBlock">
	<asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" style="top:200px;" Height="100px" Width="735px">
		<asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
			<table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%;">
				<tr>
					<td style="width:10px"></td>
					<td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle"></asp:Label></td>
					<td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton></td>
					<td style="width:10px"></td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
			<div style="margin:0 auto; width:98%;">
				<table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
					<tr style="height:20px;"><td></td></tr>
					<tr class="trFilaItem">
						<td>
							<table cellpadding="0" cellspacing="0">
								<tr>
									<td style="text-align:left;"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" MaxLength="200" width="620px" ></asp:TextBox></td>
									<td style="width:10px;"></td>
									<td style="text-align:left;"><asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="Button_General" width="92px" onclick="btnCrear_Click" /></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr style="height:5px;"><td></td></tr>
					<tr>
						<td><asp:Label ID="lblMessage" runat="server" CssClass="ActionContentMessage"></asp:Label></td>
					</tr>
				</table>
			</div>
		</asp:Panel>
	</asp:Panel>
	<ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"></ajaxToolkit:DragPanelExtender>
</asp:Panel>

<asp:HiddenField ID="hddFastCatalogType" runat="server" Value="" />
<asp:HiddenField ID="hddItemCreatedID" runat="server" Value="0" />
<asp:HiddenField ID="hddPaisId" runat="server" Value="0" />
<asp:HiddenField ID="hddEstadoId" runat="server" Value="0" />
<asp:HiddenField ID="hddMunicipioId" runat="server" Value="0" />