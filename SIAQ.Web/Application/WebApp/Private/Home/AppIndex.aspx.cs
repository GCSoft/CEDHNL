/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	AppIndex
' Autor:		GCSoft - Web Project Creator BETA 1.0
' Fecha:		21-Octubre-2013
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

          switch (oENTSession.idRol)
          {
              case 3:
                  this.Response.Redirect("../Operation/opeInicio.aspx", false);
                  break;

              case 4:
                  this.Response.Redirect("../Operation/opeSolicitudSecretaria.aspx", false);
                  break;

              case 5:
                  this.Response.Redirect("../Operation/opeSolicitudFuncionario.aspx", false);
                  break;

              case 6:
                  this.Response.Redirect("../Operation/opeBusquedaSolicitud.aspx", false);
                  break;

              default:
                  break;
          }
      }

	}
}
