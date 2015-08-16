<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMenu.ascx.cs" Inherits="SIAQ.Web.Include.WebUserControls.wucMenu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<table style="width:250px">
	<tr>
		<td>
			<ajaxToolkit:Accordion ID="acrdMenu" runat="server"
                AutoSize="None"
                ContentCssClass="AccordionContent"
                EnableViewState="true"
                FadeTransitions="false"
                FramesPerSecond="40"
                HeaderCssClass="AccordionHeader"
                HeaderSelectedCssClass="AccordionHeaderSelected"
                RequireOpenedPane="false"
                SuppressHeaderPostbacks="true"
                TransitionDuration="250">
			</ajaxToolkit:Accordion>					         
		</td>
	</tr>
</table>