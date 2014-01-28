<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucTimeMask.ascx.cs" Inherits="SafeTransfere.Web.Include.WebUserControls.wucTimeMask" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

        <asp:TextBox ID="txtCanvas" runat="server" Width="80px" Height="16px" ValidationGroup="MKE" />
        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
            TargetControlID="txtCanvas" 
            Mask="99:99"
            MessageValidatorTip="true"
            OnFocusCssClass="MaskedEditFocus"
            OnInvalidCssClass="MaskedEditError"
            MaskType="Time"
            AcceptAMPM="True"
            ErrorTooltipEnabled="True" />
        <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
            ControlExtender="MaskedEditExtender3"
            ControlToValidate="txtCanvas"
            IsValidEmpty="False"
            EmptyValueMessage="Time is required"
            InvalidValueMessage="Time is invalid"
            Display="Dynamic"
            TooltipMessage="Input a time"
            EmptyValueBlurredText="*"
            InvalidValueBlurredMessage="*"
            ValidationGroup="MKE"/>