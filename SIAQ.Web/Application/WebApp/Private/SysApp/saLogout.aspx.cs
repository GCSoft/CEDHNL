/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre: saLogout
' Autor:		GCSoft - Web Project Creator BETA 1.0
' Fecha:		21-Octubre-2013
'
' Descripción:
'           Pantalla de sistema enfocada a desautenticar al usuario firmado.
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
using SIAQ.BusinessProcess.Page;

namespace SIAQ.Web.Application.WebApp.Private.SysApp
{
   public partial class saLogout : BPPage
   {

      // Eventos de la página

      protected void Page_Load(object sender, EventArgs e){
         this.Session.Abandon();
         this.Response.Redirect("~/Index.aspx", true);
      }

   }
}
