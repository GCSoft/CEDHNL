<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucASCiudadano.ascx.cs" Inherits="SIAQ.Web.Include.WebUserControls.wucASCiudadano" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<script type = "text/javascript">
	function ClientItemSelected(sender, e) {
		$get("<%=hddCiudadanoId.ClientID %>").value = e.get_value();
	}
</script>

<asp:TextBox ID="txtCiudadano" runat="server" CssClass="Textbox_General" Width="400px"></asp:TextBox>
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
	OnClientItemSelected="ClientItemSelected">
</ajaxToolkit:AutoCompleteExtender>

<asp:HiddenField ID="hddCiudadanoId" runat="server" />