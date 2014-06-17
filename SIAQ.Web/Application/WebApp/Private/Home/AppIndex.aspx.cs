/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	AppIndex
' Autor:	GCSoft - Web Project Creator BETA 1.0
' Fecha:	21-Octubre-2013
'
' Descripción:
'           Pantalla inicial de la aplicación
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
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Home
{
	public partial class AppIndex : BPPage
	{
      

		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			ENTSession oENTSession = new ENTSession();

			oENTSession = (ENTSession)Session["oENTSession"];

			switch (oENTSession.idRol){
				case 1: // System Administrator
					break;

				case 2: // Administrador
					break;

				case 3: // Recepción
					this.Response.Redirect("../Operation/opeInicio.aspx", false);
					break;

				case 4: // Queja - Secretaria
					this.Response.Redirect("../Operation/opeSolicitudSecretaria.aspx", false);
					break;

				case 5: // Queja - Funcionario
					this.Response.Redirect("../Operation/opeSolicitudFuncionario.aspx", false);
					break;

				case 6: // Queja - Director
					this.Response.Redirect("../Operation/opeBusquedaSolicitud.aspx", false);
					break;

				case 7: // Visitaduría - Secretaria
					break;

				case 8: // Visitaduría - Visitador
					break;

				case 9: // Visitaduría - Director
					break;

				case 10: // Seguimiento - Secretaria
					this.Response.Redirect("../Seguimiento/segListadoExpediente.aspx", false);
					break;

				case 11: // Seguimiento - Defensor
					this.Response.Redirect("../Seguimiento/segListadoExpediente.aspx", false);
					break;

				case 12: // Seguimiento - Director
					this.Response.Redirect("../Seguimiento/segListadoExpediente.aspx", false);
					break;

				case 13: // Atención a Víctimas - Secretaria
					this.Response.Redirect("../Victimas/VicListadoAtenciones.aspx", false);
					break;

				case 14: // Atención a Víctimas - Doctor
					this.Response.Redirect("../Victimas/VicListadoAtenciones.aspx", false);
					break;

				case 15: // Atención a Víctimas - Director
					this.Response.Redirect("../Victimas/VicListadoAtenciones.aspx", false);
					break;

				case 16: // Archivo
					this.Response.Redirect("../Archivo/arcBusquedaExpediente.aspx", false);
					break;

				default:
					break;
			}

		}


	}
}
