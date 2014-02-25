﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeCalificarSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeCalificarSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
			<td class="tdCeldaTituloEncabezado">
				Calificar la solicitud
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
         <asp:Label ID="Label1" runat="server" Text="Especifica la calificación de la solicitud."></asp:Label>
         <br /><br />
         </td>      
      </tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Solicitud número:</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:Label ID="lblNumSolicitud" runat="server" Text="20202"></asp:Label></td>
                        <td style="width:200px;"></td>
                    </tr>
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Calificación</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:DropDownList ID="ddlCalificacion" runat="server" CssClass="DropDownList_General" Width="183px"></asp:DropDownList></td>
                        <td style="width:200px;"></td>
                    </tr> 
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Cierre de orientación</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:DropDownList ID="ddlCierreOrientacion" runat="server" CssClass="DropDownList_General" Width="183px"></asp:DropDownList></td>
                        <td style="width:200px;"></td>
                    </tr>
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Canalizado a</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:DropDownList ID="ddlCanalizado" runat="server" CssClass="DropDownList_General" Width="183px"></asp:DropDownList></td>
                        <td style="width:200px;"></td>
                    </tr> 
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Fundamento</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:TextBox ID="txtFundamento" runat="server" CssClass="Textarea_General" Width="400px"></asp:TextBox></td>
                        <td style="width:200px;"></td>
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
                    <td class="tdCeldaLeyendaItemFondoBlanco"><asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="Button_General_Verde" width="125px"/></td>
                    <td style="width:5px;"></td>
                    <td class="tdCeldaItem"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General_Verde" width="125px"/></td>
                    <td style="width:200px;"></td>
                </tr>
            </table>
        </asp:Panel>
        </td>
    </tr>
</table>
</asp:Content>