<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarIndicadores.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarIndicadores" %>
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
                    <tr style="height:10px; background-color:#EEEEEE; text-align:left;"><td colspan="3">Condición de la víctima</td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:CheckBox ID="cnkMenor" runat="server" Text="Menor de edad" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:CheckBox ID="chkMigranteInter" runat="server" Text="Migrante internacional" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                        <td style="width:5px;"></td>
                    </tr> 
                    <tr style="height:3px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:CheckBox ID="chkAdultoMayor" runat="server" Text="Adulto mayor" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style="height:3px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:CheckBox ID="chkMigranteNacional" runat="server" Text="Migrante nacional" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                    <tr style="height:10px; background-color:#EEEEEE; text-align:left;"><td colspan="3">Actividad de la víctima</td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:CheckBox ID="chkJornalero" runat="server" Text="Jornalero" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:CheckBox ID="chkConstruccion" runat="server" Text="Construcción" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                        <td style="width:5px;"></td>
                    </tr> 
                    <tr style="height:3px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:CheckBox ID="chkSexoServidora" runat="server" Text="Sexo servidora" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style="height:3px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:CheckBox ID="chkEmpleadaDomestica" runat="server" Text="Empleada doméstica" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
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
                    <td class="tdCeldaLeyendaItemFondoBlanco"><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General_Verde" width="125px"/></td>
                    <td class="tdCeldaItem"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General_Verde" width="125px"/></td>
                </tr>
            </table>
        </asp:Panel>
        </td>
    </tr>
</table>
</asp:Content>
