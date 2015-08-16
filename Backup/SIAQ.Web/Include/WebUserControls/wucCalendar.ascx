<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCalendar.ascx.cs" Inherits="SIAQ.Web.Include.WebUserControls.wucCalendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:TextBox runat="server" ID="txtCanvas" CssClass="Calendar_Canvas"></asp:TextBox>
<ajaxToolkit:MaskedEditExtender ID="maskCalendar" runat="server" TargetControlID="txtCanvas" MaskType="Date" Mask="99/99/9999" MessageValidatorTip="true"></ajaxToolkit:MaskedEditExtender>
<div><ajaxToolkit:MaskedEditValidator ID="validatorMask" runat="server" ControlExtender="maskCalendar" ControlToValidate="txtCanvas" IsValidEmpty="true" ForeColor="Red" InvalidValueMessage="Formato de fecha inválido" ></ajaxToolkit:MaskedEditValidator></div>
<ajaxToolkit:CalendarExtender ID="ceManager" runat="server" Format="dd/MM/yyyy" TargetControlID="txtCanvas" CssClass="Calendar_General" />
