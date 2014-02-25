<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarVocesSenaladas.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarVocesSenaladas" %>
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
                        <td class="tdCeldaLeyendaItemFondoBlanco">Primer nivel</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:DropDownList ID="ddlPrimerNivel" runat="server" CssClass="DropDownList_General" Width="183px"></asp:DropDownList></td>
                        <td style="width:5px;"></td>
                    </tr> 
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Segundo nivel</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:DropDownList ID="ddlSegundoNivel" runat="server" CssClass="DropDownList_General" Width="183px"></asp:DropDownList></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Tercer nivel</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:DropDownList ID="ddlTercerNivel" runat="server" CssClass="DropDownList_General" Width="183px"></asp:DropDownList></td>
                        <td style="width:5px;"></td>
                    </tr> 
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Comentarios</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:TextBox ID="txtComentarios" runat="server" CssClass="Textarea_General" Width="400px"></asp:TextBox></td>
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
