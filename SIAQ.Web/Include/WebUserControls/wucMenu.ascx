<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMenu.ascx.cs" Inherits="SIAQ.Web.Include.WebUserControls.wucMenu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<table border="0" cellpadding="0" cellspacing="0" style="width:244px">
	<tr><td style="height:96px;"></td></tr>
	<tr>
		<td>
			<ajaxToolkit:Accordion ID="acrdMenu" runat="server" AutoSize="None" ContentCssClass="AccordionContent" EnableViewState="true" FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="AccordionHeader" HeaderSelectedCssClass="AccordionHeaderSelected" RequireOpenedPane="false" SuppressHeaderPostbacks="true" TransitionDuration="250">
			</ajaxToolkit:Accordion>					         
		</td>
	</tr>
</table>