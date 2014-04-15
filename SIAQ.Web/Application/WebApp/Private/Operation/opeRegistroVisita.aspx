﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroVisita.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroVisita" %>
<%@ Register src="../../../../Include/WebUserControls/wucFixedDateTime.ascx" tagname="wucFixedDateTime" tagprefix="wuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table class="GeneralTable">
      <tr>
         <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
            Registrar visita
         </td>
      </tr>
      <tr>
         <td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione la siguiente información para registrar una nueva visita en el sistema."></asp:Label></td>
      </tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
               <table border="0" style="width: 460px">
                  <tr>
                     <td class="Etiqueta">Fecha y Hora</td>
                     <td class="Espacio"></td>
                     <td class="Campo"><wuc:wucFixedDateTime ID="wucFixedDateTime" runat="server" /></td>
                  </tr>
                  <tr>
                     <td class="Etiqueta">Área que visita</td>
                     <td class="VinetaObligatorio">*</td>
                     <td class="Campo"><asp:DropDownList ID="ddlArea" runat="server" CssClass="DropDownList_General" width="216px"></asp:DropDownList></td>
                  </tr>
                  <tr>
                     <td class="Etiqueta">Funcionario</td>
                     <td class="VinetaObligatorio">*</td>
                     <td class="Campo"><asp:DropDownList ID="ddlFuncionario" runat="server" CssClass="DropDownList_General" width="216px"></asp:DropDownList></td>
                  </tr>
                  <tr>
                     <td class="Etiqueta">Motivo</td>
                     <td class="VinetaObligatorio">*</td>
                     <td class="Campo"><asp:DropDownList ID="ddlMotivo" runat="server" CssClass="DropDownList_General" width="216px"></asp:DropDownList></td>
                  </tr>
                  <tr>
                     <td class="Etiqueta">Detalle de visita</td>
                     <td class="VinetaObligatorio">*</td>
                     <td class="Campo"><asp:TextBox CssClass="Textarea_General" ID="DescriptionBox" MaxLength="200" runat="server" TextMode="MultiLine" width="300px"></asp:TextBox></td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnGuardar" OnClick="GuardarButton_Click" runat="server" Text="Guardar" CssClass="Button_General" width="125px" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" 
                             runat="server" Text="Regresar" CssClass="Button_General" Width="125px" 
                             onclick="btnRegresar_Click" /></td>
                     <td style="height:24px; width:530px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td style="text-align: left;">
            <asp:Label Text="Los campos marcados con " runat="server"></asp:Label> 
            <asp:Label CssClass="style3" Text="*" runat="server"></asp:Label>
            <asp:Label ID="Label1" Text="son obligatorios." runat="server"></asp:Label> 
         </td>
      </tr>
    </table>
</asp:Content>
