<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroSolicitud" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="uc1" %>
<%@ Register src="../../../../Include/WebUserControls/wucTimeMask.ascx" tagname="wucTimeMask" tagprefix="uc2" %>




<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <script type="text/javascript" language="javascript">

        // Prototipos
        String.prototype.trim = function () { return this.replace(/^\s+|\s+$/g, ''); }

        // Funciones del programador

        function validateForm() {
            var txtNombre = document.getElementById('cntPrivateTemplateBody_txtNombre');
            var txtObservaciones = document.getElementById('cntPrivateTemplateBody_txtObservaciones');
            var ddlAbogado = document.getElementById('cntPrivateTemplateBody_ddlAbogado');

            var sNombre;
            var sObservaciones;
            var iAbogado;

            // Inicializacion de variables
            sNombre = txtNombre.value.trim();
            sObservaciones = txtObservaciones.value.trim();
            iAbogado = ddlAbogado.value;

            // Espacio en blanco
            if (sNombre == "") {
                tinyboxMessage('El campo Nombre es obligatorio', 'Fail', true);
                focusControl('cntPrivateTemplateBody_txtNombre');
                return false;
            }

            if (sObservaciones == "") {
                tinyboxMessage('El campo Observaciones es obligatorio', 'Fail', true);
                focusControl('cntPrivateTemplateBody_txtObservaciones');
                return false;
            }

            if (iAbogado == "0") {
                tinyboxMessage('El campo Abogado es obligatorio favor de seleccionar uno', 'Fail', true);
                focusControl('cntPrivateTemplateBody_ddlAbogado');
                return false;
            }

            return true;
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado">
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
                                <uc2:wucTimeMask ID="txtFechaCargado" runat="server" />
                            </td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                         <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Nombre</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="177px"></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">*</font>&nbsp;<asp:Button 
                                    ID="btnBuscar" runat="server"  Width="30px" Text="..." 
                                    onclick="btnBuscar_Click"></asp:Button>
                            </td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Abogado</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlAbogado" runat="server" CssClass="DropDownList_General" width="182px" ></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">*</font></td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Observaciones</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="Textarea_General" width="300px" TextMode="MultiLine"></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnGuardar" 
                             runat="server" Text="Guardar" CssClass="Button_General_Verde" width="125px" 
                             onclick="btnGuardar_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General_Verde" width="125px" /></td>
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
               
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>