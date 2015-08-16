<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="saChangePassword.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.SysApp.saChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
   <script type="text/javascript">

      function validateNewPassword() {
         var sOldPassword = document.getElementById('cntPrivateTemplateBody_sOldPassword').value;
         var sNewPassword = document.getElementById('cntPrivateTemplateBody_sNewPassword').value;
         var sNewPasswordConfirm = document.getElementById('cntPrivateTemplateBody_sNewPasswordConfirm').value;
         var oSpan = document.getElementById('spanMessage');

         var sTempOldPassword = sOldPassword.trim();
         var sTempNewPassword = sNewPassword.trim();
         var sTempNewPasswordConfirm = sNewPasswordConfirm.trim();


         // Espacios en blanco
         if (sOldPassword.length > 0 && sTempOldPassword.length == 0) {
            oSpan.innerHTML = 'No son permitidos los espacio en blanco';
            focusControl('cntPrivateTemplateBody_sOldPassword');
            return false;
         }

         if (sNewPassword.length > 0 && sTempNewPassword.length == 0) {
            oSpan.innerHTML = 'No son permitidos los espacio en blanco';
            focusControl('cntPrivateTemplateBody_sNewPassword');
            return false;
         }

         if (sNewPasswordConfirm.length > 0 && sTempNewPasswordConfirm.length == 0) {
            oSpan.innerHTML = 'No son permitidos los espacio en blanco';
            focusControl('cntPrivateTemplateBody_sNewPasswordConfirm');
            return false;
         }

         // Campos vacíos
         if (sOldPassword == '') {
            oSpan.innerHTML = 'Antigua contraseña requerida';
            focusControl('cntPrivateTemplateBody_sOldPassword');
            return false;
         }

         if (sNewPassword == '') {
            oSpan.innerHTML = 'Nueva contraseña requerida';
            focusControl('cntPrivateTemplateBody_sNewPassword');
            return false;
         }

         if (sNewPasswordConfirm == '') {
            oSpan.innerHTML = 'Confirmación de nueva contraseña requerida';
            focusControl('cntPrivateTemplateBody_sNewPasswordConfirm');
            return false;
         }

         // Contraseñas iguales
         if (sOldPassword == sNewPassword) {
            oSpan.innerHTML = 'Las antigua contraseña no puede ser igual a la nueva contraseña';
            focusControl('cntPrivateTemplateBody_sNewPassword');
            return false;
         }

         if (sNewPassword != sNewPasswordConfirm) {
            oSpan.innerHTML = 'Las nueva contraseña no coincide con la confirmación';
            focusControl('cntPrivateTemplateBody_sNewPasswordConfirm');
            return false;
         }

         // Minimo 8 caracteres
         if (sNewPassword.length < 8) {
            oSpan.innerHTML = 'La nueva contraseña debe contener un mínimo de 8 caracteres';
            focusControl('cntPrivateTemplateBody_sNewPassword');
            return false;
         }

         // Por lo menos un número
         if (/[0-9]+/.test(sNewPassword) == false) {
            oSpan.innerHTML = 'La nueva contraseña debe contener por lo menos un número';
            focusControl('cntPrivateTemplateBody_sNewPassword');
            return false;
         }

         // Por lo menos una mayúscula
         if (/[A-Z]+/.test(sNewPassword) == false) {
            oSpan.innerHTML = 'La nueva contraseña debe contener por lo menos una letra mayúscula';
            focusControl('cntPrivateTemplateBody_sNewPassword');
            return false;
         }

         oSpan.innerHTML = '';
         return true;
      }
		
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Cambio de Contraseña
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Contraseña Anterior</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="sOldPassword" runat="server" CssClass="Textbox_General" TextMode="Password" ></asp:TextBox></td>
						</tr>
						<tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Nueva Contraseña</td>
							<td style="width:3px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="sNewPassword" runat="server" CssClass="Textbox_General" TextMode="Password" ></asp:TextBox></td>
						</tr>
						<tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Confirme Contraseña</td>
							<td></td>
							<td class="tdCeldaItem"><asp:TextBox ID="sNewPasswordConfirm" runat="server" CssClass="Textbox_General" TextMode="Password" ></asp:TextBox></td>
						</tr>
						<tr style="height:3px;"><td colspan="3"></td></tr>
						<tr>
							<td colspan="3" style="text-align:left;">
								<span id="spanMessage" style="color:Red; font-family:Verdana; font-size:Smaller; display:block;">&nbsp;</span>
							</td>
						</tr>
					</table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddlePanel"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlBotones" runat="server" Width="100%">
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                     <td style="text-align:left;"><asp:Button ID="btnActualizarPassword" runat="server" Text="Actualizar Contraseña" CssClass="Button_General" OnClick="btnActualizarPassword_Click" width="125px" /></td>
							<td></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddlePanel"></td></tr>
      <tr>
         <td class="Notification" style="text-align:left; font-size:10px;">
            * La nueva contraseña deberá tener un mínimo de 8 caracteres de los cuales por lo menos uno deberá ser numérico y por lo menos debe de contener una mayúscula. No deberá contener espacios en blanco.
         </td>
      </tr>
   </table>
</asp:Content>
