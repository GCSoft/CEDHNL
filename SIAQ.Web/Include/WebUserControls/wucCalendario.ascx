<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCalendario.ascx.cs" Inherits="SIAQ.Web.Include.WebUserControls.wucCalendario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:TextBox ID="txtCalendario" runat="server" CssClass="Calendar_Canvas"></asp:TextBox>
<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCalendario" MaskType="Date" Mask="99/99/9999" MessageValidatorTip="true"></ajaxToolkit:MaskedEditExtender>
<div><ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1" ControlToValidate="txtCalendario" IsValidEmpty="true" ForeColor="Red" InvalidValueMessage="Formato de fecha inválido" ></ajaxToolkit:MaskedEditValidator></div>
<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalendario" Format="dd/MM/yyyy" CssClass="Calendar_General"></ajaxToolkit:CalendarExtender>
