<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAcuerdoCalifDefinitiva.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAcuerdoCalifDefinitiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
			<td class="tdCeldaTituloEncabezado">
				Acuerdo de calificación definitiva
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
         <asp:Label ID="Label1" runat="server" Text="Proporcione la información del acuerdo de calificación definitiva para anexarla al expediente."></asp:Label>
         <br /><br />
         </td>      
      </tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Expediente Número</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:Label ID="lbNumeroSolictud" runat="server" Text="2000"></asp:Label></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco"></td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:20px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Calificación</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtCalificacion" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco"></td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Estatus</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtEstatus" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Fecha recepción</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFechaRecepcion" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Visitador</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFuncionario" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Fecha asignación</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFechaAsignacion" runat="server" CssClass="Textbox_General" Width="177px"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Forma de contacto</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFormaContacto" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Fecha inicio gestión</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFechaGestion" runat="server" CssClass="Textbox_General" Width="177px"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Tipo de solicitud</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtTipoSolicitud" runat="server" CssClass="Textbox_General"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Última modificación</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFechamodificacion" runat="server" CssClass="Textbox_General"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Observaciones (Recepción)</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem" colspan="5"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="Textarea_General" width="586px" ></asp:TextBox>&nbsp;</td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Lugar de los hechos</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtLugarHechos" runat="server" CssClass="Textbox_General"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco"></td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Dirección de los hechos</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtDireccionHechos" runat="server" CssClass="Textarea_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco"></td>
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
            <asp:panel ID="pnlDocumentos" runat="server" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="text-align:left;">Acuerdo de calificación definitiva</td>
                    </tr>
                    <tr>
                        <td style="background-color:Gray;">Barra de Herramientas</td>
                    </tr>
                    <tr>
                        <td style="background-color:Gray;">
                        <asp:TextBox ID="txtAsunto" runat="server" TextMode="MultiLine" CssClass="Textarea_General" Width="800px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:panel>
        </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlBotones" runat="server" Width="100%">
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnGuardar" runat="server" CssClass="Button_General_Verde" Text="Guardar" width="120px"></asp:Button></td>
                     <td style="height:24px; text-align:left; width:530px;"><asp:Button ID="btnRegresar" runat="server" CssClass="Button_General_Verde" Text="Regresar" width="120px"></asp:Button></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
    </table>
</asp:Content>
