/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	saNotificacion
' Autor:		GCSoft - Web Project Creator BETA 1.0
' Fecha:		21-Octubre-2013
'
' Descripción:
'           Pantalla de sistema enfocada a mostrar mensajes de la aplicación. No contiene Menú.
'
' Notas:
'				Hereda de la clase base SIAQ.BusinessProcess.Page.BPPage
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
using GCSoft.Utilities.Security;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.SysApp
{
	public partial class saNotificacion : BPPage
	{
	
		// Utilerías
		Encryption utilEncryption = new Encryption();
		

		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			// Validación. Solo la primera vez que se ejecuta la página
			if (this.IsPostBack) { return; }

			// Lógica de la página			
			ENTSession oENTSession = new ENTSession();

			try{
			
				// Mensajes por Default
				this.litEncabezado.Text = "Estimado Usuario, ha ocurrido un problema al querer ingresar a la página que solicitó, a continuación se detalla:";
            this.lblNotificacion.Text = "No tiene permisos de acceder a esta página";
				
				// Aviso
            this.lblNotificacion.Text = (this.Request.QueryString["key"] == null ? this.lblNotificacion.Text : utilEncryption.DecryptString(this.Request.QueryString["key"], true));

				// Nombre de usuario
				oENTSession = (ENTSession)this.Session["oENTSession"];
				this.litEncabezado.Text = "&nbsp;Estimado <b>" + oENTSession.sNombre + " </b>, ha ocurrido un problema al querer ingresar a la página que solicitó, a continuación se detalla:";

			}catch (Exception){
				// Do Nothing
			}
		}

		protected void lnkRegresar_Click(object sender, EventArgs e){
         if (this.lblNotificacion.Text.Substring(0,5) == "[V04]" ){

            // Se inactivó la compañía con el usuario dentro
            this.Response.Redirect("~/Application/WebApp/Private/SysApp/saLogout.aspx");
         }else{

            // Acceso prohibido común
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "parent.parent.window.location.href = '../../../../Application/WebApp/Private/Home/AppIndex.aspx';", true);
         }
		}


	}
}
