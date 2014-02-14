<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroVisita.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroVisita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
        .style1
        {
            width: 118px;
        }
                
        .DetalleBox
        {
            font-family: Calibri, Verdana, Arial;
            height: 100px;
            width: 300px;
            
        }

        .style3
        {
            color: #ff0000;
            font-size: 14px;
            vertical-align: top;
            width: 26px;
            vertical-align:middle;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align:left">
      <tr>
			<td class="tdCeldaTituloEncabezado">
				Registrar visita
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
         <asp:Label runat="server" Text="Proporcione la siguiente información para registrar una nueva visita en el sistema."></asp:Label>
         <br /><br />
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
				<table border="0" style="width: 460px">
                  <tr>
                    <td class="style1">Fecha</td>
                    <td class="style3"></td>
                    <td><asp:TextBox ReadOnly="true" ID="txtBoxFecha" width="183px" runat="server"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td class="style1">Hora</td>
                    <td class="style3"></td>
                    <td><asp:TextBox ReadOnly="true" ID="txtBoxHora" width="183px" runat="server"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td class="style1">Área que visita</td>
                    <td class="style3">*</td>
                    <td><asp:DropDownList ID="ddlArea" runat="server" CssClass="DropDownList_General" width="183px"></asp:DropDownList></td>
                  </tr>
                  <tr>
                    <td class="style1">Funcionario</td>
                    <td class="style3">*</td>
                    <td><asp:DropDownList ID="ddlFuncionario" runat="server" CssClass="DropDownList_General" width="183px"></asp:DropDownList></td>
                  </tr>
                  <tr>
                    <td class="style1">Motivo</td>
                    <td class="style3">*</td>
                    <td><asp:DropDownList ID="ddlMotivo" runat="server" CssClass="DropDownList_General" width="183px"></asp:DropDownList></td>
                  </tr>
                  <tr>
                    <td class="style1">Detalle de visita</td>
                    <td class="style3">*</td>
                    <td><asp:TextBox CssClass="DetalleBox" ID="DescriptionBox" MaxLength="200" runat="server" TextMode="MultiLine"></asp:TextBox></td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnCancelar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" /></td>
							<td style="height:24px; width:530px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Label Text="Los campos marcados con " runat="server"></asp:Label> 
            <asp:Label CssClass="style3" Text="*" runat="server"></asp:Label>
             <asp:Label ID="Label1" Text="son obligatorios." runat="server"></asp:Label> 
         </td>
      </tr>
   </table>
</asp:Content>
