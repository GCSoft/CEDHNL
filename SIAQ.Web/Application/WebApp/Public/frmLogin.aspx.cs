/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre: frmLogin
' Autor:		GCSoft - Web Project Creator BETA 1.0
' Fecha:		21-Octubre-2013
'
' Descripción:
'           Pantalla de autenticación de la aplicación
'
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp
{
	public partial class frmLogin : System.Web.UI.Page
	{
	
		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();
	
	
		// Rutinas del programador
		
		private void cookiesGetConfiguration(){
         try
         {
            
            // Usuario
			   if ( this.Request.Cookies["txtEmail"] != null ){
				   this.txtEmail.Text = utilEncryption.DecryptString(this.Server.HtmlEncode(this.Request.Cookies["txtEmail"].Value), false);
			   }

			   // Password
			   if (this.Request.Cookies["txtPassword"] != null){
				   this.txtPassword.Attributes.Add("value", this.Server.HtmlEncode(this.Request.Cookies["txtPassword"].Value));
				   this.chkRememberPassword.Checked = true;
			   }

         }catch(Exception ex){
            throw(ex);
         }
		}

		private void cookiesSetConfiguration(){
			try
         {
            
            // Usuario
			   this.Response.Cookies["txtEmail"].Value = utilEncryption.EncryptString(this.txtEmail.Text, false);
			   this.Response.Cookies["txtEmail"].Expires = DateTime.Now.AddDays(100);

			   // Password
			   if (this.chkRememberPassword.Checked){
				   this.Response.Cookies["txtPassword"].Value = utilEncryption.EncryptString((this.hddEncryption.Value == "1" ? utilEncryption.DecryptString(this.txtPassword.Text, false) : this.txtPassword.Text), false);
				   this.Response.Cookies["txtPassword"].Expires = DateTime.Now.AddDays(100);
			   }else{
				   this.Response.Cookies["txtPassword"].Expires = DateTime.Now.AddDays(-1);
			   }

         }catch(Exception ex){
            throw(ex);
         }
		}
		
		private void loginUser(){
			BPUsuario oBPUsuario = new BPUsuario();
			
			ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession oENTSession = new ENTSession();
			
			try{
			
				// Datos del formulario
				oENTUsuario.sEmail = this.txtEmail.Text;
				oENTUsuario.sPassword = (this.hddEncryption.Value == "1" ? utilEncryption.DecryptString(this.txtPassword.Text, false) : this.txtPassword.Text);

				// Transacción
				oENTResponse = oBPUsuario.SelectUsuario_Autenticacion(oENTUsuario);
				
				// Validaciones
            if (oENTResponse.GeneratesException){ throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){ throw (new Exception(oENTResponse.sMessage)); }
				
				// Usuario válido
            cookiesSetConfiguration();
            this.Response.Redirect("../Private/Home/AppIndex.aspx", false);
				
			}catch(Exception ex){
				throw(ex);
			}
		}
		
		private void recoveryPassword(){
			BPUsuario oBPUsuario = new BPUsuario();

			ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Datos del formulario
				oENTUsuario.sEmail = this.txtEmail.Text;

				// Transacción
				oENTResponse = oBPUsuario.SelectUsuario_RecuperaContrasena(oENTUsuario);

				// Validaciones
				if (oENTResponse.GeneratesException){ throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){ throw (new Exception(oENTResponse.sMessage)); }

				// Recuperación exitosa
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Los datos de recuperación de contraseña han sido enviados por correo electrónico', 'Success', true); function pageLoad(){ focusControl('" + this.txtEmail.ClientID + "'); }", true);

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

				// Variable de sesión incial. Previene Sys.Webforms.PageRequestManagerServerErrorException
				this.Session.Add("oENTSession", new ENTSession());
			
				// Configuraciones personalizadas guardadas en las Cookies
				cookiesGetConfiguration();
				
				// Atributos de los controles
				this.btnLogin.Attributes.Add("onclick", "return validateLogin();");
				this.btnRecoveryPassword.Attributes.Add("onclick", "return validateRecoveryPassword();");
				this.txtPassword.Attributes.Add("onchange", "document.getElementById('" + this.hddEncryption.ClientID + "').value = '0'");
				
				// Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtEmail.ClientID + "'); }", true);

			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtEmail.ClientID + "'); }", true);
			}
		}

		protected void btnLogin_Click(object sender, EventArgs e){
         try
         {
            
            // Autenticar al usuario
            loginUser();

         }catch(Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtEmail.ClientID + "'); }", true);
         }
		}

		protected void btnRecoveryPassword_Click(object sender, EventArgs e){
         try
         {
            
            // Recuperar contraseña
            recoveryPassword();

         }catch(Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtEmail.ClientID + "'); }", true);
         }
		}
		
	}
}
