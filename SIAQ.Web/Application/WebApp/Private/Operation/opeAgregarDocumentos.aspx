﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarDocumentos.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarDocumentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
			<td class="tdCeldaTituloEncabezado">
				Agregar voces señaladas
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
         <asp:Label ID="Label1" runat="server" Text="Seleccione los distintos niveles de las voces a señalar en la solicitud."></asp:Label>
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
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Archivo</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem">
                            <asp:Textbox ID="txtArchivo" runat="server" CssClass="Textbox_General" Width="177px"></asp:Textbox>
                            <asp:Button ID="btnBuscar" runat="server" Text="..." Width="50px" />
                        </td>
                        <td style="width:5px;"></td>
                    </tr> 
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Nombre</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:Textbox ID="txtNombre" runat="server" CssClass="Textbox_General" Width="177px"></asp:Textbox></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Descripción</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:TextBox ID="txtDescripcion" runat="server" CssClass="Textarea_General" Width="400px"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                    </tr>   
                </table>
            </asp:Panel>
         </td>
         <td style="width:20px;"></td>
         <td rowspan="5" valign="top" style="width:200px;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="background-color:#DDDDFF; font-size:10px; border:1px solid #333333;">Voces señaladas en la solicitud</td>
                </tr>
                <tr>
                    <td style="background-color:#FBFBFF; font-size:10px; border:1px solid #333333;">
                        <asp:CheckBoxList ID="chkListCiudadanos" runat="server"></asp:CheckBoxList>
                    </td>
                </tr>
            </table>
         </td>
      </tr>
    <tr><td class="tdCeldaMiddleSpace"></td></tr>
    <tr>
        <td>
        <asp:Panel id="pnlBotones" runat="server" Width="100%">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="tdCeldaLeyendaItemFondoBlanco"><asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="Button_General_Verde" width="125px"/></td>
                    <td class="tdCeldaItem"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General_Verde" width="125px"/></td>
                </tr>
            </table>
        </asp:Panel>
        </td>
    </tr>
</table>
</asp:Content>
