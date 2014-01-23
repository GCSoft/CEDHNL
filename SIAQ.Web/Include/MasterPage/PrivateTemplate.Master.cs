/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	PrivateTemplate
' Autor:		GCSoft - Web Project Creator BETA 1.0
' Fecha:		21-Octubre-2013
'
' Descripción:
'           MasterPage de las pantallas de trabajo en la sección Privada de la aplicación
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
using SIAQ.Entity.Object;

namespace SIAQ.Web.Include.MasterPage
{
	public partial class PrivateTemplate : System.Web.UI.MasterPage
	{

		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			// Validación. Solo la primera vez que se ejecuta la página
			if (this.IsPostBack) { return; }

			// Lógica de la página			
			ENTSession oENTSession = new ENTSession();

			try
			{

				// Imagen de Exit
				this.imgExit.Attributes.Add("onmouseover", "src='../../../../Include/Image/Web/SalirOn.png'");
				this.imgExit.Attributes.Add("onmouseout", "src='../../../../Include/Image/Web/SalirOff.png'");

				// Nombre de usuario
				oENTSession = (ENTSession)this.Session["oENTSession"];
				this.lblUserName.Text = "Bienvenido: " + oENTSession.sNombre + " | ";

			}catch (Exception){
				// Do Nothing
			}

		}

		protected void imgExit_Click(object sender, ImageClickEventArgs e){
			this.Response.Redirect("~/Application/WebApp/Private/SysApp/saLogout.aspx");
		}
		
	}
}
