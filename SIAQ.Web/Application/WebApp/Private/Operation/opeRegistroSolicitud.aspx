<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroSolicitud" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="uc1" %>
<%@ Register src="../../../../Include/WebUserControls/wucTimeMask.ascx" tagname="wucTimeMask" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Registro de Solicitudes
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Fecha</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem">
                                <uc1:wucCalendar ID="txtFechaCaptura" runat="server" />
                            </td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Hora</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem">
                                <wuc:wucTimeMask ID="txtFechaCargado" runat="server" />
                            </td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                         <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Nombre</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="150px"></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Tipo de Solicitud</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlTipoSolicitud" runat="server" CssClass="Textbox_General" width="150px" ></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Colonia</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtColonia" runat="server" CssClass="Textbox_General" width="150px"></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Descripción de los hechos</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtDescripcion" runat="server" CssClass="Textarea_General" width="300px"></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Dirección o lugar de los hechos</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtDireccion" runat="server" CssClass="Textarea_General" width="300px"></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="width:25%;"><asp:CheckBox ID="chkIndicador1" runat="server" Text="Indicador 1" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                                        <td style="width:25%"><asp:CheckBox ID="chkIndicador4" runat="server" Text="Indicador 4" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                                        <td style="width:50%"></td>
                                    </tr>
                                    <tr>
                                        <td style="width:25%;"><asp:CheckBox ID="chkIndicador2" runat="server" Text="Indicador 2" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                                        <td style="width:25%"><asp:CheckBox ID="chkIndicador5" runat="server" Text="Indicador 5" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                                        <td style="width:50%"></td>
                                    </tr>
                                    <tr>
                                        <td style="width:25%;"><asp:CheckBox ID="chkIndicador3" runat="server" Text="Indicador 3" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                                        <td style="width:25%"><asp:CheckBox ID="chkIndicador6" runat="server" Text="Indicador 6" CssClass="CheckBox_Regular"></asp:CheckBox></td>
                                        <td style="width:50%"></td>
                                    </tr>
                                </table>
                            </td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General_Verde" width="125px" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General_Verde" width="125px" /></td>
					 <td style="height:24px; width:530px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <!-- GRID -->
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
