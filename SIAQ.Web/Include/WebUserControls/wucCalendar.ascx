<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCalendar.ascx.cs" Inherits="SIAQ.Web.Include.WebUserControls.wucCalendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:TextBox runat="server" ID="txtCanvas" CssClass="Calendar_Canvas"></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="ceManager" runat="server" Format="dd/MM/yyyy" TargetControlID="txtCanvas" CssClass="Calendar_General" />
