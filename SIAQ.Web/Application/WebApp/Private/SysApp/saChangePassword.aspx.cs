/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:   opeChangePassword
' Autor:		GCSoft - Web Project Creator BETA 1.0
' Fecha:		21-Octubre-2013
'
' Descripción:
'           Pantalla designada para cambio de contraseñas
'
' Notas:
'				Hereda de la clase base SIAQ.BusinessProcess.Page.BPPage
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Page;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.SysApp
{
   public partial class saChangePassword : BPPage
   {
     
      // Utilerías
		Function utilFunction = new Function();


      // Funciones del programador

		private void updateUserPassword(){
			BPUsuario oBPUsuario = new BPUsuario();

			ENTSession oENTSession = new ENTSession();
			ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Obtener sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Datos del formulario
				oENTUsuario.idUsuario = oENTSession.idUsuario;
				oENTUsuario.sPassword = this.sNewPassword.Text;
				oENTUsuario.sOldPassword = this.sOldPassword.Text;

				// Transacción
				oENTResponse = oBPUsuario.UpdateUsuario_ActualizaContrasena(oENTUsuario);

				// Validaciones
				if (oENTResponse.GeneratesException){ throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){ throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Su contraseña ha sido actualizada con éxito', 'Success', false); focusControl('" + this.sOldPassword.ClientID + "');", true);

			}catch (Exception ex){
				throw(ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			// Validación. Solo la primera vez que se ejecuta la página
			if (this.IsPostBack) { return; }

			// Lógica de la página

			try{

				// Atributos de los controles
				this.btnActualizarPassword.Attributes.Add("onclick", "return validateNewPassword();");

				// Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.sOldPassword.ClientID + "');", true);

			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.sOldPassword.ClientID + "');", true);
			}
		}

		protected void btnActualizarPassword_Click(object sender, EventArgs e){
          try
         {
            
            // Actualizar contraseña
            updateUserPassword();

         }catch(Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.sOldPassword.ClientID + "');", true);
         }
		}

   }
}