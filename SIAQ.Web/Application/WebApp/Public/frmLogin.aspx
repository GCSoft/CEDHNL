<%@ Page Language="C#" MasterPageFile="~/Include/MasterPage/LoginTemplate.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.frmLogin" Title="SIAQ - Autenticación de Usuario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntLoginHeader" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntLoginBody" runat="server">
   <asp:Panel id="pnlLogin" runat="server" style="background-color:#E5E9EC; width:310px;">
		<table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:300px">
			<tr><td colspan="3" style="height:10px;"></td></tr>
			<tr style="height:25px; vertical-align:bottom;">
				<td style="width:10px;"></td>
				<td class="LoginText" style="width:80px">Correo</td>
				<td style="width:210px">
					<asp:TextBox id="txtEmail" runat="server" width="210px"></asp:TextBox>
				</td>
			</tr>
			<tr style="height:25px; vertical-align:bottom;">
				<td style="width:10px;"></td>
				<td class="LoginText">Password</td>
				<td>
					<asp:TextBox id="txtPassword" runat="server" TextMode="Password" width="210px"></asp:TextBox>
				</td>
			</tr>
			<tr style="height:25px; vertical-align:middle;">
				<td></td>
				<td colspan="2">
					<table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
						<tr>
							<td valign="middle" style="text-align:left; width:190px;">
								<span id="spanMessage" style="color:Red; font-family:'Lucida Grande',Tahoma,Verdana,Arial,Sans-serif; font-size:11px; display:none;"></span>
							</td>
							<td style="text-align:right; width:100px;">
								<asp:Button id="btnLogin" runat="server" Text="Iniciar sesión" CssClass="Button_General" OnClick="btnLogin_Click" width="100px"></asp:Button>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr><td colspan="3" style="height:3px;"></td></tr>
			<tr>
				<td colspan="3" style="height:1px;">
					<div style="border-bottom:1px solid #4B4878; height:1px; left:10px; position:relative; width:290px;"></div>
				</td>
			</tr>
			<tr><td colspan="3" style="height:3px;"></td></tr>
			<tr>
				<td></td>
				<td colspan="2" style="height:20px; vertical-align:top;">
					<asp:Panel ID="pnlCollapseHeader" runat="server" style="cursor:pointer;">
						<asp:Label ID="lblCollapseHeader" runat="server" CssClass="LoginTextLink" Text="Opciones"></asp:Label>
					</asp:Panel>
					<asp:Panel ID="pnlCollapseBody" runat="server" style="overflow:hidden; height:0"> 
						<table border="0" cellpadding="0" cellspacing="0">
							<tr><td colspan="2" style="height:10px;"></td></tr>
							<tr style="height:25px; vertical-align:middle;">
								<td style="width:10px;"></td>
								<td>
									<asp:CheckBox id="chkRememberPassword" runat="server" CssClass="CheckBox_Regular" Text="Recordar Contraseña"></asp:CheckBox>
								</td>
							</tr>
							<tr style="height:25px; vertical-align:middle;">
								<td style="width:10px;"></td>
								<td>
									<div style="left:3px; position:relative;">
										<asp:Button id="btnRecoveryPassword" runat="server" Text="Recuperar Contraseña" CssClass="Button_General" OnClick="btnRecoveryPassword_Click" width="125px"></asp:Button>
									</div>
								</td>
							</tr>
						</table>
					</asp:Panel>
					<ajaxToolkit:CollapsiblePanelExtender ID="cpeOptions" runat="Server" TargetControlID="pnlCollapseBody" Collapsed="true" CollapsedText="Opciones" ExpandedText="Ocultar" TextLabelID="lblCollapseHeader" ExpandControlID="pnlCollapseHeader" CollapseControlID="pnlCollapseHeader" SuppressPostBack="true" />
				</td>
			</tr>
			<tr><td colspan="3"></td></tr>
		</table>		
	</asp:Panel>
	<ajaxToolkit:DropShadowExtender ID="dseLogin" runat="server" TargetControlID="pnlLogin" Width="0" Rounded="true" Radius="6" Opacity=".75" TrackPosition="true" />
	<asp:HiddenField id="hddEncryption" runat="server" value="1"></asp:HiddenField>
</asp:Content>
